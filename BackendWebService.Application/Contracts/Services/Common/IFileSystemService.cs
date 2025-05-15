using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs;
using Domain;

namespace Application.Contracts.Services;

public interface IFileSystemService
{
    Task<int> UploadFile(UploadRequest request, string folderName);
    FileResponse? DownloadFileResponse(string folderName);
    void DeleteFile(string folderName);
}
