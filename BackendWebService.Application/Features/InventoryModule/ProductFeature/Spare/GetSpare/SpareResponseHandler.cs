using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class SpareResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<SpareResponse>
{

    public IResponse<SpareResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<Spare>().GetById(id);

        var result = SpareResponse.FromEntity(entity);

        return Success(result);
    }
}