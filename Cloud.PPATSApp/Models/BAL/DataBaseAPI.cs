using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Models.BAL
{
    public  class DataBaseAPI
    {
        CloudPATContext dbContext = new CloudPATContext();
        private readonly CloudPATContext _db;         
        public DataBaseAPI( CloudPATContext dbContext)
        {
            _db = dbContext;
            
        }

        public DataBaseAPI()
        {
        }

        //public DataTable GetMeasuringApplicationMappings(string AppCode)
        //{

        //}

        public DataSet CheckUserAuthetication(string username, string password)
        {
            SqlParameter usernameParam = new SqlParameter("@UserName", username.ToString() ?? (object)DBNull.Value);
            SqlParameter passwordParam = new SqlParameter("@Password", password.ToString() ?? (object)DBNull.Value);
             
            var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(dbConnection))
            {
                using (SqlCommand cmd = new SqlCommand("prcCheckUserAuthentication", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(usernameParam);
                        cmd.Parameters.Add(passwordParam);
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }

        public DataSet GetPPATMasterInfo(string AppCode)
        {
            SqlParameter AppCodeParam = new SqlParameter("@AppCode", AppCode.ToString() ?? (object)DBNull.Value);

            var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(dbConnection))
            {
                using (SqlCommand cmd = new SqlCommand("prcGetPPATMasterInfo", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(AppCodeParam);
                        da.Fill(ds);
                    }
                }
            }
            return ds;
        }

        //private  List<T> MapToList<T>(this DbDataReader dr)
        //{
        //    var objList = new List<T>();
        //    var props = typeof(T).GetRuntimeProperties();

        //    var colMapping = dr.GetColumnSchema()
        //      .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
        //      .ToDictionary(key => key.ColumnName.ToLower());

        //    if (dr.HasRows)
        //    {
        //        while (dr.Read())
        //        {
        //            T obj = Activator.CreateInstance<T>();
        //            foreach (var prop in props)
        //            {
        //                var val =
        //                  dr.GetValue(colMapping[prop.Name.ToLower()].ColumnOrdinal.Value);
        //                prop.SetValue(obj, val == DBNull.Value ? null : val);
        //            }
        //            objList.Add(obj);
        //        }
        //    }
        //    return objList;
        //}


    }
}
