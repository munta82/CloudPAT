using Cloud.PPATSApp.Core;
using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Cloud.PPATSApp.Controllers
{
    public class AdminController : Controller
    {
        DataBaseAPI databaseAPI = new DataBaseAPI();
        //EmployeeInfoViewModel objEmployeeInfo = new EmployeeInfoViewModel();
        public IActionResult Index()
        {
            //GetAdminEmpInfo();
            return View();
        }
        //private void GetAdminEmpInfo()
        //{
        //    List<SelectListItem> lstMainApplications = new List<SelectListItem>()
        //    {
        //        new SelectListItem {Text="PPAT",Value="PPAT",Selected=true },
        //        new SelectListItem {Text="PIG",Value="PIG" },
        //        new SelectListItem {Text="SS",Value="SS"}
        //    };

            

        //    //TempData.Put("applications", lstMainApplications);


        //    EmployeeInfoViewModel objEmployeeInfo = new EmployeeInfoViewModel();
        //    DataSet dsEmployee = new DataSet();
        //    dsEmployee = databaseAPI.GetEmployeeMasterInfo(Convert.ToInt16(1));

        //    if (dsEmployee != null)
        //    {
        //        if (dsEmployee.Tables.Count > 0)
        //        {
        //            if (dsEmployee.Tables[0].Rows.Count > 0)
        //            {
        //                foreach (DataRow row in dsEmployee.Tables[0].Rows)
        //                {
        //                    objEmployeeInfo.EmpId = Convert.ToInt16(row["EmpId"]);
        //                    objEmployeeInfo.EmpFirstName = row["EmpFirstName"].ToString();
        //                    objEmployeeInfo.EmpLastName = row["EmpLastName"].ToString();
        //                    objEmployeeInfo.EmpPhone = row["EmpPhone"].ToString();
        //                    objEmployeeInfo.EmpEmail = row["EmpEmail"].ToString();
        //                    objEmployeeInfo.EmpAddress = row["EmpAddress"].ToString();
        //                    objEmployeeInfo.EmpUsername = row["EmpUsername"].ToString();
        //                    objEmployeeInfo.EmpPassword = row["EmpPassword"].ToString();
        //                    objEmployeeInfo.EmpRoleId = Convert.ToInt16(row["RoleId"].ToString());
        //                    objEmployeeInfo.EmpRoleName = row["RoleName"].ToString();
        //                }
        //            }

        //            List<SelectListItem> EmpApps = new List<SelectListItem>();

        //            if (dsEmployee.Tables[1].Rows.Count > 0)
        //            {
        //                foreach (DataRow row in dsEmployee.Tables[1].Rows)
        //                {
        //                    EmpApps.Add(new SelectListItem
        //                    {
        //                        Text = row["AppCode"].ToString(),
        //                        Value = row["AppCode"].ToString(),
        //                        Selected = true
        //                    });

        //                }
        //                objEmployeeInfo.EmpAssignedApps = EmpApps;
        //            }
        //        }
        //    }

           
        //    List<SelectListItem> lstRoles = new List<SelectListItem>()
        //    {
        //        new SelectListItem {Text="Not assigned",Value="0"},
        //        new SelectListItem {Text="User",Value="1"  },
        //        new SelectListItem {Text="Supervisor",Value="2"},
        //        new SelectListItem {Text="Admin",Value="3"},
        //        new SelectListItem {Text="Techsupport",Value="4"}
        //    };
        //    //objEmployeeInfo.Roles = new SelectList(lstRoles, "Value", "Text", objEmployeeInfo.EmpRoleId);
        //    objEmployeeInfo.Roles = lstRoles;
        //    ViewBag.EmpRoles = new SelectList(lstRoles, "Value", "Text", objEmployeeInfo.EmpRoleId);

        //    //TempData["applications"] = JsonConvert.SerializeObject(lstMainApplications); ;
        //    //TempData["Roles"] = JsonConvert.SerializeObject(lstRoles);

        //    //TempData["applications"] = lstMainApplications; ;
        //    //TempData["Roles"] = lstRoles;

        //    //TempDataExtensions.Put<EmployeeInfoViewModel>(TempData, "empInfo", objEmployeeInfo);

        //    //return View("_EmployeeInfo", objEmployeeInfo);
        //    //return View("AdminConfig", objEmployeeInfo);
        //}
        public IActionResult AdminConfig()
        {
            List<SelectListItem> lstMainApplications = new List<SelectListItem>()
            {
                new SelectListItem {Text="PPAT",Value="PPAT",Selected=true },
                new SelectListItem {Text="PIG",Value="PIG" },
                new SelectListItem {Text="SS",Value="SS"}
            };

            //TempData.Put("applications", lstMainApplications);
            EmployeeInfoViewModel objEmployeeInfo = new EmployeeInfoViewModel();
            DataSet dsEmployee = new DataSet();
            dsEmployee = databaseAPI.GetEmployeeMasterInfo(Convert.ToInt16(1));

            if (dsEmployee != null)
            {
                if (dsEmployee.Tables.Count > 0)
                {
                    if (dsEmployee.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsEmployee.Tables[0].Rows)
                        {
                            objEmployeeInfo.EmpId = Convert.ToInt16(row["EmpId"]);
                            objEmployeeInfo.EmpFirstName = row["EmpFirstName"].ToString();
                            objEmployeeInfo.EmpLastName = row["EmpLastName"].ToString();
                            objEmployeeInfo.EmpPhone = row["EmpPhone"].ToString();
                            objEmployeeInfo.EmpEmail = row["EmpEmail"].ToString();
                            objEmployeeInfo.EmpAddress = row["EmpAddress"].ToString();
                            objEmployeeInfo.EmpUsername = row["EmpUsername"].ToString();
                            objEmployeeInfo.EmpPassword = row["EmpPassword"].ToString();
                            objEmployeeInfo.EmpRoleId = Convert.ToInt16(row["RoleId"].ToString());
                            objEmployeeInfo.EmpRoleName = row["RoleName"].ToString();
                        }
                    }

                    List<SelectListItem> EmpApps = new List<SelectListItem>();

                    if (dsEmployee.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsEmployee.Tables[1].Rows)
                        {
                            EmpApps.Add(new SelectListItem
                            {
                                Text = row["AppCode"].ToString(),
                                Value = row["AppCode"].ToString(),
                                Selected = true
                            });

                        }
                        //objEmployeeInfo.EmpAssignedApps = EmpApps;
                    }
                }
            }

            objEmployeeInfo.EmpAssignedApps = lstMainApplications;
            List<SelectListItem> lstRoles = new List<SelectListItem>()
            {
                new SelectListItem {Text="Not assigned",Value="0"},
                new SelectListItem {Text="User",Value="1"  },
                new SelectListItem {Text="Supervisor",Value="2"},
                new SelectListItem {Text="Admin",Value="3"},
                new SelectListItem {Text="Techsupport",Value="4"}
            };
            //objEmployeeInfo.Roles = new SelectList(lstRoles, "Value", "Text", objEmployeeInfo.EmpRoleId);
            objEmployeeInfo.Roles = lstRoles;
            ViewBag.EmpRoles = new SelectList(lstRoles, "Value", "Text", objEmployeeInfo.EmpRoleId);

            return View("AdminConfig",objEmployeeInfo);
            //return View("_EmployeeInfo", objEmployeeInfo);
        }
    }
}
