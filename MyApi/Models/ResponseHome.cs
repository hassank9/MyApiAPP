namespace MyApi.Models
{
    public class ResponseHome
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public List<Categories> lstCategories { get; set; } 
        public List<Items> lstItems { get; set; }

    }
}
