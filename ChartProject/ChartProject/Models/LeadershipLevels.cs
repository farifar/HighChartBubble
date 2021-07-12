using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChartProject.Models
{
    public class LeadershipLevels
    {
        [Key]
        public Int64 Id { get; set; }
        public string Level { get; set; }
        public string LevelName { get; set; }
    }
}