using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateActionObjectRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateActionObjectRequest, int>
{
    public IResponse<int> Handle(UpdateActionObjectRequest request)
    {
        throw new NotImplementedException();
    }
}