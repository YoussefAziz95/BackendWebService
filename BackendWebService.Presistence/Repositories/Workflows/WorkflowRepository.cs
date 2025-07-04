﻿using Application.Contracts;
using Application.Contracts.Persistence;
using Application.Features;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Repositories.Common;
using Persistence.Repositories.WorkflowReviewRepositories;

namespace Persistence.Repositories.Workflows
{
    public class WorkflowRepository : GenericRepository<Workflow>, IWorkflowRepository
    {
        private IWorkflowReviewRepositoryFactory<Case, WorkflowCycle> _actionObjectRepositoryFactory;
        private IActorRepositoryFactory<CaseAction> _actorRepositoryFactory;
        private const string WORKFLOW = "Workflow";
        private const string WORKFLOW_CYCLE = "WorkflowCycle";

        public WorkflowRepository(ApplicationDbContext context,
            IMapper mapper) : base(context)
        {

        }

        public async Task<int> AddWorkflowAsync(Workflow workflow, ActionObject actionObject, List<ActionObject> workflowActorObjects, List<Actor> workflowCycleActors)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    if (_context.Set<ActionObject>().
                        Any(wr => wr.ObjectId == actionObject.ObjectId
                        && wr.ObjectType == actionObject.ObjectType
                        && wr.ActionType == WORKFLOW))
                        throw new Exception(" Cannot Create workflow for " + actionObject.ObjectType + " " + actionObject.ObjectId);
                    _context.Add(workflow);
                    _context.SaveChanges();


                    _context.Update(workflow);


                    _context.SaveChanges();


                    actionObject.ActionId = workflow.Id;
                    actionObject.ActionType = WORKFLOW;



                    for (int i = 0; i < workflow.WorkflowCycles.Count; i++)
                    {
                        if (workflowActorObjects[i].ObjectId == 0 || workflowActorObjects[i].ObjectType == "")
                        {
                            workflowActorObjects[i].ObjectId = actionObject.ObjectId;
                            workflowActorObjects[i].ObjectType = actionObject.ObjectType;
                        }
                        workflowActorObjects[i].ActionId = workflow.WorkflowCycles[i].Id;
                        workflowActorObjects[i].ActionType = WORKFLOW_CYCLE;
                        workflowCycleActors[i].OwnerId = workflow.WorkflowCycles[i].Id;
                        workflowCycleActors[i].OwnerType = WORKFLOW_CYCLE;


                    }
                    _context.Add(actionObject);
                    _context.AddRange(workflowActorObjects);
                    _context.AddRange(workflowCycleActors);
                    result = _context.SaveChanges();

