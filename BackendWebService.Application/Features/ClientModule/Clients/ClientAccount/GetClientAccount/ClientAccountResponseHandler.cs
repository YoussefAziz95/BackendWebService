using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class ClientAccountResponseHandler : ResponseHandler, IRequestHandler<ClientAccountRequest, ClientAccountResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientAccountResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientAccountResponse> Handle(ClientAccountRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ClientAccount>().Get();

        var result = ClientAccountResponse.FromEntity(entity);

        return Success(result);
    }
}

