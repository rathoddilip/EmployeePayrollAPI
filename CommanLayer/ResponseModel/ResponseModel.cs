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

    }
}
