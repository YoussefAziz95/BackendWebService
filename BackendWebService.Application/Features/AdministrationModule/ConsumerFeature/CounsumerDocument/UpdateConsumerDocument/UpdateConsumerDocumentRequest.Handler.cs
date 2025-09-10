using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateConsumerDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateConsumerDocumentRequest, int>
{
    public IResponse<int> Handle(UpdateConsumerDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}