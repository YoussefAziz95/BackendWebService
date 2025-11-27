using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ClientAccountResponseHandler : ResponseHandler, IRequestByIdHandler<ClientAccountResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientAccountResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientAccountResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<ClientAccount>().GetById(id);

        var result = ClientAccountResponse.FromEntity(entity);

        return Success(result);
    }   
}

