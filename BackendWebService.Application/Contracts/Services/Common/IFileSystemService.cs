using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs;
using Domain;

namespace Application.Contracts.Services;

public interface IFileSystemService
{
    Task<IResponse<int>> UploadFile(UploadRequest request, string folderName);
    IResponse<DownloadResponse> DownloadFile(int id);
    DownloadResponse DownloadFileResponse(int? id);
    IResponse<string> DeleteFile(DeleteRequest request);
    IResponse<string> DeleteFileById(int? id);
    FileLog? GetFileById(int? id);
}
