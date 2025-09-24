using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdatePreDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdatePreDocumentRequest, int>
{
    public IResponse<int> Handle(UpdatePreDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}