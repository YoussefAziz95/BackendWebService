using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ClientServiceAllResponseHandler : ResponseHandler, IRequestHandler<ClientServiceAllRequest, List<ClientServiceAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientServiceAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ClientServiceAllResponse>> Handle(ClientServiceAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ClientService>().GetAll();

        var result = entity.Select(ClientServiceAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

