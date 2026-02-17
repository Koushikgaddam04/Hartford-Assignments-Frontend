namespace Day_33_C__JWT.Models
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = "ThisIsMySuperSecretKeyThatIsAtLeast32CharsLong!";
        public string Issuer { get; set; } = "http://www.xyz.com";
        public string Audience { get; set; } = "http://www.abc.com";
        public int ExpiryMinutes { get; set; } = 60;
    }
}