using Cloud.PPATSApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Cloud.PPATSApp.Core;
using System.Data.Entity.Repository;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Threading;

namespace Cloud.PPATSApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CloudPATContext _db;
        DataBaseAPI databaseAPI = new DataBaseAPI();
        public HomeController(ILogger<HomeController> logger, CloudPATContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
            DataBaseAPI databaseAPI = new DataBaseAPI(_db);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View("_Login");
        }
        
        [HttpPost]
        public JsonResult LongRunningDemoProcess(EmployeeInfoViewModel employeeInfo)
        {
            Thread.Sleep(1000);
            return Json(employeeInfo, "json");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(EmployeeInfoViewModel employeeInfo)
        {
            Thread.Sleep(1000);
            if (ModelState.IsValid)
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    DataSet dsEmployeeInfo = new DataSet();
                    var obj = _db.EmployeeInfos.Where(a => a.EmpUsername.Equals(employeeInfo.EmpUsername) && a.EmpPassword.Equals(employeeInfo.EmpPassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        dsEmployeeInfo = databaseAPI.CheckUserAuthetication(employeeInfo.EmpUsername, employeeInfo.EmpPassword);
                        if (dsEmployeeInfo.Tables[0].Rows[0].ItemArray[0].ToString() == "-1")
                        {
                            ViewBag.LoginMessage = "You are not authorized user. Please contact your admin";
                            return ViewLogin(dsEmployeeInfo);
                        }
                        else
                        {
                            HttpContext.Session.SetString("LoginUserName", employeeInfo.EmpUsername);
                            HttpContext.Session.SetString("LoginUserDisplayName", dsEmployeeInfo.Tables[0].Rows[0].ItemArray[1].ToString() + " " + dsEmployeeInfo.Tables[0].Rows[0].ItemArray[2].ToString());
                            HttpContext.Session.SetString("LoginEmpId", dsEmployeeInfo.Tables[0].Rows[0].ItemArray[0].ToString());

                            if (dsEmployeeInfo.Tables[1].Rows.Count == 0)
                            {
                                ViewBag.LoginMessage = "You are not assinged with any applications. Please contact your admin";
                                return ViewLogin(dsEmployeeInfo);
                            }
                            else
                            {
                                //FormsAuthentication.SetAuthCookie(employeeInfo.EmpUsername, employeeInfo.EmpPassword);
                                //Access code should be here
                                Authorization.setCurrentUserInfo(dsEmployeeInfo);

                                string LaunchingApp = dsEmployeeInfo.Tables[1].Rows[0].ItemArray[2].ToString();
                                if (LaunchingApp == "PPAT")
                                {
                                    return ViewPPAT(dsEmployeeInfo);// View("_PPAT", dsEmployeeInfo);
                                }
                                else if (LaunchingApp == "PIG")
                                {
                                    return ViewPPAT(dsEmployeeInfo);  //return View("_PIG", dsEmployeeInfo);
                                }
                                else if (LaunchingApp == "SS")
                                {
                                    return ViewPPAT(dsEmployeeInfo);  //return View("_SS", dsEmployeeInfo);
                                }
                            }
                        }
                        return ViewLogin(dsEmployeeInfo);
                    }
                    else
                    {
                        ViewBag.LoginMessage = "You are not authorized user. Please contact your admin";
                        return ViewLogin(dsEmployeeInfo);
                    }
                }
            }

            return View("_Login");
        }

        private void setCurrentUserInfo1(DataSet dsEmpInfo)
        { 
            Authorization.CurrentUser.EmpId = Convert.ToInt16(dsEmpInfo.Tables[0].Rows[0]["EmpId"].ToString());
            Authorization.CurrentUser.EmpFirstName = dsEmpInfo.Tables[0].Rows[0]["EmpFirstName"].ToString();
            Authorization.CurrentUser.EmpLastName = dsEmpInfo.Tables[0].Rows[0]["EmpLastName"].ToString();
            Authorization.CurrentUser.EmpAddress = dsEmpInfo.Tables[0].Rows[0]["EmpAddress"].ToString();
            Authorization.CurrentUser.EmpPhone = dsEmpInfo.Tables[0].Rows[0]["EmpPhone"].ToString();
            Authorization.CurrentUser.EmpEmail = dsEmpInfo.Tables[0].Rows[0]["EmpEmail"].ToString();
            Authorization.CurrentUser.EmpUsername = dsEmpInfo.Tables[0].Rows[0]["EmpUsername"].ToString();
            Authorization.CurrentUser.EmpPassword = dsEmpInfo.Tables[0].Rows[0]["EmpPassword"].ToString();
            Authorization.CurrentUser.IsActive = dsEmpInfo.Tables[0].Rows[0]["IsActive"].ToString();
            Authorization.CurrentUser.EmpRoleId = Convert.ToInt16(dsEmpInfo.Tables[0].Rows[0]["RoleId"].ToString());
            Authorization.CurrentUser.EmpRoleName = dsEmpInfo.Tables[0].Rows[0]["RoleName"].ToString();

            List<String> EmpAssignedApps = new List<String>();

            foreach(DataRow dr in dsEmpInfo.Tables[1].Rows)
            {
                EmpAssignedApps.Add(dr["AppCode"].ToString());
            }
            Authorization.CurrentUser.EmpApplications = EmpAssignedApps;

        }
        //[HttpPost]
        //public IActionResult AuthenticateUser(string username, string password)
        //{
        //    List<EmployeeInfo> list;
        //    DataSet dsEmployeeInfo = new DataSet();
        //    dsEmployeeInfo = databaseAPI.CheckUserAuthetication(username, password);
        //    if (dsEmployeeInfo.Tables[0].Rows[0].ItemArray[0].ToString() == "-1")
        //    {
        //        return ViewLogin(dsEmployeeInfo);
        //    }
        //    else
        //    {
        //        string LaunchingApp = dsEmployeeInfo.Tables[1].Rows[0].ItemArray[2].ToString();
        //        if (LaunchingApp == "PPAT")
        //        {
        //            return ViewPPAT(dsEmployeeInfo);// View("_PPAT", dsEmployeeInfo);
        //        }
        //        else if (LaunchingApp == "PIG")
        //        {
        //            return ViewPPAT(dsEmployeeInfo);  //return View("_PIG", dsEmployeeInfo);
        //        }
        //        else if (LaunchingApp == "SS")
        //        {
        //            return ViewPPAT(dsEmployeeInfo);  //return View("_SS", dsEmployeeInfo);
        //        }
        //    }
        //    return ViewLogin(dsEmployeeInfo);
        //}

        private ActionResult ViewLogin(DataSet ds)
        {
            return View("_Login");
        }
        private ActionResult ViewPPAT(DataSet ds)
        {
            return RedirectToAction("Index", "PPAT", ds);
        }
        private ActionResult ViewPIG(DataSet ds)
        {
            return View("_PIG", ds);
        }
        private ActionResult ViewSS(DataSet ds)
        {
            return View("_SS", ds);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
