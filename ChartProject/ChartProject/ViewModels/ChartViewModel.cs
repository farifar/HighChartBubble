
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChartProject.ViewModels
{
    public class ResponseViewModel
    {
        public int status { get; set; }
        public string message { get; set; }
        public ChartViewModel data { get; set; }
    }

    public class ChartViewModel
    {
        public List<Levels_VM> technical_levels { get; set; }
        public List<Levels_VM> leadership_levels { get; set; }
        public List<GraphData_VM> graph_data { get; set; }
    }

    public class Levels_VM
    {
        public string level { get; set; }
        public string level_name { get; set; }
    }

    public class GraphData_VM
    {
        public string employee_name { get; set; }
        public decimal technical_level { get; set; }
        public decimal leadership_level { get; set; }
    }
}