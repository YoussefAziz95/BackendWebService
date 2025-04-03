using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;


namespace Application.Contracts.Infrastructure;

/// <summary>
/// Defines operations for handling files, such as uploading, deleting, moving, and checking file existence.
/// </summary>
public interface IFileService
{
    /// <summary>
    /// Uploads a file to the specified directory.
    /// </summary>
    /// <param name="file">The file to upload.</param>
    /// <param name="uploadDir">The directory where the file will be uploaded.</param>
    /// <returns>A task representing the asynchronous operation, returning the path to the uploaded file.</returns>
    Task<string> Upload(IFormFile file, string uploadDir);

    /// <summary>
    /// Deletes the file at the specified path.
    /// </summary>
    /// <param name="path">The path of the file to delete.</param>
    void Delete(string path);

    /// <summary>
    /// Moves a file from one location to another.
    /// </summary>
    /// <param name="filePath">The current path of the file.</param>
    /// <param name="newPath">The new path where the file will be moved.</param>
    /// <returns>True if the file was successfully moved; otherwise, false.</returns>
    bool Move(string filePath, string newPath);

    /// <summary>
    /// Checks whether a file exists at the specified path.
    /// </summary>
    /// <param name="path">The path of the file to check.</param>
    /// <returns>True if the file exists; otherwise, false.</returns>
    bool Exists(string path);

    /// <summary>
    /// Retrieves the file at the specified file name.
    /// </summary>
    /// <param name="fileName">The name of the file to retrieve.</param>
    /// <returns>The file content as a string.</returns>
    string DownloadFile(string fullPath);
    string GetFile(string fileName);

}
