using Cloud.PPATSApp.Core;
using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
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

        private EmployeeInfoViewModel LoadEmployeeInfo()
        {
            List<SelectListItem> lstMainApplications = new List<SelectListItem>()
            {
                new SelectListItem {Text="PPAT",Value="PPAT"},
                new SelectListItem {Text="PIG",Value="PIG" },
                new SelectListItem {Text="SS",Value="SS"}
            };
            EmployeeInfoViewModel objEmployeeInfo = new EmployeeInfoViewModel();
            objEmployeeInfo.EmpAssignedApps = lstMainApplications;
            List<SelectListItem> lstRoles = new List<SelectListItem>()
            {
                new SelectListItem {Text="Not assigned",Value="0"},
                new SelectListItem {Text="User",Value="1"  },
                new SelectListItem {Text="Supervisor",Value="2"},
                new SelectListItem {Text="Admin",Value="3"},
                new SelectListItem {Text="Techsupport",Value="4"}
            };
            objEmployeeInfo.Roles = lstRoles;

            return objEmployeeInfo;
        }
        public IActionResult AdminConfig()
        {
            //ViewBag.EmpRoles = new SelectList(lstRoles, "Value", "Text", objEmployeeInfo.EmpRoleId);

            return View("AdminConfig", LoadEmployeeInfo());
            //return View("_EmployeeInfo", objEmployeeInfo);
        }

        public List<EmployeeInfo> GetEmpSearchData(string searchString)
        {
            List<EmployeeInfo> objEmp = new List<EmployeeInfo>();
            objEmp = databaseAPI.GetEmpSearchData(searchString);
            return objEmp;
        }

        public EmployeeInfoViewModel GetEmployeeMasterInfo(int empId)
        {
            EmployeeInfoViewModel objEmployeeInfo = new EmployeeInfoViewModel();
            _ = new DataSet();
            DataSet dsEmployee = databaseAPI.GetEmployeeMasterInfo(Convert.ToInt16(empId));

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
                            objEmployeeInfo.IsActive = row["IsActive"].ToString();
                        }
                    }

                    List<SelectListItem> EmpApps = new List<SelectListItem>();
                    List<String> EmpExistingApps = new List<string>();
                    if (dsEmployee.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in dsEmployee.Tables[1].Rows)
                        {
                            EmpExistingApps.Add(row["AppCode"].ToString());
                            EmpApps.Add(new SelectListItem
                            {
                                Text = row["AppCode"].ToString(),
                                Value = row["AppCode"].ToString(),
                                Selected = true
                            });

                        }
                        objEmployeeInfo.EmpAssignedApps = EmpApps;
                        objEmployeeInfo.EmpApplications = EmpExistingApps;
                    }
                }
            }
            return objEmployeeInfo;
        }
        [HttpPost]
        public ActionResult SaveUpdateEmployeeForm(EmployeeInfoViewModel obj, IFormCollection form) 
        {
            EmployeeInfoViewModel empInfoModel = new EmployeeInfoViewModel();
            empInfoModel.EmpId = Convert.ToInt16(HttpContext.Request.Form["hdnEmpId"].ToString());
            empInfoModel.EmpFirstName = HttpContext.Request.Form["txtempFirstName"].ToString();
            empInfoModel.EmpLastName = HttpContext.Request.Form["txtempLastName"].ToString();
            empInfoModel.EmpAddress = HttpContext.Request.Form["txtempAddress"].ToString();
            empInfoModel.EmpPhone = HttpContext.Request.Form["txtempMobile"].ToString();
            empInfoModel.EmpEmail = HttpContext.Request.Form["txtempEmail"].ToString();
            empInfoModel.EmpUsername = HttpContext.Request.Form["txtempUserName"].ToString();
            empInfoModel.EmpPassword = HttpContext.Request.Form["txtempPassword"].ToString();
            empInfoModel.IsActive = HttpContext.Request.Form["chkActive"].ToString();
            empInfoModel.CreatedBy = "Admin";
            empInfoModel.CreatedDate = System.DateTime.Now;
            empInfoModel.EmpRoleId = Convert.ToInt16(HttpContext.Request.Form["ddlRoles"].ToString());

            List<String> EmpSelectedApps = new List<String>();

            if (HttpContext.Request.Form["chk_PPAT"].ToString() != "") EmpSelectedApps.Add(HttpContext.Request.Form["chk_PPAT"].ToString());
            if (HttpContext.Request.Form["chk_PIG"].ToString() != "") EmpSelectedApps.Add(HttpContext.Request.Form["chk_PIG"].ToString());
            if (HttpContext.Request.Form["chk_SS"].ToString() != "") EmpSelectedApps.Add(HttpContext.Request.Form["chk_SS"].ToString());

            empInfoModel.EmpApplications = EmpSelectedApps;

            databaseAPI.SaveUpdateEmployeeInfo(empInfoModel);

            //AssemblyPollingStationLookUp objPSData = new AssemblyPollingStationLookUp();
            //TryUpdateModelAsync(objPSData);
             
            //ViewBag.Message = "Customer saved successfully!";

            //DataSet dsEmployeeInfo = new DataSet();
            //dsEmployeeInfo = databaseAPI.GetEmployeeInfo(HttpContext.Session.GetString("LoginUserName").ToString(), -1);
            
            return View("_EmployeeInfo", LoadEmployeeInfo());
            //return View("Index", dsEmployeeInfo);
            //return RedirectToAction("Index", "PPAT", dsEmployeeInfo);
        }

    }//class
}//namespace
