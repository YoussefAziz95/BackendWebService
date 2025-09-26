using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class FileLogResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileLogRequest, FileLogResponse>
{

    public IResponse<FileLogResponse> Handle(FileLogRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileLog>().Get();

        var result = FileLogResponse.FromEntity(entity);

        return Success(result);
    }
}