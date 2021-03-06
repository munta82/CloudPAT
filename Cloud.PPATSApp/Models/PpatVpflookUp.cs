using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class PpatVpflookUp
    {
        public int PpatVpfid { get; set; }
        public string PpatVpfcode { get; set; }
        public string PpatVpfname { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
