using Application.DTOs;
using Domain;

namespace Application.Contracts.Persistences;

public interface IFileRepository
{
    FileLog Upload(UploadRequest request, string fullPath);
    FileResponse GetFileResponse(int id);
    FileLog GetFile(int id);
    void Delete(FileLog file);
}
