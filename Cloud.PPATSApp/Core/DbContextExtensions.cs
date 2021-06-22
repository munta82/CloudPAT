using Cloud.PPATSApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Core
{
    public static  class DbContextExtensions
    {
        private readonly static CloudPATContext _db;
        public static DataTable DataTable(this DbContext context, string sqlQuery)
        {
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(_db.Database.GetDbConnection());

            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = _db.Database.GetDbConnection();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
        }
        public static async Task<IList<IList>> MultiResultSetsFromSql(this DbContext dbContext, ICollection<Type> resultSetMappingTypes, string sql, params object[] parameters)
        {
            var resultSets = new List<IList>();

            var connection = dbContext.Database.GetDbConnection();
            var parameterGenerator = dbContext.GetService<IParameterNameGeneratorFactory>()
                                                .Create();
            var commandBuilder = dbContext.GetService<IRelationalCommandBuilderFactory>()
                                            .Create();

            foreach (var parameter in parameters)
            {
                var generatedName = parameterGenerator.GenerateNext();
                if (parameter is DbParameter dbParameter)
                    commandBuilder.AddRawParameter(generatedName, dbParameter);
                else
                    commandBuilder.AddParameter(generatedName, generatedName);
            }

            using var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Connection = connection;
            for (var i = 0; i < commandBuilder.Parameters.Count; i++)
            {
                var relationalParameter = commandBuilder.Parameters[i];
                relationalParameter.AddDbParameter(command, parameters[i]);
            }

            var materializerSource = dbContext.GetService<IEntityMaterializerSource>();
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();
            foreach (var pair in resultSetMappingTypes.Select((x, i) => (Index: i, Type: x)))
            {
                var i = pair.Index;
                var resultSetMappingType = pair.Type;
                if (i > 0 && !(await reader.NextResultAsync()))
                    throw new InvalidOperationException(string.Format("No result set at index {0}, unable to map to {1}.", i, resultSetMappingType));

                var type = resultSetMappingType;
                var entityType = dbContext.GetService<IModel>()
                                            .FindEntityType(type);
                if (entityType == null)
                    throw new InvalidOperationException(string.Format("Unable to find a an entity type (or query type) matching '{0}'", type));
                var relationalTypeMappingSource = dbContext.GetService<IRelationalTypeMappingSource>();
                var columns = Enumerable.Range(0, reader.FieldCount)
                                        .Select(x => new
                                        {
                                            Index = x,
                                            Name = reader.GetName(x)
                                        })
                                        .ToList();
                var relationalValueBufferFactoryFactory = dbContext.GetService<IRelationalValueBufferFactoryFactory>();
                int discriminatorIdx = -1;
                var discriminatorProperty = entityType.GetDiscriminatorProperty();
                var entityTypes = entityType.GetDerivedTypesInclusive();

                var instanceTypeMapping = entityTypes.Select(et => new
                {
                    EntityType = et,
                    Properties = et.GetProperties()
                                    .Select(x =>
                                    {
                                        var column = columns.FirstOrDefault(y => string.Equals(y.Name,
                                                                                                x.GetColumnName() ?? x.Name, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException(string.Format("Unable to find a column mapping property '{0}'.", x.Name));

                                        if (x == discriminatorProperty)
                                            discriminatorIdx = column.Index;
                                        return new TypeMaterializationInfo(x.PropertyInfo.PropertyType, x, relationalTypeMappingSource, column.Index);
                                    })
                                    .ToArray()
                })
                .Select(x => new
                {
                    EntityType = x.EntityType,
                    Properties = x.Properties,
                    ValueBufferFactory = relationalValueBufferFactoryFactory.Create(x.Properties)
                })
                .ToDictionary(e => e.EntityType.GetDiscriminatorValue() ?? e.EntityType, e => e)
                ;

                var resultSetValues = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                while (await reader.ReadAsync())
                {
                    var instanceInfo = discriminatorIdx < 0 ? instanceTypeMapping[entityType] : instanceTypeMapping[reader[discriminatorIdx]];

                    var valueBuffer = instanceInfo.ValueBufferFactory.Create(reader);

                    var materializationAction = materializerSource.GetMaterializer(instanceInfo.EntityType);
                    resultSetValues.Add(materializationAction(new MaterializationContext(valueBuffer, dbContext)));
                }

                resultSets.Add(resultSetValues);
            }

            return resultSets;
        }

        public static async Task<(IReadOnlyCollection<T1> FirstResultSet, IReadOnlyCollection<T2> SecondResultSet)> MultiResultSetsFromSql<T1, T2>(this DbContext dbContext, string sql, params object[] parameters)
        {
            var resultSetMappingTypes = new[]
                                        {
                                        typeof(T1), typeof(T2)
                                };

            var resultSets = await MultiResultSetsFromSql(dbContext, resultSetMappingTypes, sql, parameters);

            return ((IReadOnlyCollection<T1>)resultSets[0], (IReadOnlyCollection<T2>)resultSets[1]);
        }

        public static async Task<(IReadOnlyCollection<T1> FirstResultSet, IReadOnlyCollection<T2> SecondResultSet, IReadOnlyCollection<T3> ThirdResultSet)> MultiResultSetsFromSql<T1, T2, T3>(this DbContext dbContext, string sql, params object[] parameters)
        {
            var resultSetMappingTypes = new[]
                                        {
                                        typeof(T1), typeof(T2), typeof(T3)
                                };

            var resultSets = await MultiResultSetsFromSql(dbContext, resultSetMappingTypes, sql, parameters);

            return ((IReadOnlyCollection<T1>)resultSets[0], (IReadOnlyCollection<T2>)resultSets[1], (IReadOnlyCollection<T3>)resultSets[2]);
        }

    }

}
