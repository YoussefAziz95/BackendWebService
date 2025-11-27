using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ClientServiceResponseHandler : ResponseHandler, IRequestByIdHandler<ClientServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientServiceResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientServiceResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<ClientService>().GetById(id);

        var result = ClientServiceResponse.FromEntity(entity);

        return Success(result);
    }
}

