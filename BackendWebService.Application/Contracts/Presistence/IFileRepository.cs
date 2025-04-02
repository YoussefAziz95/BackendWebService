using Application.DTOs.Utility;


namespace Application.Contracts.Presistence
{
    public interface IFileRepository
    {
        FileLog Upload(UploadRequest request, string fullPath);
        FileResponse GetFile(int id);

    }
}
