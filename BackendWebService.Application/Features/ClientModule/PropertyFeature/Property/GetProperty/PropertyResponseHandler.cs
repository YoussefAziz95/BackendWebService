using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class PropertyResponseHandler : ResponseHandler, IRequestByIdHandler<PropertyResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public PropertyResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<PropertyResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Property>().GetById(id);

        var result = PropertyResponse.FromEntity(entity);

        return Success(result);
    }
}

