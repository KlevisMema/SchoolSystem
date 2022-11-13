namespace SchoolSystem.BLL.AuthTokenService
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int LifeTime { get; set; }
    }
}