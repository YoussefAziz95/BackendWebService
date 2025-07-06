using Application.Features;
namespace Application.Contracts.Persistence;

public interface IFileRepository
{
    FileLog Upload(FileLog file);
    FileResponse GetFileResponse(string fileName);
    FileLog? GetFileById(string? fileName);
    bool Exists(string fileName);
    void Delete(string fileName);
}
