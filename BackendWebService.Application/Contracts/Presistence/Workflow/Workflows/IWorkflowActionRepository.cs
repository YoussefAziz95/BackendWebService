using Application.Features;
using Application.Model.EAVEngine;
namespace Application.Contracts.Persistence
{
    public interface ICaseActionRepository
    {
        int AddNeactionActor(Case wcase);
        int TakeAction(TakeActionModel reviewObjectModel);
        List<CaseActionAllResponse> GetActionsByUserId(int userId);
        ActionResponse GetAsync(int id, int userId);
    }
}
