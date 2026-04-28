internal class JWTSettings
{
    public char[] SecretKey { get; internal set; }
    public string Issuer { get; internal set; }
    public string Audience { get; internal set; }
}