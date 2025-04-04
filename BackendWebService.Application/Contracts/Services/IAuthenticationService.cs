namespace Application.Contracts.Services;

public interface IAuthenticationService
{
    Task<bool> IsAuthenticated();
    string getEmail();
}
