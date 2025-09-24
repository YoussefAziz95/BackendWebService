using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ClientPropertyResponseHandler : ResponseHandler, IRequestHandler<ClientPropertyRequest, ClientPropertyResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientPropertyResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientPropertyResponse> Handle(ClientPropertyRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ClientProperty>().Get();

        var result = ClientPropertyResponse.FromEntity(entity);

        return Success(result);
    }
}

