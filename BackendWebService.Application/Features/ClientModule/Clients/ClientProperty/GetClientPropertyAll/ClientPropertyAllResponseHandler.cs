using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class ClientPropertyAllResponseHandler : ResponseHandler, IRequestHandler<ClientPropertyAllRequest, List<ClientPropertyAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientPropertyAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<ClientPropertyAllResponse>> Handle(ClientPropertyAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<ClientProperty>().GetAll();

        var result = entity.Select(ClientPropertyAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

