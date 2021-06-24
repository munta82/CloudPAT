using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class EmployeeAcSetting
    {
        public int AcSettingsId { get; set; }
        public int EmpId { get; set; }
        public string Pscode { get; set; }
        public string Psname { get; set; }
        public string VillageCode { get; set; }
        public string MandalCode { get; set; }
        public string Accode { get; set; }
        public string Pccode { get; set; }
        public string StateCode { get; set; }
        public string MeasuringAppCode { get; set; }
        public string MainAppCode { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
