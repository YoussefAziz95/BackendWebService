using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddDealDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddDealDocumentRequest, int>
{
    public IResponse<int> Handle(AddDealDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}