using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
public class AddressResponseHandler : ResponseHandler, IRequestByIdHandler<AddressResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddressResponseHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IResponse<AddressResponse> Handle(int id)
    {
        var entity = _unitOfWork.GenericRepository<Address>().GetById(id);

        var result = AddressResponse.FromEntity(entity);

        return Success(result);
    }
}

