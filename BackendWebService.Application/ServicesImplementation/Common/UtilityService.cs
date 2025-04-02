using Application.Contracts.Infrastructure;
using Application.Contracts.Services;
using Application.DTOs.Common;
using Application.DTOs.Utility;
using Application.Model.File;
using Domain.Constants;
using Application.Wrappers;
using Application.Contracts.DTOs;

namespace Application.Implementations.Common
{
    public sealed class UtilityService : ResponseHandler, IUtilityService
    {
        private readonly IFileHandler _fileHandler;
        public UtilityService(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }
        public IResponse<DownloadResponse> DownloadFile(string fileName)
        {
            var path = _fileHandler.GetFile(fileName);
            if (path == null)
                return NotFound<DownloadResponse>();

            var response = new DownloadResponse()
            {
                FileName = fileName,
                FilePath = path,
                MimeType = MimeTypes.GetContentType(fileName)
            };

            return Success(response);
        }

        public async Task<IResponse<string>> UploadFile(UploadRequest request)
        {
            var fileName = await _fileHandler.Upload(request.File, $"{AppConstants.TempUploadPath}");

            return Uploaded(entity: fileName);
        }
        public IResponse<string> DeleteFile(DeleteRequest request)
        {
            _fileHandler.Delete(request.FileName);

            return Deleted<string>();
        }
    }
}