namespace MyApi.Models
{
    public class ResponseLogin
    {
        public int StatusCode { get; set; }
        public int id{ get; set; }
        public String username{ get; set; }
        public String email{ get; set; }
        public String phone{ get; set; }
        public String password { get; set; }
        public String users_approve { get; set; }
    }
}
