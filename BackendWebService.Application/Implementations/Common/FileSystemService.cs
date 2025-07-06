using Application.Contracts.Infrastructures;
using Application.Contracts.Persistence;
using Application.Contracts.Services;
using Application.Features;
using Application.Wrappers;
using Domain.Constants;
namespace Application.Implementations.Common
{
    public class FileSystemService : ResponseHandler, IFileSystemService
    {
        private readonly IFileHandler _fileService;
        private readonly IFileRepository _fileRepository;

        public FileSystemService(IFileHandler fileHandler, IFileRepository fileRepository)
        {
            _fileService = fileHandler;
            _fileRepository = fileRepository;
        }

        public void DeleteFile(string folderName)
        {
            _fileService.Delete(folderName);
            _fileRepository.Delete(folderName);
        }

        public FileResponse? DownloadFileResponse(string folderName)
        {
            //var fileString = _fileService.GetFile(folderName);
            var response = _fileRepository.GetFileResponse(folderName);
            return response;
        }


        public async Task<int> UploadFile(UploadRequest request, string folderName)
        {
            var fullPath = await _fileService.Upload(request.File, $"{AppConstants.TempUploadPath + "\\" + folderName}");
            var fileLog = new FileLog
            {
                FullPath = fullPath,
                FileName = Path.GetFileNameWithoutExtension(fullPath), // e.g., "document"
                Extention = Path.GetExtension(fullPath),               // e.g., ".pdf"
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };
            var result = _fileRepository.Upload(fileLog);
            return result.Id;
        }

    }
}
