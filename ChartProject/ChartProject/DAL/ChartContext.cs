using ChartProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChartProject.DAL
{
    public class ChartContext : DbContext
    {
        public DbSet<TechnicalLevels> TechnicalLevels { get; set; }
        public DbSet<LeadershipLevels> LeadershipLevels { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeSkills> EmployeeSkills { get; set; }
    }
}