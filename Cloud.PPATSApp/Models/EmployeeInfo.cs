using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class EmployeeInfo
    {
        public EmployeeInfo()
        {
            EmployeeAppAccesses = new HashSet<EmployeeAppAccess>();
            EmployeeRoles = new HashSet<EmployeeRole>();
        }

        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        public string EmpUsername { get; set; }
        public string EmpPassword { get; set; }
        public Guid EmpSecureId { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<EmployeeAppAccess> EmployeeAppAccesses { get; set; }
        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
