using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChartProject.Models
{
    public class Employees
    {
        [Key]
        public Int64 Id { get; set; }
        public string EmployeeName { get; set; }
    }
}