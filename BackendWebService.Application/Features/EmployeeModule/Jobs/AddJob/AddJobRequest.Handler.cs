using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;

public class AddJobRequestHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<AddJobRequest, int>
{
    public IResponse<int> Handle(AddJobRequest request)
    {
        throw new NotImplementedException();
    }
}