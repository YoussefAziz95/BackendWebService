namespace Application.Contracts.Presistence.ActorRepositories
{
    public interface IActorRepositoryFactory<IAction>
    {
        string GetActorType(int id);
        List<IAction> getActions(int id);
    }
}
