namespace QueueGen.Api.Dtos.Auth;

public static class Refresh
{
    public static class Request
    {
        public record Body(string RefreshToken);
    }
}