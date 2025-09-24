using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddFileLogRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddFileLogRequest, int>
{
    public IResponse<int> Handle(AddFileLogRequest request)
    {
        throw new NotImplementedException();
    }
}