namespace WorldOfFootball
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; }
        public int ExpireDays { get; set; }
        public string JwtIssuer { get; set; }
    }
}
