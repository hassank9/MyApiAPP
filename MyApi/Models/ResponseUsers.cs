namespace MyApi.Models
{
    public class ResponseUsers
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<Users> listUsers { get; set; }
    }
}
