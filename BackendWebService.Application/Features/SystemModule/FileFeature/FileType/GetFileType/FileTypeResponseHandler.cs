using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;

namespace Application.Features;
public class FileTypeResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestByIdHandler<FileTypeResponse>
{

    public IResponse<FileTypeResponse> Handle(int id)
    {
        var entity = unitOfWork.GenericRepository<FileType>().GetById(id);

        var result = FileTypeResponse.FromEntity(entity);

        return Success(result);
    }
}