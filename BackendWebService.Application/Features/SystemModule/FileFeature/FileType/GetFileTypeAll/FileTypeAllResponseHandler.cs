using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class FileTypeAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileTypeAllRequest, List<FileTypeAllResponse>>
{
    public IResponse<List<FileTypeAllResponse>> Handle(FileTypeAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileType>().GetAll();

        var result = entity.Select(FileTypeAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

