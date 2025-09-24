using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddSupplierDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddSupplierDocumentRequest, int>
{
    public IResponse<int> Handle(AddSupplierDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}