using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PortionResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<PortionResponse>
{

    public IResponse<PortionResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Portion>().GetById(id);

        var result = PortionResponse.FromEntity(entity);

        return Success(result);
    }
}