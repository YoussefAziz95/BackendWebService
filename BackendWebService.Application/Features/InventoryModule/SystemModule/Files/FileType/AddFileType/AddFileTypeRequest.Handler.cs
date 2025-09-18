using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;


public class AddFileTypeRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddFileTypeRequest, int>
{
    public IResponse<int> Handle(AddFileTypeRequest request)
    {
        throw new NotImplementedException();
    }
}