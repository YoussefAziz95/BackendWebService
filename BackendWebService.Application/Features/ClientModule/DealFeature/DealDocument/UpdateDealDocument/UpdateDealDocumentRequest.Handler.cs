using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateDealDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateDealDocumentRequest, int>
{
    public IResponse<int> Handle(UpdateDealDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}