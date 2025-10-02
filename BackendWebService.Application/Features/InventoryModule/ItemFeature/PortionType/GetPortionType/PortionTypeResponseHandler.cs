using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PortionTypeResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<PortionTypeResponse>
{

    public IResponse<PortionTypeResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<PortionType>().GetById(id);

        var result = PortionTypeResponse.FromEntity(entity);

        return Success(result);
    }
}