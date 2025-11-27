using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AdministratorResponseHandler : ResponseHandler, IRequestByIdHandler<AdministratorResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AdministratorResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<AdministratorResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Administrator>().GetById(id);

        var result = AdministratorResponse.FromEntity(entity);

        return Success(result);
    }
}

