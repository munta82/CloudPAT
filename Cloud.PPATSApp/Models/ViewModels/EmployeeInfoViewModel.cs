using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cloud.PPATSApp.Models.ViewModels
{
    public class EmployeeInfoViewModel
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        [Required(ErrorMessage = "*")]
        public string EmpUsername { get; set; }
        [Required(ErrorMessage = "*")]
        public string EmpPassword { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public List<RolesLookUp> RolesLookUp { get; set; }
        public List<String> EmpApplications { get; set; }
        public IEnumerable<SelectListItem> EmpAssignedApps { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
        public int EmpRoleId { get; set; }
        public string EmpRoleName { get; set; }

    }
}