                    // Commit the transaction
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    throw ex;
                }
            }
            return workflow.Id;
        }

        public async Task<int> UpdateWorkflow(Workflow updatedWorkflow, ActionObject updatedWorkflowReview, List<ActionObject> workflowActorObjects, List<Actor> workflowCycleActors)
        {
            var result = -1;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Workflow workflow = GetById(updatedWorkflow.Id);
                    var actionObject = _context.Set<ActionObject>().First(r => r.ActionId == workflow.Id && r.ActionType == WORKFLOW);
                    actionObject.ObjectId = updatedWorkflowReview.ObjectId;
                    actionObject.ObjectType = updatedWorkflowReview.ObjectType;

                    workflow.WorkflowCycles.ToList().ForEach(c => c.IsDeleted = true);
                    int i = 0;
                    updatedWorkflow.WorkflowCycles.ToList().ForEach(updatedCycle =>
                    {
                        var cycle = workflow.WorkflowCycles.FirstOrDefault(t => t.Id == updatedCycle.Id && t.Id != 0);
                        if (cycle is not null)
                        {
                            var review = _context.Set<ActionObject>().FirstOrDefault(r => r.ActionId == cycle.Id && r.ActionType == WORKFLOW_CYCLE);
                            var actor = _context.Set<Actor>().FirstOrDefault(r => r.OwnerId == cycle.Id && r.OwnerType == WORKFLOW_CYCLE);
                            cycle.IsDeleted = false;
                            cycle.Mandatory = updatedCycle.Mandatory;
                            cycle.ActionOrder = updatedCycle.ActionOrder;
                            cycle.ActionType = updatedCycle.ActionType;
                            review.ObjectId = workflowActorObjects[i].ObjectId;
                            review.ObjectType = workflowActorObjects[i].ObjectType;
                            actor.ActorId = workflowCycleActors[i].ActorId;
                            actor.ActorType = workflowCycleActors[i].ActorType;
                            updatedCycle.Id = 0;
                            _context.Update(review);
                            _context.Update(actor);
                            _context.Update(cycle);
                            _context.SaveChanges();
                        }
                        else
                        {

                            updatedCycle.WorkflowId = workflow.Id;
                            _context.Add(updatedCycle);
                            _context.SaveChanges();
                            if (workflowActorObjects[i].ObjectId == 0 || workflowActorObjects[i].ObjectType == "")
                            {
                                workflowActorObjects[i].ObjectId = actionObject.ObjectId;
                                workflowActorObjects[i].ObjectType = actionObject.ObjectType;
                            }
                            workflowActorObjects[i].ActionId = updatedCycle.Id;
                            workflowActorObjects[i].ActionType = WORKFLOW_CYCLE;
                            workflowCycleActors[i].OwnerId = updatedCycle.Id;
                            workflowCycleActors[i].OwnerType = WORKFLOW_CYCLE;

                            _context.Add(workflowActorObjects[i]);
                            _context.Add(workflowCycleActors[i]);
                        }
                        i++;
                    });
                    foreach (var criteria in workflow.WorkflowCycles.Where(c => c.IsDeleted ?? true))
                    {
                        var review = _context.Set<ActionObject>().First(a => a.ActionId == criteria.Id && a.ActionType == WORKFLOW_CYCLE);
                        var actor = _context.Set<Actor>().First(a => a.OwnerId == criteria.Id && a.OwnerType == WORKFLOW_CYCLE);
                        _context.Remove(review);
                        _context.Remove(actor);
                        _context.Remove(criteria);
                    }


                    result = _context.SaveChanges();

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    return result;
                }
            }
            return updatedWorkflow.Id;
        }

        public List<WorkflowAllResponse> GetPaginated(GetPaginatedRequest request)
        {
            var workflowResponses = new List<WorkflowAllResponse>();
            var workflows = _context.Set<Workflow>()
                .Select(w => new { w.Id, w.Name, w.Description });
            foreach (var workflow in workflows)
            {

                var actionObject = _context.Set<ActionObject>().First(r => r.ActionId == workflow.Id && r.ActionType == WORKFLOW);
                _actionObjectRepositoryFactory = new WorkflowReviewRepositoryFactory<Case, WorkflowCycle>(_context, actionObject.ObjectType);

                var workflowResponse = new WorkflowAllResponse(
                    Id: workflow.Id,
                    Name: workflow.Name,
                    Description: workflow.Name,
                    WorkflowType: actionObject.ObjectType,
                    ObjectType: _actionObjectRepositoryFactory.GetObjectType(actionObject.ObjectId)

                );
                workflowResponses.Add(workflowResponse);

            }

            return workflowResponses;
        }

        public Workflow GetById(int id)
        {
            var workflow = Get(b => b.Id == id,
                            b => b.Include(c => c.WorkflowCycles), disableTracking: false);

            return workflow;
        }

        public WorkflowResponse GetWorkflowById(int id)
        {

            var workflow = Get(w => w.Id == id, include: wc => wc.Include(c => c.WorkflowCycles ?? new List<WorkflowCycle>()));

            var actionObject = _context.Set<ActionObject>().First(r => r.ActionId == workflow.Id && r.ActionType == WORKFLOW);
            var workflowResponse = new WorkflowResponse(
                Id: workflow.Id,
                Name: workflow.Name,
                Description: workflow.Description,
                UserId: workflow.UserId,
                CompanyId: workflow.CompanyId,
                ObjectType: actionObject.ObjectType,
                ObjectId: actionObject.ObjectId,
                WorkflowCycles: workflow.WorkflowCycles.Select(c => new WorkflowCycleResponse(
                    Id: c.Id,
                    Mandatory: c.Mandatory,
                    WorkflowId: c.WorkflowId,
                    ActionOrder: c.ActionOrder,
                    ObjectType: _context.Set<ActionObject>().First(r => r.ActionId == c.Id && r.ActionType == WORKFLOW_CYCLE).ObjectType,
                    ObjectId: _context.Set<ActionObject>().First(r => r.ActionId == c.Id && r.ActionType == WORKFLOW_CYCLE).ObjectId,
                    ActorType: _context.Set<Actor>().First(a => a.OwnerId == c.Id && a.OwnerType == WORKFLOW_CYCLE).ActorType,
                    ActorId: _context.Set<Actor>().First(a => a.OwnerId == c.Id && a.OwnerType == WORKFLOW_CYCLE).ActorId,
                    ActionType: c.ActionType
                )).ToList()

            );

            return workflowResponse;
        }

    }
}
