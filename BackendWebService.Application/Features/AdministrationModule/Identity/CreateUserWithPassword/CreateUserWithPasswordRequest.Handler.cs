using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class CreateUserWithPasswordRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<CreateUserWithPasswordRequest, int>
{
    public IResponse<int> Handle(CreateUserWithPasswordRequest request)
    {
        throw new NotImplementedException();
    }
}