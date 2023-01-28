namespace SchoolSystem.BLL.AuthTokenService
{
    /// <summary>
    ///     Class used to desirialize the values from a json file
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        ///     Key string which value is stored in a json file
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        ///    Issuer string which value is stored in a json filek
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        ///     LifeTime integer which value is stored in a json file
        /// </summary>
        public int LifeTime { get; set; }
    }
}