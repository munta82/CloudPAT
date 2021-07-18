using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class UserInfo
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
        public string Ifcode { get; set; }
        public string Sfcode { get; set; }
        public string Prfcode { get; set; }
        public string Vpfcode { get; set; }
        public string Pifcode { get; set; }
        public string Ebfcode { get; set; }
        public string Llrfcode { get; set; }
        public string GradingCode { get; set; }
        public string Sifcode { get; set; }
        public string Remarks { get; set; }
        public string StateCode { get; set; }
        public string Pccode { get; set; }
        public string Accode { get; set; }
        public string MandalCode { get; set; }
        public string VillageCode { get; set; }
        public string Pscode { get; set; }
        public string MeasureAppCode { get; set; }
        public string AppCode { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
