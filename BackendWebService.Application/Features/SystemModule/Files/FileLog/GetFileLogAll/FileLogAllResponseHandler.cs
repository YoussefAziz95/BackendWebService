using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
internal class FileLogAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileLogAllRequest, List<FileLogAllResponse>>
{
    public IResponse<List<FileLogAllResponse>> Handle(FileLogAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileLog>().GetAll();

        var result = entity.Select(FileLogAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

