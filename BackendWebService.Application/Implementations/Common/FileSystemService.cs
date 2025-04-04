using Application.Contracts.DTOs;
using Application.Contracts.Infrastructures;
using Application.Contracts.Persistences;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Utility;
using Application.Model.File;
using Application.Wrappers;
using Domain.Constants;

namespace Application.Implementations.Common
{
    public class FileSystemService : ResponseHandler, IFileSystemService
    {
        private readonly IFileService _fileHandler;
        private readonly IFileRepository _fileRepository;

        public FileSystemService(IFileService fileHandler, IFileRepository fileRepository)
        {
            _fileHandler = fileHandler;
            _fileRepository = fileRepository;
        }
        public IResponse<string> DeleteFile(DeleteRequest request)
        {
            _fileHandler.Delete(request.FileName);

            return Deleted<string>();
        }

        public IResponse<DownloadResponse> DownloadFile(int id)
        {
            var response = DownloadFileResponse(id);
            return response is not null ? Success(response) : NotFound<DownloadResponse>();
        }
        public DownloadResponse DownloadFileResponse(int id)
        {
            var fileResponse = _fileRepository.GetFile(id);
            var path = _fileHandler.DownloadFile(fileResponse.FullPath);
            if (path == null)
                return null;

            var response = new DownloadResponse()
            {
                FileName = fileResponse.FullName,
                FilePath = path,
                MimeType = MimeTypes.GetContentType(fileResponse.FullName)
            };

            return response;
        }
        public async Task<IResponse<int>> UploadFile(UploadRequest request, string folderName)
        {
            var fileName = await _fileHandler.Upload(request.File, $"{AppConstants.TempUploadPath + "\\" + folderName + "\\" + folderName + "_" + request.Id + "_" + request.CreatedDate}");

            var result = _fileRepository.Upload(request, fileName);
            return Uploaded(entity: result.Id);
        }
    }
}
