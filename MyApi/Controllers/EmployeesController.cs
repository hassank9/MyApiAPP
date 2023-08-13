using ASP_CORE_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace ASP_CORE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public EmployeesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        public Response GetEmployees()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmployee(con);
            return response;
        }

        [HttpGet]
        [Route("GetAllEmployees/{id}")]
        public Response GetEmployeeById(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetEmployeeById(con,id);
            return response;
        }


        [HttpPost]
        [Route("AddEmployee")]
        public Response AddEmployee(Employee employee)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddEmployee(con, employee);
            return response;
        }


        [HttpPut]
        [Route("UpdateEmployee")]
        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateEmployee(con, employee);
            return response;
        }


        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public Response DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteEmployee(con, id); 
            return response;
        }

    }
}
