using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class ClientPropertyResponseHandler : ResponseHandler, IRequestByIdHandler<ClientPropertyResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientPropertyResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<ClientPropertyResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<ClientProperty>().GetById(id);

        var result = ClientPropertyResponse.FromEntity(entity);

        return Success(result);
    }
}

