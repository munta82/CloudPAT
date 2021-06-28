using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cloud.PPATSApp.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public int UserId { get; set; }
        public string UserDisplayName { get; set; }
        public string Gender { get; set; }
        public int UserAge { get; set; }
        public string UserMobile { get; set; }
        public string Occupation { get; set; }
        public string EducationCode { get; set; }
        public string CommunityCode { get; set; }
        public string SubCasteCode { get; set; }
        public string IFCode { get; set; }
        public string SFCode { get; set; }
        public string PRFCode { get; set; }
        public string VPFCode { get; set; }
        public string PIFCode { get; set; }
        public string Remarks { get; set; }
        public string MeasureAppCode { get; set; }
        public string StateCode { get; set; }
        public string MandalCode { get; set; }
        public string VillageCode { get; set; }

        public string PCCode { get; set; }
        public string PCName { get; set; }
        public string ACCode { get; set; }
        public string ACName { get; set; }
        public string PSCode { get; set; }
        public string PSName { get; set; }      
     
        //public string AppCode { get; set; }
        //public char IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
