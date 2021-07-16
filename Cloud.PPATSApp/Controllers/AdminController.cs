using ClosedXML.Excel;
using Cloud.PPATSApp.Core;
using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


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
            ViewBag.ddlMainApps = lstMainApplications;

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

        //public ActionResult ExportUserDataToExcel(string id)
        //{
        //    DataTable dt = new DataTable();

        //    DataTable dataTable = new DataTable();
        //    List<EmployeeInfo> objEmp = new List<EmployeeInfo>();
        //    DataSet dsEmp = new DataSet();
        //    try
        //    {
        //        // Define the query to be performed to export desired data
        //        //SqlCommand command = new SqlCommand("select * from Partners", connection);

        //        //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        //        CloudPATContext dbContext = new CloudPATContext();
        //        //SqlParameter searchStringParam = new SqlParameter("@searchString", searchString);
        //        var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
        //        using (var con = new SqlConnection(dbConnection))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("prcExportUserDataToExcel", con))
        //            {
        //                using (var da = new SqlDataAdapter(cmd))
        //                {
        //                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //                    //cmd.Parameters.Add(searchStringParam);
        //                    da.Fill(dataTable);
        //                }
        //            }
        //        }

        //        //dataAdapter.Fill(dataTable);

        //        var excelApplication = new Excel.Application();
        //        var excelWorkBook = excelApplication.Application.Workbooks.Add(Type.Missing);
        //        DataColumnCollection dataColumnCollection = dataTable.Columns;
        //        for (int i = 1; i <= dataTable.Rows.Count + 1; i++)
        //        {
        //            for (int j = 1; j <= dataTable.Columns.Count; j++)
        //            {
        //                if (i == 1)
        //                    excelApplication.Cells[i, j] = dataColumnCollection[j - 1].ToString();
        //                else
        //                    excelApplication.Cells[i, j] = dataTable.Rows[i - 2][j - 1].ToString();
        //            }
        //        }

        //        // Save the excel file at specified location
        //        excelApplication.ActiveWorkbook.SaveCopyAs(@"C:\Users\Satish Kumar\Desktop\BKP\test.xlsx");
        //        excelApplication.ActiveWorkbook.Saved = true;
        //        // Close the Excel Application
        //        excelApplication.Quit();

        //        //Release or clear the COM object
        //        //releaseObject(excelWorkBook);
        //        //releaseObject(excelApplication);
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = ex.Message;
        //    }
        //    dt = databaseAPI.ExportDataFromSQLServer();
        //    return View("_EmployeeInfo", LoadEmployeeInfo());
        //}

        public IActionResult DownloadExcelDocument(string id)
        {

            //databaseAPI.DownloadExcelDocument(id);
            DataTable dataTable = new DataTable();
            List<UserInfoViewModel> lstUsers = new List<UserInfoViewModel>();
            DataSet dsEmp = new DataSet();
            CloudPATContext dbContext = new CloudPATContext();
            var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
            //using (var con = new SqlConnection(dbConnection))
            //{
            //    using (SqlCommand cmd = new SqlCommand("prcExportUserDataToExcel", con))
            //    {
            //        using (var da = new SqlDataAdapter(cmd))
            //        {
            //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //            //cmd.Parameters.Add(searchStringParam);
            //            da.Fill(dataTable);
            //        }
            //    }
            //}

            //SqlParameter searchStringParam = new SqlParameter("@searchString", searchString);
            //var dbConnection = dbContext.Database.GetDbConnection().ConnectionString;
            using (var con = new SqlConnection(dbConnection))
            {
                using (SqlCommand cmd = new SqlCommand("prcExportUserDataToExcel", con))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        //cmd.Parameters.Add(searchStringParam);
                        da.Fill(dsEmp);
                    }
                }
            }

            lstUsers = CommonExtensions.CreateListFromTable<UserInfoViewModel>(dsEmp.Tables[0]);

            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "UserData.xlsx";
            try
            {
                using (var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet =
                    workbook.Worksheets.Add("Authors");
                    worksheet.Cell(1, 1).Value = "UserDisplayName";
                    worksheet.Cell(1, 2).Value = "Gender";
                    worksheet.Cell(1, 3).Value = "UserAge";
                    worksheet.Cell(1, 4).Value = "Occupation";
                    worksheet.Cell(1, 5).Value = "EducationCode";
                    worksheet.Cell(1, 6).Value = "CommunityCode";
                    worksheet.Cell(1, 7).Value = "SubCasteCode";
                    worksheet.Cell(1, 8).Value = "IFCode";
                    worksheet.Cell(1, 9).Value = "SFCode";
                    worksheet.Cell(1, 10).Value = "PRFCode";
                    worksheet.Cell(1, 11).Value = "VPFCode";
                    worksheet.Cell(1, 12).Value = "PIFCode";
                    worksheet.Cell(1, 13).Value = "Remarks";
                    worksheet.Cell(1, 14).Value = "MeasureAppCode";
                    worksheet.Cell(1, 15).Value = "PCCode";
                    worksheet.Cell(1, 16).Value = "PCName";
                    worksheet.Cell(1, 17).Value = "ACCode";
                    worksheet.Cell(1, 18).Value = "ACName";
                    worksheet.Cell(1, 19).Value = "PSCode";
                    worksheet.Cell(1, 20).Value = "PSName";
                    worksheet.Cell(1, 21).Value = "CreatedBy";
                    worksheet.Cell(1, 22).Value = "CreatedDate";

                    for (int index = 1; index <= lstUsers.Count; index++)
                    {
                        worksheet.Cell(index + 1, 1).Value = lstUsers[index - 1].UserDisplayName;
                        worksheet.Cell(index + 1, 2).Value = lstUsers[index - 1].Gender;
                        worksheet.Cell(index + 1, 3).Value = lstUsers[index - 1].UserAge;
                        worksheet.Cell(index + 1, 4).Value = lstUsers[index - 1].Occupation;
                        worksheet.Cell(index + 1, 5).Value = lstUsers[index - 1].EducationCode;
                        worksheet.Cell(index + 1, 6).Value = lstUsers[index - 1].CommunityCode;
                        worksheet.Cell(index + 1, 7).Value = lstUsers[index - 1].SubCasteCode;
                        worksheet.Cell(index + 1, 8).Value = lstUsers[index - 1].IFCode;
                        worksheet.Cell(index + 1, 9).Value = lstUsers[index - 1].SFCode;
                        worksheet.Cell(index + 1, 10).Value = lstUsers[index - 1].PRFCode;
                        worksheet.Cell(index + 1, 11).Value = lstUsers[index - 1].VPFCode;
                        worksheet.Cell(index + 1, 12).Value = lstUsers[index - 1].PIFCode;
                        worksheet.Cell(index + 1, 13).Value = lstUsers[index - 1].Remarks;
                        worksheet.Cell(index + 1, 14).Value = lstUsers[index - 1].MeasureAppCode;
                        worksheet.Cell(index + 1, 15).Value = lstUsers[index - 1].PCCode;
                        worksheet.Cell(index + 1, 16).Value = lstUsers[index - 1].PCName;
                        worksheet.Cell(index + 1, 17).Value = lstUsers[index - 1].ACCode;
                        worksheet.Cell(index + 1, 18).Value = lstUsers[index - 1].ACName;
                        worksheet.Cell(index + 1, 19).Value = lstUsers[index - 1].PSCode;
                        worksheet.Cell(index + 1, 20).Value = lstUsers[index - 1].PSName;
                        worksheet.Cell(index + 1, 21).Value = lstUsers[index - 1].CreatedBy;
                        worksheet.Cell(index + 1, 22).Value = lstUsers[index - 1].CreatedDate;
                    }
                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }
            catch (Exception ex)
            {
                //return Error();
            }
            return View("_EmployeeInfo", LoadEmployeeInfo());
        }

    }//classs

    
}//namespace
