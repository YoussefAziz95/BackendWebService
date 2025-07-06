using Application.Contracts;
using Application.Contracts.Persistence;
using Domain;
using Domain.Enums;
using Persistence.Data;
using Persistence.Repositories.Common;


namespace Persistence.Repositories.Workflows
{
    public class CaseRepository : GenericRepository<Case>, ICaseRepository
    {
        private IWorkflowReviewRepositoryFactory<Case, WorkflowCycle> _actionObjectRepositoryFactory;
        private IWorkflowRepository _workflowRepository;
        private readonly ApplicationDbContext _context;

        public CaseRepository(ApplicationDbContext context,
            IWorkflowRepository workflowRepository) : base(context)
        {
            _workflowRepository = workflowRepository;
            _context = context;
        }

        public Case OpenCase(int workflowId, int companySupplierId)
        {

            Workflow workflow = _workflowRepository.GetById(workflowId);
            var wcase = new Case()
            {
                CompanySupplierId = _context.userInfo.OrganizationId ?? 0,
                OrganizationId = _context.Set<Company>().Where(o => o.Id == workflow.CompanyId).Select(o => o.OrganizationId).First(),
                StatusId = (int)StatusEnum.New,
                UserId = (int)_context.userInfo.UserId,
                WorkflowId = workflow.Id,
                ActionIndex = 1,
            };
            _context.Add(wcase);
            _context.SaveChanges();

            return wcase;

        }
    }
}

