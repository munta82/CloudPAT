using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class IgDetail
    {
        public int IgId { get; set; }
        public string Igcode { get; set; }
        public string Igname { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
