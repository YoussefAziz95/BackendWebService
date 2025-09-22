using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class PropertyAllResponseHandler : ResponseHandler, IRequestHandler<PropertyAllRequest, List<PropertyAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertyAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<PropertyAllResponse>> Handle(PropertyAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Property>().GetAll();

        var result = entity.Select(PropertyAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

