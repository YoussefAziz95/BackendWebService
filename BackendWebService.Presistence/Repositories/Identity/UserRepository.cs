using Application.Contracts.Persistences;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;


namespace Persistence.Repositories.Identity
{
    public class UserRepository : UserStore, IActorRepository<WAction>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private const string WORKFLOW_ACTION = "WorkflowAction";


        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<User> getUsers()
        {
            return _context.Users.Include(ur => ur.UserRoles).Where(c => c.OrganizationId == _context.userInfo.OrganizationId); ;
        }

        public User? getById(int id)
        {
            var users = _context.Users.AsQueryable();
            if (_context.userInfo.OrganizationId > 0)
            {
                users = users.Where(c => c.Id == id && c.OrganizationId == _context.userInfo.OrganizationId).Include(ur => ur.UserRoles);
            }
            return users.FirstOrDefault();
        }
        public List<WAction> getActions(int userid)
        {
            var actors = _context.Actors.Where(a => a.ActorId == userid && a.ActorType == "Customer" && a.OwnerType == WORKFLOW_ACTION).ToList();
            var workflowActions = new List<WAction>();
            actors.ForEach(actor =>
            {
                var action = _context.WActions.FirstOrDefault(a => a.Id == actor.OwnerId && a.StatusId <= StatusEnum.New);
                if (action is not null)
                    workflowActions.Add(action);
            });

            return workflowActions;
        }

        public string GetActorType(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user is null ? "" : user.FirstName + " " + user.LastName;
        }

    }
}
