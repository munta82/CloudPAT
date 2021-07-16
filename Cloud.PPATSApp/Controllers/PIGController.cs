using Cloud.PPATSApp.Core;
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
    public class PIGController : Controller
    {
        private readonly CloudPATContext _dbContext;
        DataBaseAPI databaseAPI = new DataBaseAPI();
        public PIGController(CloudPATContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(DataSet dsEmployeeInfo = null)
        {
            DataSet dsPPAT = new DataSet();
            dsPPAT = databaseAPI.GetPIGMasterInfo("PIG");
            
            EmployeeAcSetting objEmpACSettingsData = new EmployeeAcSetting();
            objEmpACSettingsData = databaseAPI.GetEmployeeACSettings(Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString()), "PIG");
            if (objEmpACSettingsData != null)
            {
                ViewBag.ddlMeasuringApp = CommonExtensions.ToSelectList(dsPPAT.Tables[0], "MeasureAppCode", "MeasureAppCode", objEmpACSettingsData.MeasuringAppCode);
                ViewBag.ddlStates = CommonExtensions.ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName", objEmpACSettingsData.StateCode);
                ViewBag.ddlParliament = CommonExtensions.ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName", objEmpACSettingsData.Pccode);
                ViewBag.ddlAssembly = CommonExtensions.ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName", objEmpACSettingsData.Accode);
                ViewBag.ddlMandal = CommonExtensions.ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName", objEmpACSettingsData.MandalCode);
                ViewBag.ddlVillage = CommonExtensions.ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName", objEmpACSettingsData.VillageCode);
                ViewBag.PSCode = objEmpACSettingsData.Pscode;
                ViewBag.PSName = objEmpACSettingsData.Psname;
            }
            else
            {
                ViewBag.ddlMeasuringApp = CommonExtensions.ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode");
                ViewBag.ddlStates = CommonExtensions.ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");
                ViewBag.ddlParliament = CommonExtensions.ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");
                ViewBag.ddlAssembly = CommonExtensions.ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");
                ViewBag.ddlMandal = CommonExtensions.ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");
                ViewBag.ddlVillage = CommonExtensions.ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");
                ViewBag.PSCode = "";
                ViewBag.PSName = "";
            }

            ViewBag.ddlEducation = CommonExtensions.ToSelectList(dsPPAT.Tables[6], "EducationCode", "EducationName");
            ViewBag.ddlCommunity = CommonExtensions.ToSelectList(dsPPAT.Tables[7], "CommunityCode", "CommunityName");
            ViewBag.ddlIFParty = CommonExtensions.ToSelectList(dsPPAT.Tables[8], "IFCode", "IFName");
            ViewBag.ddlIG = CommonExtensions.ToSelectList(dsPPAT.Tables[9], "IGCode", "IGName");
            
            List<SelectListItem> ddlGender = new List<SelectListItem>()
            {
                new SelectListItem {Text="M",Value="M",Selected=true },
                new SelectListItem {Text="F",Value="F" },
                new SelectListItem {Text="OTH",Value="OTH"}
            };

            List<SelectListItem> ddlScale = new List<SelectListItem>();
            for (int i=0; i<5; i++)
            {
                ddlScale.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            List<SelectListItem> ddlPIG = new List<SelectListItem>();
            for (int i = 1; i < 11; i++)
            {
                ddlPIG.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            }

            List<SelectListItem> ddGrade = new List<SelectListItem>()
            {
                new SelectListItem {Text="A",Value="A",Selected=true },
                new SelectListItem {Text="B",Value="B"},
                new SelectListItem {Text="C",Value="C"},
                new SelectListItem {Text="D",Value="D"},
                new SelectListItem {Text="E",Value="E"},
            };

            ViewBag.ddlGender = ddlGender;
            ViewBag.ddlPIG = ddlPIG;
            ViewBag.ddlGrade = ddGrade;
            ViewBag.ddlScale = ddlScale;
            return View("_PIG");
            
        }

        [HttpPost]
        public ActionResult SavePIGForm(PIGViewModel obj, IFormCollection form)
        {
            PigUserInfo userInfoModel = new PigUserInfo();
            userInfoModel.PigUserDisplayName = HttpContext.Request.Form["txtUserDisplayName"].ToString();
            userInfoModel.PigUserAge = Convert.ToInt16(HttpContext.Request.Form["txtUserAge"]);
            userInfoModel.PigUserGender = HttpContext.Request.Form["ddlGender"].ToString();
            userInfoModel.PigUserMobile = HttpContext.Request.Form["txtMobile"].ToString();
            userInfoModel.PigOccupation = HttpContext.Request.Form["txtOccupation"].ToString();
            userInfoModel.PigEducationCode = HttpContext.Request.Form["ddlEducation"].ToString();
            userInfoModel.PigCommunityCode = HttpContext.Request.Form["ddlCommunity"].ToString();
            userInfoModel.PigSubCasteCode = HttpContext.Request.Form["txtSubCaste"].ToString();
            userInfoModel.PigIfcode = HttpContext.Request.Form["ddlIFParty"].ToString();
            userInfoModel.PigScale = HttpContext.Request.Form["ddlScale"].ToString();
            userInfoModel.PigGrade = HttpContext.Request.Form["ddlGrade"].ToString();
            userInfoModel.Pigcode = HttpContext.Request.Form["ddlPIG"].ToString();
            userInfoModel.PigPosition = HttpContext.Request.Form["txtPosition"].ToString();
            userInfoModel.PigIgcode = HttpContext.Request.Form["ddlIG"].ToString();
            userInfoModel.PigRemarks = HttpContext.Request.Form["txtRemarks"].ToString();

            userInfoModel.StateCode = HttpContext.Request.Form["ddlStates"].ToString();
            userInfoModel.Pccode = HttpContext.Request.Form["ddlParliament"].ToString();
            userInfoModel.Accode = HttpContext.Request.Form["ddlAssembly"].ToString();
            userInfoModel.MandalCode = HttpContext.Request.Form["ddlMandal"].ToString();
            userInfoModel.VillageCode = HttpContext.Request.Form["ddlVillage"].ToString();
            userInfoModel.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
            userInfoModel.MeasureAppCode = HttpContext.Request.Form["hdnMeasuringApp"].ToString();
            //HttpContext.Request.Form["ddlMeasuringApp"].ToString();
            userInfoModel.AppCode = "PIG";
            userInfoModel.CreatedBy = HttpContext.Session.GetString("LoginUserDisplayName").ToString();
            userInfoModel.CreatedDate = System.DateTime.Now;

            databaseAPI.SaveUpdatePIGUserInfo(userInfoModel);

            AssemblyPollingStationLookUp objPSData = new AssemblyPollingStationLookUp();
            TryUpdateModelAsync(objPSData);
            objPSData.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
            objPSData.Psname = HttpContext.Request.Form["txtPSName"].ToString();
            objPSData.ModifiedBy = HttpContext.Session.GetString("LoginUserDisplayName").ToString();
            databaseAPI.UpdateAssemblyPollingStationName(objPSData);

            ViewBag.Message = "Customer saved successfully!";

            DataSet dsEmployeeInfo = new DataSet();
            dsEmployeeInfo = databaseAPI.GetEmployeeInfo(HttpContext.Session.GetString("LoginUserName").ToString(), -1);

            
            return RedirectToAction("Index", "PIG", dsEmployeeInfo);
        }

    }
}
