using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Utility;

namespace Application.Contracts.Services;

public interface IFileSystemService
{
    Task<IResponse<int>> UploadFile(UploadRequest request, string folderName);
    IResponse<DownloadResponse> DownloadFile(int id);
    DownloadResponse DownloadFileResponse(int id);
    IResponse<string> DeleteFile(DeleteRequest request);
}
