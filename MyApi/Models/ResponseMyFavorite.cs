using ASP_CORE_API.Models;

namespace MyApi.Models
{
    public class ResponseMyFavorite
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public List<MyFavorite> myFavorites { get; set; }
    }
}
