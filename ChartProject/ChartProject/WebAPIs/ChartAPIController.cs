using ChartProject.DAL;
using ChartProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChartProject.WebAPIs
{
    public class ChartAPIController : ApiController
    {
        private ChartContext db = new ChartContext();

        [Route("graph/data")]    
        [HttpGet]                       
        public HttpResponseMessage GetGraphData()
        {
            try
            {
                //--Create object of Resopnse
                ChartViewModel objGraph = new ChartViewModel();

                //--Get All Technical-Levels
                objGraph.technical_levels = (from tl in db.TechnicalLevels
                                             select new Levels_VM
                                             {
                                                 level = tl.Level,
                                                 level_name = tl.LevelName
                                             }).ToList();

                //--Get All Leadership-Levels
                objGraph.leadership_levels = (from tl in db.LeadershipLevels
                                             select new Levels_VM
                                             {
                                                 level = tl.Level,
                                                 level_name = tl.LevelName
                                             }).ToList();

                //--Get Employees-Skill
                objGraph.graph_data = (from es in db.EmployeeSkills
                                       join e in db.Employees on es.EmployeeId equals e.Id
                                       select new GraphData_VM
                                       {
                                           employee_name = e.EmployeeName,
                                           technical_level = es.TechnicalLevel,
                                           leadership_level = es.LeadershipLevel
                                       }).ToList();

                //--Create Success response of Graph-Data
                ResponseViewModel objResponse = new ResponseViewModel() { status = 1, message = "Success", data = objGraph };

                //sending response OK with Data
                return Request.CreateResponse(HttpStatusCode.OK, objResponse);
            }
            catch (Exception)
            {
                //--Create response as Error
                ResponseViewModel objResponse = new ResponseViewModel() { status = -100, message = "Technical Error!", data = null };
                //sending response as error
                return Request.CreateResponse(HttpStatusCode.InternalServerError, objResponse);
            }
        }
    }
}
