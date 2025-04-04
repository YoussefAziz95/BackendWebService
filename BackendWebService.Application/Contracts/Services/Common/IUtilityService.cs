using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Utility;

namespace Application.Contracts.Services;

public interface IUtilityService
{
    Task<IResponse<string>> UploadFile(UploadRequest request);

    IResponse<DownloadResponse> DownloadFile(string fileName);

    IResponse<string> DeleteFile(DeleteRequest request);
}
