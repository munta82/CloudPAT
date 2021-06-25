using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Controllers
{
    public class AdminControler : Controller
    {
        DataBaseAPI databaseAPI = new DataBaseAPI();
        public IActionResult c()
        {
            return View();
        }
        public IActionResult AdminConfig()
        {
            List<SelectListItem> lstMainApplications = new List<SelectListItem>()
            {
                new SelectListItem {Text="PPAT",Value="PPAT",Selected=true },
                new SelectListItem {Text="PIG",Value="PIG" },
                new SelectListItem {Text="SS",Value="SS"}
            };

            List<SelectListItem> lstRoles = new List<SelectListItem>()
            {
                new SelectListItem {Text="Not assigned",Value="0"},
                new SelectListItem {Text="User",Value="1",Selected=true  },
                new SelectListItem {Text="Supervisor",Value="2"},
                new SelectListItem {Text="Admin",Value="3"},
                new SelectListItem {Text="Techsupport",Value="4"}

            };

            string[] applications;
            ViewBag.applications = lstMainApplications;
            ViewBag.Roles = lstRoles;

            EmployeeInfoViewModel objEmployeeInfo = new EmployeeInfoViewModel();
            DataSet dsEmployee = new DataSet();
            dsEmployee = databaseAPI.GetEmployeeMasterInfo(Convert.ToInt16(1));

            //return View("_EmployeeInfo", objEmployeeInfo);
            //return View("AdminConfig", objEmployeeInfo);
            return View();
        }
    }
}
