using ASP_CORE_API.Models;

namespace MyApi.Models
{
    public class ResponseItems
    {

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public List<Items> ItemsList { get; set; }

    }
}
