using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class LDAPConfigAllResponseHandler : ResponseHandler, IRequestHandler<LDAPConfigAllRequest, List<LDAPConfigAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public LDAPConfigAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<LDAPConfigAllResponse>> Handle(LDAPConfigAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<LDAPConfig>().GetAll();

        var result = entity.Select(LDAPConfigAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

