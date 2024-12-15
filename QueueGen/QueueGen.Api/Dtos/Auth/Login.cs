namespace QueueGen.Api.Dtos.Auth;

public static class Login
{
    public static class Request
    {
        public record Body(string Email, string Password);
    }
}
