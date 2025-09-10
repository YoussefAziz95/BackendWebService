using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddPreDocumentRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddPreDocumentRequest, int>
{
    public IResponse<int> Handle(AddPreDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}