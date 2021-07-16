using Cloud.PPATSApp.Core;
using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Controllers
{
    public class SSController : Controller
    {
        private readonly CloudPATContext _dbContext;
        DataBaseAPI databaseAPI = new DataBaseAPI();
        public SSController(CloudPATContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            DataSet dsSocial= new DataSet();
            dsSocial = databaseAPI.GetPIGMasterInfo("SS");

            EmployeeAcSetting objEmpACSettingsData = new EmployeeAcSetting();
            objEmpACSettingsData = databaseAPI.GetEmployeeACSettings(Convert.ToInt16(HttpContext.Session.GetString("LoginEmpId").ToString()), "SS");
            if (objEmpACSettingsData != null)
            {
                ViewBag.ddlMeasuringApp = CommonExtensions.ToSelectList(dsSocial.Tables[0], "MeasureAppCode", "MeasureAppCode", objEmpACSettingsData.MeasuringAppCode);
                ViewBag.ddlStates = CommonExtensions.ToSelectList(dsSocial.Tables[1], "StateCode", "StateName", objEmpACSettingsData.StateCode);
                ViewBag.ddlParliament = CommonExtensions.ToSelectList(dsSocial.Tables[2], "PCCode", "PCName", objEmpACSettingsData.Pccode);
                ViewBag.ddlAssembly = CommonExtensions.ToSelectList(dsSocial.Tables[3], "ACCode", "ACName", objEmpACSettingsData.Accode);
                ViewBag.ddlMandal = CommonExtensions.ToSelectList(dsSocial.Tables[4], "MandalCode", "MandalName", objEmpACSettingsData.MandalCode);
                ViewBag.ddlVillage = CommonExtensions.ToSelectList(dsSocial.Tables[5], "VillageCode", "VillageName", objEmpACSettingsData.VillageCode);
                ViewBag.PSCode = objEmpACSettingsData.Pscode;
                ViewBag.PSName = objEmpACSettingsData.Psname;
            }
            else
            {
                ViewBag.ddlMeasuringApp = CommonExtensions.ToSelectList(dsSocial.Tables[0], "MeasureAppMapId", "MeasureAppCode");
                ViewBag.ddlStates = CommonExtensions.ToSelectList(dsSocial.Tables[1], "StateCode", "StateName");
                ViewBag.ddlParliament = CommonExtensions.ToSelectList(dsSocial.Tables[2], "PCCode", "PCName");
                ViewBag.ddlAssembly = CommonExtensions.ToSelectList(dsSocial.Tables[3], "ACCode", "ACName");
                ViewBag.ddlMandal = CommonExtensions.ToSelectList(dsSocial.Tables[4], "MandalCode", "MandalName");
                ViewBag.ddlVillage = CommonExtensions.ToSelectList(dsSocial.Tables[5], "VillageCode", "VillageName");
                ViewBag.PSCode = "";
                ViewBag.PSName = "";
            }

            ViewBag.ddlCommunity = CommonExtensions.ToSelectList(dsSocial.Tables[7], "CommunityCode", "CommunityName");
           
            return View("_SS");
        }

        [HttpPost]
        public ActionResult SaveSSForm(IFormCollection form)
        {
            SsDetail SSDetailInfoModel = new SsDetail();
            SSDetailInfoModel.Remarks = HttpContext.Request.Form["txtRemarks"].ToString();
            SSDetailInfoModel.Voters = Convert.ToInt16(HttpContext.Request.Form["txtVoters"]);
            SSDetailInfoModel.SsCommunityCode = HttpContext.Request.Form["ddlCommunity"].ToString();
            SSDetailInfoModel.SsSubCasteCode = HttpContext.Request.Form["txtSubCaste"].ToString();

            SSDetailInfoModel.StateCode = HttpContext.Request.Form["ddlStates"].ToString();
            SSDetailInfoModel.Pccode = HttpContext.Request.Form["ddlParliament"].ToString();
            SSDetailInfoModel.Accode = HttpContext.Request.Form["ddlAssembly"].ToString();
            SSDetailInfoModel.MandalCode = HttpContext.Request.Form["ddlMandal"].ToString();
            SSDetailInfoModel.VillageCode = HttpContext.Request.Form["ddlVillage"].ToString();
            SSDetailInfoModel.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
            SSDetailInfoModel.MeasureAppCode = HttpContext.Request.Form["hdnMeasuringApp"].ToString();
            SSDetailInfoModel.AppCode = "SS";
            SSDetailInfoModel.CreatedBy = HttpContext.Session.GetString("LoginUserDisplayName").ToString();
            SSDetailInfoModel.CreatedDate = System.DateTime.Now;

            databaseAPI.SaveUpdateSSInfo(SSDetailInfoModel);

            AssemblyPollingStationLookUp objPSData = new AssemblyPollingStationLookUp();
            TryUpdateModelAsync(objPSData);
            objPSData.Pscode = HttpContext.Request.Form["txtPSCode"].ToString();
            objPSData.Psname = HttpContext.Request.Form["txtPSName"].ToString();
            objPSData.ModifiedBy = HttpContext.Session.GetString("LoginUserDisplayName").ToString();
            databaseAPI.UpdateAssemblyPollingStationName(objPSData);

            ViewBag.Message = "Customer saved successfully!";

            DataSet dsEmployeeInfo = new DataSet();
            dsEmployeeInfo = databaseAPI.GetEmployeeInfo(HttpContext.Session.GetString("LoginUserName").ToString(), -1);


            return RedirectToAction("Index", "SS", dsEmployeeInfo);
        }

    }
}
