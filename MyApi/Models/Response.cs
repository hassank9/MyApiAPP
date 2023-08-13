using MyApi.Models;

namespace ASP_CORE_API.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public Employee Employee { get; set; }
        public List<Employee> listEmployee { get; set; }

    }
}
