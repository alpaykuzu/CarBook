namespace CarBook.WebUI.Models
{
    public class JwtResponseModel
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
