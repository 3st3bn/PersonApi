namespace PersonApi.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateJwtToken(string username);
    }
}
