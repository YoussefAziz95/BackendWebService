
using System.Collections.Generic;

namespace Application.Contracts.Persistence.ActorRepositories;

public interface IActorRepositoryFactory<IAction>
{
    string GetActorType(int id);
    List<IAction> getActions(int id);
}
