using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class UpdateJobRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<UpdateJobRequest, int>
{
    public IResponse<int> Handle(UpdateJobRequest request)
    {
        throw new NotImplementedException();
    }
}