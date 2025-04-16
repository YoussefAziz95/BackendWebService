using Application.DTOs;
using Domain;

namespace Application.Contracts.Persistences;

public interface IFileRepository
{
    FileLog Upload(UploadRequest request, string fullPath);
    FileResponse GetFile(int id);

}
