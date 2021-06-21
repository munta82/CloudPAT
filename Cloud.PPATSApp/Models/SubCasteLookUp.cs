using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class SubCasteLookUp
    {
        public int SubCasteId { get; set; }
        public string SubCasteCode { get; set; }
        public string SubCasteName { get; set; }
        public string CommunityCode { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
