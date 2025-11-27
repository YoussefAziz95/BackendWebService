using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AddressAllResponseHandler : ResponseHandler, IRequestHandler<AddressAllRequest, List<AddressAllResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressAllResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<List<AddressAllResponse>> Handle(AddressAllRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Address>().GetAll();

        var result = entity.Select(AddressAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

