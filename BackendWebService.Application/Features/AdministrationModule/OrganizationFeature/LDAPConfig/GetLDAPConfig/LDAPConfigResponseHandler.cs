using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class LDAPConfigResponseHandler : ResponseHandler, IRequestHandler<LDAPConfigRequest, LDAPConfigResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public LDAPConfigResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<LDAPConfigResponse> Handle(LDAPConfigRequest request)
    {
        var entity = _unitOfWork.GenericRepository<LDAPConfig>().Get();

        var result = LDAPConfigResponse.FromEntity(entity);

        return Success(result);
    }
}

