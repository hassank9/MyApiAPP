namespace MyApi.Models
{
    public class ResponseCategories
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public List<Categories> lstCategories { get; set; }
    }
}
