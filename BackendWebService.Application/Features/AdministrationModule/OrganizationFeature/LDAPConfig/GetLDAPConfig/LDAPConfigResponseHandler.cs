using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class LDAPConfigResponseHandler : ResponseHandler, IRequestByIdHandler<LDAPConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public LDAPConfigResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<LDAPConfigResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<LDAPConfig>().GetById(id);

        var result = LDAPConfigResponse.FromEntity(entity);

        return Success(result);
    }
}

