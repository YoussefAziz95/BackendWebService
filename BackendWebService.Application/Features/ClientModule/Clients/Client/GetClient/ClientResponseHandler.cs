using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ClientResponseHandler : ResponseHandler, IRequestHandler<ClientRequest, ClientResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientResponse> Handle(ClientRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Client>().Get();

        var result = ClientResponse.FromEntity(entity);

        return Success(result);
    }
}

