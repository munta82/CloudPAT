using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class PigUserInfo
    {
        public int PigUserId { get; set; }
        public string PigUserDisplayName { get; set; }
        public string PigUserGender { get; set; }
        public int PigUserAge { get; set; }
        public string PigUserMobile { get; set; }
        public string PigOccupation { get; set; }
        public string PigEducationCode { get; set; }
        public string PigCommunityCode { get; set; }
        public string PigSubCasteCode { get; set; }
        public string PigIfcode { get; set; }
        public string PigScale { get; set; }
        public string PigGrade { get; set; }
        public string Pigcode { get; set; }
        public string PigRemarks { get; set; }
        public string PigIgcode { get; set; }
        public string PigPosition { get; set; }
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
