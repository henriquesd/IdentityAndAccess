namespace IdentityAndAccess.API.Dtos.Authentication
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
    }
}
