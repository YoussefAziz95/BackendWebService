using Application.Contracts.DTOs;
using Application.DTOs;

namespace Application.Contracts.Services;

public interface IUtilityService
{
    Task<IResponse<string>> UploadFile(FileResponse request);

    IResponse<FileResponse> DownloadFile(string fileName);

    IResponse<string> DeleteFile(DeleteRequest request);
}
