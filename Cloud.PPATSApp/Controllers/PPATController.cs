using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
using Cloud.PPATSApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Controllers
{
    public class PPATController : Controller
    {
        private readonly CloudPATContext _dbContext;
        DataBaseAPI databaseAPI = new DataBaseAPI();
        public PPATController(CloudPATContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(DataSet dsEmployeeInfo)
        {
            DataSet dsPPAT = new DataSet();
            dsPPAT = databaseAPI.GetPPATMasterInfo("PPAT");
            //IEnumerable<MeasuringApplicationMapping> PPATMeasuringApp =

            //ViewBag.ddlMeasuringApp = new SelectList(dsPPAT.Tables[0].AsDataView(), "MeasureAppMapId", "MeasureAppCode");            

            EmployeeAcSetting objEmpACSettingsData = new EmployeeAcSetting();
            objEmpACSettingsData = databaseAPI.GetEmployeeACSettings(Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString()), "PPAT");
            if (objEmpACSettingsData != null)
            {
                ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppCode", "MeasureAppCode", objEmpACSettingsData.MeasuringAppCode);
                ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName", objEmpACSettingsData.StateCode);
                ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName", objEmpACSettingsData.Pccode);
                ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName", objEmpACSettingsData.Accode);
                ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName", objEmpACSettingsData.MandalCode);
                ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName", objEmpACSettingsData.VillageCode);
                ViewBag.PSCode = objEmpACSettingsData.Pscode;
                ViewBag.PSName = objEmpACSettingsData.Psname;
            }
            else
            {
                ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
                ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
                ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
                ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
                ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
                ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");
                ViewBag.PSCode = "";
                ViewBag.PSName = "";
            }

            //ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
            //ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
            //ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
            //ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
            //ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
            //ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");


            ViewBag.ddlEducation = ToSelectList(dsPPAT.Tables[6], "EducationCode", "EducationName");
            ViewBag.ddlCommunity = ToSelectList(dsPPAT.Tables[7], "CommunityCode", "CommunityName");
            ViewBag.ddlIFParty = ToSelectList(dsPPAT.Tables[8], "IFCode", "IFName");
            ViewBag.ddlPPAT_SF = ToSelectList(dsPPAT.Tables[9], "PPAT_SFCode", "PPAT_SFName");
            ViewBag.ddlPPAT_PRF = ToSelectList(dsPPAT.Tables[10], "PPAT_PRFCode", "PPAT_PRFName");
            ViewBag.ddlPPAT_VPF = ToSelectList(dsPPAT.Tables[11], "PPAT_VPFCode", "PPAT_VPFName");
            ViewBag.ddlPPAT_PIF = ToSelectList(dsPPAT.Tables[12], "PPAT_PIFCode", "PPAT_PIFName");

            ViewBag.ddlPPAT_EBF = ToSelectList(dsPPAT.Tables[14], "PPAT_EBFCode", "PPAT_EBFName");
            ViewBag.ddlPPAT_LLRF = ToSelectList(dsPPAT.Tables[15], "PPAT_LLRFCode", "PPAT_LLRFName");
            ViewBag.ddlPPAT_Grading = ToSelectList(dsPPAT.Tables[16], "PPAT_GrdingCode", "PPAT_GradingName");
            ViewBag.ddlPPAT_SIF = ToSelectList(dsPPAT.Tables[17], "PPAT_SIFCode", "PPAT_SIFName");

            List<SelectListItem> ddlGender = new List<SelectListItem>()
            {
                new SelectListItem {Text="M",Value="M",Selected=true },
                new SelectListItem {Text="F",Value="F" },
                new SelectListItem {Text="OTH",Value="OTH"}
            };
            ViewBag.ddlGender = ddlGender;
            return View("_PPAT");
            //return View("_PPATForm");
        }
        public AssemblyPollingStationLookUp GetPPATPollingStationData(string PSCode)
        {
            AssemblyPollingStationLookUp AsseblyPollingInfo = new AssemblyPollingStationLookUp();
            return databaseAPI.GetPPATPollingStationData(PSCode);
        }

        public List<SubCasteLookUp> GetPPATSubCasteData(string searchString, string communityCode)
        {
            List<SubCasteLookUp> listSubCaste = new List<SubCasteLookUp>();
            listSubCaste = databaseAPI.GetPPATSubCasteData(searchString, communityCode);
            return listSubCaste;
        }


        [HttpPost]
        public ActionResult SaveForm(PPATViewModel obj, IFormCollection form)//, IFormCollection form
        {
            DataSet dsEmployeeInfo = new DataSet();
            try
            {
                UserInfo userInfoModel = new UserInfo();
                userInfoModel.UserDisplayName = HttpContext.Request.Form["txtUserDisplayName"].ToString();
                userInfoModel.UserAge = Convert.ToInt16(HttpContext.Request.Form["txtUserAge"]);
                userInfoModel.Gender = HttpContext.Request.Form["ddlGender"].ToString();
                userInfoModel.UserMobile = HttpContext.Request.Form["txtMobile"].ToString();
                userInfoModel.Occupation = HttpContext.Request.Form["txtOccupation"].ToString();
                userInfoModel.EducationCode = HttpContext.Request.Form["ddlEducation"].ToString();
                userInfoModel.CommunityCode = HttpContext.Request.Form["ddlCommunity"].ToString();
                userInfoModel.SubCasteCode = HttpContext.Request.Form["txtSubCaste"].ToString();
                userInfoModel.Ifcode = HttpContext.Request.Form["ddlIFParty"].ToString();
                userInfoModel.Sfcode = HttpContext.Request.Form["ddlPPAT_SF"].ToString();
                userInfoModel.Prfcode = HttpContext.Request.Form["ddlPPAT_PRF"].ToString();
                userInfoModel.Vpfcode = HttpContext.Request.Form["ddlPPAT_VPF"].ToString();
                userInfoModel.Pifcode = HttpContext.Request.Form["ddlPPAT_PIF"].ToString();

                userInfoModel.Ebfcode = HttpContext.Request.Form["ddlPPAT_EBF"].ToString();
                userInfoModel.Llrfcode = HttpContext.Request.Form["ddlPPAT_LLRF"].ToString();
                userInfoModel.GradingCode = HttpContext.Request.Form["ddlPPAT_Grading"].ToString();
                userInfoModel.Sifcode = HttpContext.Request.Form["ddlPPAT_SIF"].ToString();

                userInfoModel.Remarks = HttpContext.Request.Form["txtRemarks"].ToString();
                userInfoModel.StateCode = HttpContext.Request.Form["ddlStates"].ToString();
                userInfoModel.Pccode = HttpContext.Request.Form["ddlParliament"].ToString();
                userInfoModel.Accode = HttpContext.Request.Form["ddlAssembly"].ToString();
                userInfoModel.MandalCode = HttpContext.Request.Form["ddlMandal"].ToString();
                userInfoModel.VillageCode = HttpContext.Request.Form["ddlVillage"].ToString();
                userInfoModel.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
                userInfoModel.MeasureAppCode = HttpContext.Request.Form["hdnMeasuringApp"].ToString();
                //HttpContext.Request.Form["ddlMeasuringApp"].ToString();
                userInfoModel.AppCode = "PPAT";
                userInfoModel.CreatedBy = HttpContext.Session.GetString("LoginUserDisplayName").ToString();
                userInfoModel.CreatedDate = System.DateTime.Now;

                databaseAPI.SaveUpdateUserInfo(userInfoModel);

                AssemblyPollingStationLookUp objPSData = new AssemblyPollingStationLookUp();
                TryUpdateModelAsync(objPSData);
                objPSData.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
                objPSData.Psname = HttpContext.Request.Form["txtPSName"].ToString();
                databaseAPI.UpdateAssemblyPollingStationName(objPSData);

                //ViewBag.dbMessage = "Record " + userInfoModel.UserDisplayName + " saved successfully!";
                TempData["dbMessage"] = "Record " + userInfoModel.UserDisplayName + " saved successfully!";

                dsEmployeeInfo = databaseAPI.GetEmployeeInfo(HttpContext.Session.GetString("LoginUserName").ToString(), -1);
            }
            catch (Exception ex)
            {
                ViewBag.dbMessage = ex.Message;
            }
            //return View("Index", dsEmployeeInfo);
            return RedirectToAction("Index", "PPAT", dsEmployeeInfo);
        }

        [HttpPost]
        public ActionResult ClearForm(PPATViewModel obj)
        {
            ViewBag.Message = "The operation was cancelled!";
            return View("PPAT", obj);
        }

        [HttpPost]
        public ActionResult PreviewForm(PPATViewModel obj)
        {
            ViewBag.Message = "The operation was cancelled!";
            return View("PPAT", obj);
        }

        public List<MeasuringApplicationMapping> GetMeasuringApplicationMappings(string MainAppCode)
        {
            List<MeasuringApplicationMapping> lstMeasureAppMappings = new List<MeasuringApplicationMapping>();
            lstMeasureAppMappings = databaseAPI.GetMeasuringApplicationMappings(MainAppCode);
            return lstMeasureAppMappings;
        }

        [HttpGet]
        public IActionResult ConstituencySettings(IFormCollection form)
        {
            List<ApplicationLookUp> lstApplicationLookUp = new List<ApplicationLookUp>();
            lstApplicationLookUp = databaseAPI.GetMainApplications();
            List<SelectListItem> ddlMainApps = new List<SelectListItem>();

            //var measureApp = HttpContext.Request.Form["ddlMeasuringApp"].ToString();
            //var mainApp = HttpContext.Request.Form["ddlMainApps"].ToString();

            DataSet dsPPAT = new DataSet();


            EmployeeAcSetting objEmpACSettingsData = new EmployeeAcSetting();
            objEmpACSettingsData = databaseAPI.GetEmployeeACSettings(Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString()));
            if (objEmpACSettingsData != null)
            {
                switch (objEmpACSettingsData.MainAppCode)
                {
                    case "PPAT":
                        dsPPAT = databaseAPI.GetPPATMasterInfo("PPAT");
                        break;
                    case "PIG":
                        dsPPAT = databaseAPI.GetPIGMasterInfo("PIG");
                        break;
                    case "SS":
                        dsPPAT = databaseAPI.GetSSMasterInfo("SS");
                        break;
                }

                foreach (var item in lstApplicationLookUp)
                {
                    if (item.AppCode == objEmpACSettingsData.MainAppCode)
                        ddlMainApps.Add(new SelectListItem { Text = item.AppCode, Value = item.AppCode, Selected = true });
                    else
                        ddlMainApps.Add(new SelectListItem { Text = item.AppCode, Value = item.AppCode });
                }
                ViewBag.ddlMainApps = ddlMainApps;
                //ViewBag.ddlMainApps = ToSelectList(dsPPAT.Tables[13], "AppCode", "AppCode", objEmpACSettingsData.MainAppCode);
                ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppCode", "MeasureAppCode", objEmpACSettingsData.MeasuringAppCode);
                ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName", objEmpACSettingsData.StateCode);
                ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName", objEmpACSettingsData.Pccode);
                ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName", objEmpACSettingsData.Accode);
                ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName", objEmpACSettingsData.MandalCode);
                ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName", objEmpACSettingsData.VillageCode);
                ViewBag.PSCode = objEmpACSettingsData.Pscode;
                ViewBag.PSName = objEmpACSettingsData.Psname;
            }
            else
            {
                List<EmployeeAppAccess> lstEmpAppAccess = new List<EmployeeAppAccess>();
                lstEmpAppAccess = databaseAPI.GetEmpApplicationAccessInfo(Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString()));
                if (lstEmpAppAccess.Count > 0)
                {
                    string mainAppCode = lstEmpAppAccess[0].AppCode;
                    switch (mainAppCode)
                    {
                        case "PPAT":
                            dsPPAT = databaseAPI.GetPPATMasterInfo("PPAT");
                            break;
                        case "PIG":
                            dsPPAT = databaseAPI.GetPIGMasterInfo("PIG");
                            break;
                        case "SS":
                            dsPPAT = databaseAPI.GetSSMasterInfo("SS");
                            break;
                    }
                }
                foreach (var item in lstApplicationLookUp)
                {
                    ddlMainApps.Add(new SelectListItem { Text = item.AppCode, Value = item.AppCode });
                }

                ViewBag.ddlMainApps = ddlMainApps;
                List<SelectListItem> ddlMeasuringApp = new List<SelectListItem>();
                ddlMeasuringApp.Add(new SelectListItem { Text = "Select", Value = "Select" });
                ViewBag.ddlMeasuringApp = ddlMeasuringApp; // ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
                ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
                ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
                ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
                ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
                ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");


                ViewBag.PSCode = "";
                ViewBag.PSName = "";
            }

            //ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
            //ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
            //ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
            //ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
            //ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
            //ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");

            return View("_ConstituencySettings");
        }

        [HttpPost]
        public IActionResult SaveUserConstituencySettings()
        {
            EmployeeAcSetting empAcSettingModel = new EmployeeAcSetting();
            empAcSettingModel.StateCode = HttpContext.Request.Form["ddlStates"].ToString();
            empAcSettingModel.Pccode = HttpContext.Request.Form["ddlParliament"].ToString();
            empAcSettingModel.Accode = HttpContext.Request.Form["ddlAssembly"].ToString();
            empAcSettingModel.MandalCode = HttpContext.Request.Form["ddlMandal"].ToString();
            empAcSettingModel.VillageCode = HttpContext.Request.Form["ddlVillage"].ToString();
            empAcSettingModel.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
            empAcSettingModel.Psname = HttpContext.Request.Form["txtPSName"].ToString();
            empAcSettingModel.MeasuringAppCode = HttpContext.Request.Form["ddlMeasuringApp"].ToString();
            // HttpContext.Request.Form["hdnMeasuringApp"].ToString();
            empAcSettingModel.MainAppCode = HttpContext.Request.Form["ddlMainApps"].ToString();// HttpContext.Request.Form["hdnMainApp"].ToString();
            empAcSettingModel.CreatedBy = HttpContext.Session.GetString("LoginUserName").ToString();
            empAcSettingModel.CreatedDate = System.DateTime.Now;
            empAcSettingModel.EmpId = Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString());

            databaseAPI.UpdateEmployeeACSettingsData(empAcSettingModel);

            return RedirectToAction("ConstituencySettings");
        }
        public SelectList ToSelectList(DataTable table, string valueField, string textField, string selectText = "")
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                if (selectText == row[textField].ToString())
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[textField].ToString(),
                        Value = row[valueField].ToString(),
                        Selected = true
                    });
                }
                else
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[textField].ToString(),
                        Value = row[valueField].ToString()
                    });
                }
            }
            if (selectText != "")
                return new SelectList(list, "Value", "Text", selectText);
            else
                return new SelectList(list, "Value", "Text");
        }

        public IActionResult PPATForm(DataSet dsEmployeeInfo)
        {
            DataSet dsPPAT = new DataSet();
            dsPPAT = databaseAPI.GetPPATMasterInfo("PPAT");
            //IEnumerable<MeasuringApplicationMapping> PPATMeasuringApp =

            //ViewBag.ddlMeasuringApp = new SelectList(dsPPAT.Tables[0].AsDataView(), "MeasureAppMapId", "MeasureAppCode");            

            EmployeeAcSetting objEmpACSettingsData = new EmployeeAcSetting();
            objEmpACSettingsData = databaseAPI.GetEmployeeACSettings(Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString()), "PPAT");
            if (objEmpACSettingsData != null)
            {
                ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode", objEmpACSettingsData.MeasuringAppCode);
                ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName", objEmpACSettingsData.StateCode);
                ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName", objEmpACSettingsData.Pccode);
                ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName", objEmpACSettingsData.Accode);
                ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName", objEmpACSettingsData.MandalCode);
                ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName", objEmpACSettingsData.VillageCode);
                ViewBag.PSCode = objEmpACSettingsData.Pscode;
                ViewBag.PSName = objEmpACSettingsData.Psname;
            }
            else
            {
                ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
                ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
                ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
                ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
                ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
                ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");
                ViewBag.PSCode = "";
                ViewBag.PSName = "";
            }

            //ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
            //ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
            //ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
            //ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
            //ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
            //ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");
            ViewBag.ddlEducation = ToSelectList(dsPPAT.Tables[6], "EducationCode", "EducationName");
            ViewBag.ddlCommunity = ToSelectList(dsPPAT.Tables[7], "CommunityCode", "CommunityName");
            ViewBag.ddlIFParty = ToSelectList(dsPPAT.Tables[8], "IFCode", "IFName");
            ViewBag.ddlPPAT_SF = ToSelectList(dsPPAT.Tables[9], "PPAT_SFCode", "PPAT_SFName");
            ViewBag.ddlPPAT_PRF = ToSelectList(dsPPAT.Tables[10], "PPAT_PRFCode", "PPAT_PRFName");
            ViewBag.ddlPPAT_VPF = ToSelectList(dsPPAT.Tables[11], "PPAT_VPFCode", "PPAT_VPFName");
            ViewBag.ddlPPAT_PIF = ToSelectList(dsPPAT.Tables[12], "PPAT_PIFCode", "PPAT_PIFName");

            List<SelectListItem> ddlGender = new List<SelectListItem>()
            {
                new SelectListItem {Text="M",Value="M",Selected=true },
                new SelectListItem {Text="F",Value="F" },
                new SelectListItem {Text="OTH",Value="OTH"}
            };
            ViewBag.ddlGender = ddlGender;
            //return View("_PPAT");
            return View("_PPATForm");
        }
    }
}
