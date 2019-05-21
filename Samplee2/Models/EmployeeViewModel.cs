using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Samplee2.Models
{
    public class EmployeeViewModel
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="please provide the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please provide the Birthdate")]
        //[DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }
            

        [Required(ErrorMessage = "please provide the Designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "please provide the Salary")]
        public double Salary { get; set; }
    }
}