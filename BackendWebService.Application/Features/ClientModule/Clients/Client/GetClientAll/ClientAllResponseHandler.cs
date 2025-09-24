using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class ClientAllResponseHandler : ResponseHandler, IRequestHandler<ClientAllRequest, List<ClientAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ClientAllResponse>> Handle(ClientAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Client>().GetAll();

        var result = entity.Select(ClientAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

