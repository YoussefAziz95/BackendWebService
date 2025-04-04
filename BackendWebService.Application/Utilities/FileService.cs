using Application.Contracts.Infrastructures;
using Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Application.Utilities
{
    /// <summary>
    /// Provides utility methods for handling files.
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        /// Uploads a file to the specified directory.
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <param name="uploadDir">The directory where the file will be uploaded.</param>
        /// <returns>The path of the uploaded file.</returns>
        public async Task<string> Upload(IFormFile file, string uploadDir)
        {
            // Get the file's extension
            var fileExtension = Path.GetExtension(file.FileName);

            // Generate a new unique name using the current datetime
            var uniqueFileName = $"{DateTime.Now.ToString("yyyyMMddHHmmss")}{fileExtension}";

            // Define the path where the file will be saved
            var path = Path.Combine(uploadDir);

            // Check if directory exists
            if (!Directory.Exists(path))
            {
                // Create directory
                Directory.CreateDirectory(path);
            }

            // Create the file path with the unique file name
            var filePath = Path.Combine(path, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        /// <summary>
        /// Deletes a file.
        /// </summary>
        /// <param name="path">The path of the file to delete.</param>
        public void Delete(string path)
        {
            // Check if the file exists
            if (Exists(path))
                File.Delete(path);
        }

        /// <summary>
        /// Moves a file to a new location.
        /// </summary>
        /// <param name="filePath">The path of the file to move.</param>
        /// <param name="newPath">The new path where the file will be moved.</param>
        /// <returns>True if the file is moved successfully; otherwise, false.</returns>
        public bool Move(string filePath, string newPath)
        {
            if (Exists($"{filePath}") && !Exists($"{newPath}"))
            {
                if (!Directory.Exists(newPath.Substring(0, newPath.LastIndexOf('\\'))))
                    Directory.CreateDirectory(newPath.Substring(0, newPath.LastIndexOf('\\')));

                // To move a file or folder to a new location:
                File.Move($"{filePath}", $"{newPath}");
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a file exists.
        /// </summary>
        /// <param name="path">The path of the file to check.</param>
        /// <returns>True if the file exists; otherwise, false.</returns>
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Gets the path of a file with the specified file name.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The path of the file if found; otherwise, null.</returns>
        public string DownloadFile(string FullPath)
        {
            string directoryPath = Path.GetDirectoryName(FullPath);
            string fileName = Path.GetFileName(FullPath);

            string[] files = Directory.GetFiles(directoryPath, fileName, SearchOption.AllDirectories);

            if (files.Length == 0)
                return null!;

            return files.FirstOrDefault()!;
        }

        public string GetFile(string fileName)
        {
            string[] files = Directory.GetFiles(AppConstants.WWWRoot, fileName, SearchOption.AllDirectories);

            if (files.Length == 0)
                return null!;

            return files.FirstOrDefault()!;
        }
    }
}
