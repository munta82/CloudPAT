using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Cloud.PPATSApp.Models
{
    public partial class EmployeeInfo
    {
        public int EmpId { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public string EmpPhone { get; set; }
        public string EmpEmail { get; set; }
        public string EmpAddress { get; set; }
        [Required()]
        public string EmpUsername { get; set; }
        [Required()]
        public string EmpPassword { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
