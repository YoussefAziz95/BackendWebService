namespace Application.Contracts.Persistence;

public interface IActorRepository<IAction>
{
    public string GetActorType(int id);
    public List<IAction> getActions(int userid);
}
