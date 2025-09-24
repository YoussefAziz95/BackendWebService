using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class PropertyResponseHandler : ResponseHandler, IRequestHandler<PropertyRequest, PropertyResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertyResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<PropertyResponse> Handle(PropertyRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Property>().Get();

        var result = PropertyResponse.FromEntity(entity);

        return Success(result);
    }
}

