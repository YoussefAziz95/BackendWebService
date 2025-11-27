using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class FileLogResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<FileLogResponse>
{

    public IResponse<FileLogResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<FileLog>().GetById(id);

        var result = FileLogResponse.FromEntity(entity);

        return Success(result);
    }
}