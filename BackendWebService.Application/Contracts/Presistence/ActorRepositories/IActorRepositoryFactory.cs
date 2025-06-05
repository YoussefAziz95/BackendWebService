namespace Application.Contracts.Persistence;

public interface IActorRepositoryFactory<IAction>
{
    string GetActorType(int id);
    List<IAction> getActions(int id);
}
