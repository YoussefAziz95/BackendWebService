using Application.Contracts.DTOs;
using Application.DTOs.Common;
using Application.DTOs.Utility;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    /// <summary>
    /// Interface for utility services.
    /// </summary>
    public interface IUtilityService
    {
        /// <summary>
        /// Uploads a file asynchronously.
        /// </summary>
        /// <param name="request">The request containing file upload details.</param>
        /// <returns>A response indicating the result of the upload operation.</returns>
        Task<IResponse<string>> UploadFile(UploadRequest request);

        /// <summary>
        /// Downloads a file asynchronously.
        /// </summary>
        /// <param name="fileName">The name of the file to download.</param>
        /// <returns>A response containing the download response.</returns>
        IResponse<DownloadResponse> DownloadFile(string fileName);

        /// <summary>
        /// Deletes a file asynchronously.
        /// </summary>
        /// <param name="request">The request containing file deletion details.</param>
        /// <returns>A response indicating the result of the deletion operation.</returns>
        IResponse<string> DeleteFile(DeleteRequest request);
    }
}
