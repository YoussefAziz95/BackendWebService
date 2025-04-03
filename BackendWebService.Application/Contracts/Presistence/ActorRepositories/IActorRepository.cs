
using System.Collections.Generic;
namespace Application.Contracts.Persistence.ActorRepositories;

public interface IActorRepository<IAction>
{
    public string GetActorType(int id);
    public List<IAction> getActions(int userid);
}
