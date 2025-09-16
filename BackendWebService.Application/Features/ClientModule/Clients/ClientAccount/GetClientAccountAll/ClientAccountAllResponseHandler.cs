using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class ClientAccountAllResponseHandler : ResponseHandler, IRequestHandler<ClientAccountAllRequest, List<ClientAccountAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientAccountAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ClientAccountAllResponse>> Handle(ClientAccountAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ClientAccount>().GetAll();

        var result = entity.Select(ClientAccountAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

