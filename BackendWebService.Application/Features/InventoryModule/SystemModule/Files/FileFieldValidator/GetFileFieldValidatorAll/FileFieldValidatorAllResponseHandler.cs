using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class FileFieldValidatorAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileFieldValidatorAllRequest, List<FileFieldValidatorAllResponse>>
{
    public IResponse<List<FileFieldValidatorAllResponse>> Handle(FileFieldValidatorAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileFieldValidator>().GetAll();

        var result = entity.Select(FileFieldValidatorAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

