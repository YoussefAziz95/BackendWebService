using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;

namespace Application.Features;
internal class FileTypeAllResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileTypeAllRequest, List<FileTypeAllResponse>>
{
    public IResponse<List<FileTypeAllResponse>> Handle(FileTypeAllRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileType>().GetAll();

        var result = entity.Select(FileTypeAllResponse.FromEntity).ToList();

        return Success(result);
    }
}

