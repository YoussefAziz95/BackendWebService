using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;

public class AddJobVerificationRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddJobVerificationRequest, int>
{
    public IResponse<int> Handle(AddJobVerificationRequest request)
    {
        throw new NotImplementedException();
    }
}