using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ClientResponseHandler : ResponseHandler, IRequestByIdHandler<ClientResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Client>().GetById(id);

        var result = ClientResponse.FromEntity(entity);

        return Success(result);
    }
}

