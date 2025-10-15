using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class FileFieldValidatorResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<FileFieldValidatorResponse>
{

    public IResponse<FileFieldValidatorResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<FileFieldValidator>().GetById(id);

        var result = FileFieldValidatorResponse.FromEntity(entity);

        return Success(result);
    }
}