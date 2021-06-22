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
        [ValidateAntiForgeryToken]
        public ActionResult Login(EmployeeInfo employeeInfo)
        {
            if (ModelState.IsValid)
            {
                using (CloudPATContext db = new CloudPATContext())
                {
                    var obj = _db.EmployeeInfos.Where(a => a.EmpUsername.Equals(employeeInfo.EmpUsername) && a.EmpPassword.Equals(employeeInfo.EmpPassword)).FirstOrDefault();
                    if (obj != null)
                    {
                        DataSet dsEmployeeInfo = new DataSet();
                        dsEmployeeInfo = databaseAPI.CheckUserAuthetication(employeeInfo.EmpUsername, employeeInfo.EmpPassword);
                        if (dsEmployeeInfo.Tables[0].Rows[0].ItemArray[0].ToString() == "-1")
                        {
                            return ViewLogin(dsEmployeeInfo);
                        }
                        else
                        {
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
                        return ViewLogin(dsEmployeeInfo);
                    }
                }
            }

            return View("_Login");
        }


        [HttpPost]         
        public IActionResult AuthenticateUser(string username, string password)
        {
            List<EmployeeInfo> list;
            DataSet dsEmployeeInfo = new DataSet();
            dsEmployeeInfo = databaseAPI.CheckUserAuthetication(username, password);
            if(dsEmployeeInfo.Tables[0].Rows[0].ItemArray[0].ToString() == "-1")
            {
                return ViewLogin(dsEmployeeInfo);
            }
            else
            {
                string LaunchingApp = dsEmployeeInfo.Tables[1].Rows[0].ItemArray[2].ToString();
                if (LaunchingApp == "PPAT")
                {
                    return ViewPPAT(dsEmployeeInfo);// View("_PPAT", dsEmployeeInfo);
                }
                else if(LaunchingApp == "PIG")
                {
                    return ViewPPAT(dsEmployeeInfo);  //return View("_PIG", dsEmployeeInfo);
                }
                else if (LaunchingApp == "SS")
                {
                    return ViewPPAT(dsEmployeeInfo);  //return View("_SS", dsEmployeeInfo);
                }
            }
            return ViewLogin(dsEmployeeInfo);
        }

        private ActionResult ViewLogin(DataSet ds)
        {
            return View("_Login");
        }
        private ActionResult ViewPPAT(DataSet ds)
        {
            return RedirectToAction("Index", "PPAT",ds);
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
