using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ManagerResponseHandler : ResponseHandler, IRequestByIdHandler<ManagerResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ManagerResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ManagerResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Manager>().Get();

        var result = ManagerResponse.FromEntity(entity);

        return Success(result);
    }
}

