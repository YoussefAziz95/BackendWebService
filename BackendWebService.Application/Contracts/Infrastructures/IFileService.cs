using Microsoft.AspNetCore.Http;

namespace Application.Contracts.Infrastructures;
public interface IFileService
{
    Task<string> Upload(IFormFile file, string uploadDir);
    void Delete(string path);
    bool Move(string filePath, string newPath);
    bool Exists(string path);
    string DownloadFile(string fullPath);
    string GetFile(string fileName);
}
