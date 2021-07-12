using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChartProject.Models
{
    public class EmployeeSkills
    {
        [Key]
        public Int64 Id { get; set; }
        public decimal TechnicalLevel { get; set; }
        public decimal LeadershipLevel { get; set; }
        public Int64 EmployeeId { get; set; }
    }
}