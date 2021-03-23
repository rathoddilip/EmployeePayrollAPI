using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer.ResponseModel
{
    public class EmployeeModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public long Salary { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public string ProfileImage { get; set; }
        [Required]
        public int DeptID { get; set; }
        [Required]
        public string Department1 { get; set; }
        [Required]
        public string Department2 { get; set; }
        [Required]
        public string Department3 { get; set; }

    }
}
