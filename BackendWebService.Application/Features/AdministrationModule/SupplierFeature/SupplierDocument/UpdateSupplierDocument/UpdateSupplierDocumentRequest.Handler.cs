using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateSupplierDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateSupplierDocumentRequest, int>
{
    public IResponse<int> Handle(UpdateSupplierDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}