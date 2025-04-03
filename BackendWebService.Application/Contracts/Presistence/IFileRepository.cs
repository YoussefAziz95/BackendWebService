using Application.DTOs.Utility;
using Domain;


namespace Application.Contracts.Persistence
{
    public interface IFileRepository
    {
        FileLog Upload(UploadRequest request, string fullPath);
        FileResponse GetFile(int id);

    }
}
