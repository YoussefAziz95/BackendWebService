using Application.Contracts;
using Application.Contracts.Persistence;
using Domain;
using Domain;
using Domain.Enums;
using Persistence.Data;
using Persistence.Repositories.Common;


namespace Persistence.Repositories.Workflows
{
    public class WorkflowCaseRepository : GenericRepository<WorkflowCase>, IWorkflowCaseRepository
    {
        private IWorkflowReviewRepositoryFactory<WorkflowCase, WorkflowCycle> _workflowReviewRepositoryFactory;
        private IWorkflowRepository _workflowRepository;
        private readonly ApplicationDbContext _context;

        public WorkflowCaseRepository(ApplicationDbContext context,
            IWorkflowRepository workflowRepository) : base(context)
        {
            _workflowRepository = workflowRepository;
            _context = context;
        }

        public WorkflowCase OpenCase(int workflowId, int companySupplierId)
        {

            Workflow workflow = _workflowRepository.GetById(workflowId);
            var workflowCase = new WorkflowCase()
            {
                CompanySupplierId = _context.userInfo.OrganizationId ?? 0,
                OrganizationId = _context.Set<Company>().Where(o => o.Id == workflow.CompanyId).Select(o => o.OrganizationId).First(),
                StatusId = (int)StatusEnum.New,
                UserId = (int)_context.userInfo.UserId,
                WorkflowId = workflow.Id,
                ActionIndex = 1,
            };
            _context.Add(workflowCase);
            _context.SaveChanges();

            return workflowCase;

        }
    }
}

