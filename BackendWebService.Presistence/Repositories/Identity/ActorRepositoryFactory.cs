using Application.Contracts.Persistence;
using Domain;
using Persistence.Data;
namespace Persistence.Repositories.Identity;

public class ActorRepositoryFactory : IActorRepositoryFactory<ActionActor>
{

    // DbContext instance
    protected readonly ApplicationDbContext _context;
    protected readonly IActorRepository<ActionActor> _actorRepository;


    public ActorRepositoryFactory(ApplicationDbContext context, string ActorType)
    {
        _context = context;

    }

    string IActorRepositoryFactory<ActionActor>.GetActorType(int id)
    {
        throw new NotImplementedException();
    }

    List<ActionActor> IActorRepositoryFactory<ActionActor>.getActions(int id)
    {
        throw new NotImplementedException();
    }
}

