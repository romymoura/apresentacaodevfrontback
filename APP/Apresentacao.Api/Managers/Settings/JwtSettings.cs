namespace Apresentacao.Api.Managers.Settings
{
    public class JwtSettings
    {
        public string IssuerKey { get; set; }
        public string TokenAudience { get; set; }
        public string Issuer { get; set; }
        public int TokenExp { get; set; }
    }
}
