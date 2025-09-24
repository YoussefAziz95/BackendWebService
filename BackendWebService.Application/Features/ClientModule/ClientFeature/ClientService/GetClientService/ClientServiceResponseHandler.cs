using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ClientServiceResponseHandler : ResponseHandler, IRequestHandler<ClientServiceRequest, ClientServiceResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientServiceResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientServiceResponse> Handle(ClientServiceRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ClientService>().Get();

        var result = ClientServiceResponse.FromEntity(entity);

        return Success(result);
    }
}

