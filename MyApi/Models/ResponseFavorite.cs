namespace MyApi.Models
{
    public class ResponseFavorite
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public List<Favorite> listFavorite { get; set; }
    }
}
