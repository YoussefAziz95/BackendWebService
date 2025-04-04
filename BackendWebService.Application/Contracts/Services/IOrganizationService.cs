namespace Application.Contracts.Services;

public interface IOrganizationService
{
    Task<string> OrganizationNameById(int Id);
}
