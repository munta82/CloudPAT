using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class MeasuringApplicationLookUp
    {
        public MeasuringApplicationLookUp()
        {
            MeasuringApplicationMappings = new HashSet<MeasuringApplicationMapping>();
        }

        public int MeasureAppId { get; set; }
        public string MeasureAppCode { get; set; }
        public string MeasureAppName { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<MeasuringApplicationMapping> MeasuringApplicationMappings { get; set; }
    }
}
