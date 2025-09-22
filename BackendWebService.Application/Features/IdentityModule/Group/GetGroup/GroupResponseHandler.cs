using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class GroupResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<GroupRequest, GroupResponse>
{
 
    public IResponse<GroupResponse> Handle(GroupRequest request)
    {
        var entity = unitOfWork.GenericRepository<Group>().Get();

        var result = GroupResponse.FromEntity(entity);

        return Success(result);
    }
}