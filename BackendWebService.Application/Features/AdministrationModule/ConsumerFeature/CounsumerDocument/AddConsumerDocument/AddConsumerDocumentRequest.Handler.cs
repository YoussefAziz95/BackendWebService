using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class AddConsumerDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddConsumerDocumentRequest, int>
{
    public IResponse<int> Handle(AddConsumerDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}