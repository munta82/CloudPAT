using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class EmployeeAppAccess
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string AppCode { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ApplicationLookUp AppCodeNavigation { get; set; }
        public virtual EmployeeInfo Emp { get; set; }
    }
}
