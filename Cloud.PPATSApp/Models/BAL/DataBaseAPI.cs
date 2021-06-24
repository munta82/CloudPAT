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
    public class DataBaseAPI
    {
        CloudPATContext dbContext = new CloudPATContext();
        private readonly CloudPATContext _db;
        public DataBaseAPI(CloudPATContext dbContext)
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

        public DataSet GetEmployeeInfo(string username = "", int empId = -1)
        {
            SqlParameter usernameParam = new SqlParameter("@UserName", username.ToString() ?? (object)DBNull.Value);
            SqlParameter empIdParam = new SqlParameter("@EmpId", empId.ToString() ?? (object)DBNull.Value);

            var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(dbConnection))
            {
                using (SqlCommand cmd = new SqlCommand("prcGetEmployeeInfo", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(usernameParam);
                        cmd.Parameters.Add(empIdParam);
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

        public DataSet GetPPATConstituencyInfo(string PSCode)
        {
            SqlParameter PSCodeParam = new SqlParameter("@PSCode", PSCode.ToString() ?? (object)DBNull.Value);

            var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
            DataSet ds = new DataSet();
            using (var con = new SqlConnection(dbConnection))
            {
                using (SqlCommand cmd = new SqlCommand("prcGetAssemblyPollingStationsData", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(PSCodeParam);
                        da.Fill(ds);
                    }
                }
            }

            return ds;
        }

        public List<SubCasteLookUp> GetPPATSubCasteData(string searchString, string communityCode)
        {
            List<SubCasteLookUp> listSubCaste = new List<SubCasteLookUp>();
            try
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    var obj = db.SubCasteLookUps.Where(a => a.CommunityCode.Equals(communityCode.ToString())
                    && a.SubCasteName.StartsWith(searchString)).ToList();
                    if (obj != null)
                    {
                        foreach (var data in obj.ToList())
                        {
                            listSubCaste.Add(new SubCasteLookUp { SubCasteCode = data.SubCasteCode, SubCasteName = data.SubCasteName });
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return listSubCaste;
        }

        public AssemblyPollingStationLookUp GetPPATPollingStationData(string PSCode)
        {
            AssemblyPollingStationLookUp AsseblyPollingInfo = new AssemblyPollingStationLookUp();
            try
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    var obj = db.AssemblyPollingStationLookUps.Where(a => a.Pscode.Equals(PSCode.ToString())).FirstOrDefault();
                    if (obj != null)
                    {
                        AsseblyPollingInfo.Psid = obj.Psid;
                        AsseblyPollingInfo.Pscode = obj.Pscode;
                        AsseblyPollingInfo.Psname = obj.Psname;
                        AsseblyPollingInfo.VillageCode = obj.VillageCode;
                        AsseblyPollingInfo.MandalCode = obj.MandalCode;
                        AsseblyPollingInfo.Accode = obj.Accode;
                        AsseblyPollingInfo.Pccode = obj.Pccode;
                        AsseblyPollingInfo.StateCode = obj.StateCode;
                        AsseblyPollingInfo.IsActive = obj.IsActive;
                    }
                    else
                    {
                        return AsseblyPollingInfo;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return AsseblyPollingInfo;
        }

        public void SaveUpdateUserInfo(UserInfo userInfoModel)
        {
            try
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    db.UserInfos.Add(userInfoModel);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message + " " + ex.InnerException;
            }

        }
        public void UpdateAssemblyPollingStationName(AssemblyPollingStationLookUp objPSData)
        {
            try
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    AssemblyPollingStationLookUp objAssembPollinData = db.AssemblyPollingStationLookUps.Where(a => a.Pscode == objPSData.Pscode).FirstOrDefault();
                    if (objAssembPollinData != null)
                    {
                        objAssembPollinData.Psname = objPSData.Psname;
                        db.Entry(objAssembPollinData).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                //var studentbyid = objContext.tbl_Students.Where(x => x.id == studentid).FirstOrDefault();
                //if (studentbyid != null)
                //{
                //    objContext.Entry(studentbyid).State = EntityState.Deleted;
                //    objContext.SaveChanges();
                //}

            }
            catch (Exception ex)
            {
                string msg = ex.Message + " " + ex.InnerException;
            }

        }

        public void UpdateEmployeeACSettingsData(EmployeeAcSetting objEmpACSettingsData)
        {
            try
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    EmployeeAcSetting modelEmpACSettingsData = db.EmployeeAcSettings
                        .Where(a => a.EmpId == objEmpACSettingsData.EmpId)
                        .OrderByDescending(a => a.ModifiedDate)
                        .FirstOrDefault();
                    if (modelEmpACSettingsData != null)
                    {
                        modelEmpACSettingsData.EmpId = objEmpACSettingsData.EmpId;
                        modelEmpACSettingsData.Pscode = objEmpACSettingsData.Pscode;
                        modelEmpACSettingsData.Psname = objEmpACSettingsData.Psname;
                        modelEmpACSettingsData.VillageCode = objEmpACSettingsData.VillageCode;
                        modelEmpACSettingsData.MandalCode = objEmpACSettingsData.MandalCode;
                        modelEmpACSettingsData.Accode = objEmpACSettingsData.Accode;
                        modelEmpACSettingsData.Pccode = objEmpACSettingsData.Pccode;
                        modelEmpACSettingsData.StateCode = objEmpACSettingsData.StateCode;
                        modelEmpACSettingsData.MeasuringAppCode = objEmpACSettingsData.MeasuringAppCode;
                        modelEmpACSettingsData.MainAppCode = objEmpACSettingsData.MainAppCode;
                        modelEmpACSettingsData.ModifiedBy = objEmpACSettingsData.CreatedBy;
                        modelEmpACSettingsData.ModifiedDate = System.DateTime.Now;

                        db.Entry(modelEmpACSettingsData).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        EmployeeAcSetting objNewEmpACSettingsData = new EmployeeAcSetting();
                        objNewEmpACSettingsData.EmpId = objEmpACSettingsData.EmpId;
                        objNewEmpACSettingsData.Pscode = objEmpACSettingsData.Pscode;
                        objNewEmpACSettingsData.Psname = objEmpACSettingsData.Psname;
                        objNewEmpACSettingsData.VillageCode = objEmpACSettingsData.VillageCode;
                        objNewEmpACSettingsData.MandalCode = objEmpACSettingsData.MandalCode;
                        objNewEmpACSettingsData.Accode = objEmpACSettingsData.Accode;
                        objNewEmpACSettingsData.Pccode = objEmpACSettingsData.Pccode;
                        objNewEmpACSettingsData.StateCode = objEmpACSettingsData.StateCode;
                        objNewEmpACSettingsData.MeasuringAppCode = objEmpACSettingsData.MeasuringAppCode;
                        objNewEmpACSettingsData.MainAppCode = objEmpACSettingsData.MainAppCode;
                        objNewEmpACSettingsData.CreatedBy = objEmpACSettingsData.CreatedBy;
                        objNewEmpACSettingsData.CreatedDate = System.DateTime.Now;
                        objNewEmpACSettingsData.ModifiedBy = objEmpACSettingsData.CreatedBy;
                        objNewEmpACSettingsData.ModifiedDate = System.DateTime.Now;
                        db.EmployeeAcSettings.Add(objNewEmpACSettingsData);
                        db.SaveChanges();
                    }

                }
                using (CloudPATContext db = new CloudPATContext())
                {
                    AssemblyPollingStationLookUp objAssembPollinData = db.AssemblyPollingStationLookUps
                        .Where(a => a.Pscode == objEmpACSettingsData.Pscode).FirstOrDefault();
                    if (objAssembPollinData != null)
                    {
                        objAssembPollinData.Psname = objEmpACSettingsData.Psname;
                        db.Entry(objAssembPollinData).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message + " " + ex.InnerException;
            }

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
