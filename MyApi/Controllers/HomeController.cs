using ASP_CORE_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApi.Models;
using System.Data.SqlClient;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("Categories")]
        public ResponseHome GetCategories()
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseHome response = new ResponseHome();
            DAL dal = new DAL();
            response = dal.GetAllCategories(con, -1);
            return response;
        }
    }
}
