namespace MyApi.Models
{
    public class ResponseCart
    {
        public int StatusCode { get; set; }
        public int Count { get; set; }
        public string ErrorMessage { get; set; }
        public List<Cart> listCart { get; set; }
    }
}
