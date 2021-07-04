using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Core
{
    
    public static class Authorization
    {
        private static EmployeeInfoViewModel _CurrentUser;
        static DataBaseAPI databaseAPI = new DataBaseAPI();

        static Authorization()
        {
            _CurrentUser = new EmployeeInfoViewModel();
        }

        public static EmployeeInfoViewModel CurrentUser
        {
            get
            {
                return _CurrentUser;
            }
        }

        public static void setCurrentUserInfo(DataSet dsEmpInfo)
        {
            EmployeeInfoViewModel CurrentUser = new EmployeeInfoViewModel();
            Authorization.CurrentUser.EmpId = Convert.ToInt16(dsEmpInfo.Tables[0].Rows[0]["EmpId"].ToString());
            Authorization.CurrentUser.EmpFirstName = dsEmpInfo.Tables[0].Rows[0]["EmpFirstName"].ToString();
            Authorization._CurrentUser.EmpLastName = dsEmpInfo.Tables[0].Rows[0]["EmpLastName"].ToString();
            Authorization._CurrentUser.EmpAddress = dsEmpInfo.Tables[0].Rows[0]["EmpAddress"].ToString();
            Authorization._CurrentUser.EmpPhone = dsEmpInfo.Tables[0].Rows[0]["EmpPhone"].ToString();
            Authorization._CurrentUser.EmpEmail = dsEmpInfo.Tables[0].Rows[0]["EmpEmail"].ToString();
            Authorization._CurrentUser.EmpUsername = dsEmpInfo.Tables[0].Rows[0]["EmpUsername"].ToString();
            Authorization._CurrentUser.EmpPassword = dsEmpInfo.Tables[0].Rows[0]["EmpPassword"].ToString();
            Authorization._CurrentUser.IsActive = dsEmpInfo.Tables[0].Rows[0]["IsActive"].ToString();
            Authorization._CurrentUser.EmpRoleId = Convert.ToInt16(dsEmpInfo.Tables[0].Rows[0]["RoleId"].ToString());
            Authorization._CurrentUser.EmpRoleName = dsEmpInfo.Tables[0].Rows[0]["RoleName"].ToString();

            List<String> EmpAssignedApps = new List<String>();

            foreach (DataRow dr in dsEmpInfo.Tables[1].Rows)
            {
                EmpAssignedApps.Add(dr["AppCode"].ToString());
            }
            Authorization._CurrentUser.EmpApplications = EmpAssignedApps;

        }
        //public static Authorization Current
        //{
        //    get
        //    {
        //        Authorization _Current = Microsoft.AspNetCore.Http.HttpContext.Current
        //    }
        //}

        public static bool HasAccessToPage(ApplicationPages pageName)
        {
            
            bool retHasAccess = false;
            switch(pageName)
            {
                case ApplicationPages.AdminSettings:
                    if(Authorization.CurrentUser.EmpRoleName == RoleName.Admin.ToString())
                    {
                        retHasAccess = true;
                    }
                    break;
                case ApplicationPages.PPAT:
                    if (Authorization.CurrentUser.EmpRoleName == RoleName.User.ToString())
                    {
                        retHasAccess = true;
                    }
                    break;
            }

            return retHasAccess;
        }

    }

    public static class HttpContext
    {
        private static IHttpContextAccessor _contextAccessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;

        internal static void Configure(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }

    public static class StaticHttpContextExtensions
    {
        public static void AddHttpContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public static IApplicationBuilder UseStaticHttpContext(this IApplicationBuilder app)
        {
            var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            //System.Web.HttpContext.Configure(httpContextAccessor);
            return app;
        }
    }
}
