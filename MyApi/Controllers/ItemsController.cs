using ASP_CORE_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System.Data.SqlClient;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        public readonly IConfiguration _configuration;

        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpGet]
        [Route("Items")]
        public ResponseItems GetCategories(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseItems response = new ResponseItems();
            DAL dal = new DAL();
            response = dal.GetItems(con, id);
            return response;
        }


        [HttpPost]
        [Route("GetItemsByCat")]
        public ResponseItems Login(Items responseItems)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseItems response = new ResponseItems();
            DAL dal = new DAL();
            response = dal.GetItemsbyCat(con, responseItems);
            return response;
        }
    }
}
