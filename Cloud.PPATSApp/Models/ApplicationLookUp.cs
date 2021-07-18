using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class ApplicationLookUp
    {
        public ApplicationLookUp()
        {
            EmployeeAppAccesses = new HashSet<EmployeeAppAccess>();
            MeasuringApplicationMappings = new HashSet<MeasuringApplicationMapping>();
        }

        public int AppId { get; set; }
        public string AppCode { get; set; }
        public string AppName { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<EmployeeAppAccess> EmployeeAppAccesses { get; set; }
        public virtual ICollection<MeasuringApplicationMapping> MeasuringApplicationMappings { get; set; }
    }
}
