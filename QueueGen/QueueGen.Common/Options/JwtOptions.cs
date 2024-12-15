namespace QueueGen.Common.Options;

public class JwtOptions
{
    public const string Path = "Jwt";

    public required string SecretKey { get; set; }
    public required int AccessTokenLifeTimeInMinutes { get; set; }
    public required int RefreshTokenLifeTimeInDays { get; set; }
}