using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddLoggingRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddLoggingRequest, int>
{
    public IResponse<int> Handle(AddLoggingRequest request)
    {
        throw new NotImplementedException();
    }
}