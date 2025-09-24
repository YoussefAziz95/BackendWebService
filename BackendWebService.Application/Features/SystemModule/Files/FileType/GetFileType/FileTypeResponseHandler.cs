using Application.Contracts.Features;
using Application.Contracts.Persistence;
using Application.Wrappers;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Features;
internal class FileTypeResponseHandler(IUnitOfWork unitOfWork) : ResponseHandler, IRequestHandler<FileTypeRequest, FileTypeResponse>
{
 
    public IResponse<FileTypeResponse> Handle(FileTypeRequest request)
    {
        var entity = unitOfWork.GenericRepository<FileType>().Get();

        var result = FileTypeResponse.FromEntity(entity);

        return Success(result);
    }
}