using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class CompanyCategoryResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<CompanyCategoryResponse>
{
    public IResponse<CompanyCategoryResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<CompanyCategory>().GetById(id);

        var result = CompanyCategoryResponse.FromEntity(entity);

        return Success(result);
    }
}

