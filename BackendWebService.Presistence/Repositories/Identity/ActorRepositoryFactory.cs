using Application.Contracts.Persistences;

using Persistence.Data;
namespace Persistence.Repositories.Identity;

public class ActorRepositoryFactory : IActorRepositoryFactory<WAction>
{

    // DbContext instance
    protected readonly ApplicationDbContext _context;
    protected readonly IActorRepository<WAction> _actorRepository;


    public ActorRepositoryFactory(ApplicationDbContext context, string ActorType)
    {
        _context = context;

    }

    string IActorRepositoryFactory<WAction>.GetActorType(int id)
    {
        throw new NotImplementedException();
    }

    List<WAction> IActorRepositoryFactory<WAction>.getActions(int id)
    {
        throw new NotImplementedException();
    }
}

