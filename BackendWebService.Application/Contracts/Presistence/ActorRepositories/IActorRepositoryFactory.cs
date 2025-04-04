namespace Application.Contracts.Persistences;

public interface IActorRepositoryFactory<IAction>
{
    string GetActorType(int id);
    List<IAction> getActions(int id);
}
