using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class GroupResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<GroupResponse>
{

    public IResponse<GroupResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Group>().GetById(id);

        var result = GroupResponse.FromEntity(entity);

        return Success(result);
    }
}