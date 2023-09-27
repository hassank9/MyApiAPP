using ASP_CORE_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using System.Data.SqlClient;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public CartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddCart")]
        public ResponseCart AddCart(Cart cart)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseCart response = new ResponseCart();
            DAL dal = new DAL();
            response = dal.AddCart(con, cart);
            return response;
        }


        [HttpDelete]
        [Route("DeleteCart")]
        public ResponseCart DeleteCart(Cart cart)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseCart response = new ResponseCart();
            DAL dal = new DAL();
            response = dal.DeleteCart(con, cart);
            return response;
        }


        [HttpPost]
        [Route("CountCart")]
        public ResponseCart CountCart(Cart cart)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseCart response = new ResponseCart();
            DAL dal = new DAL();
            response = dal.CountCart(con, cart );
            return response;
        }
    }
}
