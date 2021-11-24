namespace IdentityAndAccess.API.Dtos.Authentication
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenDto UserToken { get; set; }
    }

    public class UserTokenDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimDto> Claims { get; set; }
    }

    public class ClaimDto
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
