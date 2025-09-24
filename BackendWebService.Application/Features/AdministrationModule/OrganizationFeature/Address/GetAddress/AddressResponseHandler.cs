using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class AddressResponseHandler : ResponseHandler, IRequestHandler<AddressRequest, AddressResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<AddressResponse> Handle(AddressRequest request)
    {
        var entity = _unitOfWork.GenericRepository<Address>().Get();

        var result = AddressResponse.FromEntity(entity);

        return Success(result);
    }
}

