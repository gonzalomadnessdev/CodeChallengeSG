namespace AuthService.Dtos.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; } = "";
        public DateTime Expires { get; set; }
    }
}
