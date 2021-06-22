using Cloud.PPATSApp.Models;
using Cloud.PPATSApp.Models.BAL;
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
             
            ViewBag.ddlMeasuringApp = ToSelectList(dsPPAT.Tables[0], "MeasureAppMapId", "MeasureAppCode"); ;

            ViewBag.ddlStates = ToSelectList(dsPPAT.Tables[1], "StateCode", "StateName");            

            ViewBag.ddlParliament = ToSelectList(dsPPAT.Tables[2], "PCCode", "PCName");

            ViewBag.ddlAssembly = ToSelectList(dsPPAT.Tables[3], "ACCode", "ACName");

            ViewBag.ddlMandal = ToSelectList(dsPPAT.Tables[4], "MandalCode", "MandalName");

            ViewBag.ddlVillage = ToSelectList(dsPPAT.Tables[5], "VillageCode", "VillageName");
            ViewBag.ddlEducation = ToSelectList(dsPPAT.Tables[6], "EducationCode", "EducationName");
            ViewBag.ddlCommunity = ToSelectList(dsPPAT.Tables[7], "CommunityCode", "CommunityName");

            ViewBag.ddlIFParty = ToSelectList(dsPPAT.Tables[8], "IFCode", "IFName");
            ViewBag.ddlPPAT_SF = ToSelectList(dsPPAT.Tables[9], "PPAT_SFCode", "PPAT_SFName");
            ViewBag.ddlPPAT_PRF = ToSelectList(dsPPAT.Tables[10], "PPAT_PRFCode", "PPAT_PRFName");
            ViewBag.ddlPPAT_VPF = ToSelectList(dsPPAT.Tables[11], "PPAT_VPFCode", "PPAT_VPFName");
            ViewBag.ddlPPAT_PIF = ToSelectList(dsPPAT.Tables[12], "PPAT_PIFCode", "PPAT_PIFName");
             
            return View("_PPAT");
        }
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }
    }
}
