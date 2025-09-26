using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class FileFieldValidatorResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileFieldValidatorRequest, FileFieldValidatorResponse>
{

    public IResponse<FileFieldValidatorResponse> Handle(FileFieldValidatorRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileFieldValidator>().Get();

        var result = FileFieldValidatorResponse.FromEntity(entity);

        return Success(result);
    }
}