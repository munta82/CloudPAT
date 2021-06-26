using System;
using System.Collections.Generic;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class RolesLookUp
    {
        public RolesLookUp()
        {
            EmployeeRoles = new HashSet<EmployeeRole>();
        }

        public int AutoId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; }
    }
}
