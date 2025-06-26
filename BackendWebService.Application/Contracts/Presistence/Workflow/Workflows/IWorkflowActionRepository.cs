using Application.Features;
using Application.Model.EAVEngine;
using Domain;

namespace Application.Contracts.Persistence
{
    public interface ICaseActionRepository
    {
        int AddNeactionActor(Case wcase);
        int TakeAction(TakeActionModel reviewObjectModel);
        List<CaseActionsResponse> GetActionsByUserId(int userId);
        ActionResponse GetAsync(int id, int userId);
    }
}
