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
    public class FavoriteController : ControllerBase
    {
        public readonly IConfiguration _configuration;

        public FavoriteController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        [Route("AddFavorite")]
        public ResponseFavorite AddUsers(Favorite favorite)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseFavorite response = new ResponseFavorite();
            DAL dal = new DAL();
            response = dal.AddFavorite(con, favorite);
            return response;
        }

        [HttpPost]
        [Route("myFavorite")]
        public ResponseMyFavorite AddUsers(MyFavorite myfavorite)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseMyFavorite response = new ResponseMyFavorite();
            DAL dal = new DAL();
            response = dal.myFavorite(con, myfavorite);
            return response;
        }

        [HttpDelete]
        [Route("DeleteFavorite")]
        public ResponseFavorite DeleteEmployee(Favorite favorite)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("AppConn").ToString());
            ResponseFavorite response = new ResponseFavorite();
            DAL dal = new DAL();
            response = dal.DeleteFavorite(con, favorite);
            return response;
        }
    }
}
