using Application.DTOs;
using Domain;

namespace Application.Contracts.Persistences;

public interface IFileRepository
{
    FileLog Upload(FileLog file);
    FileResponse GetFileResponse(string fileName);
    FileLog? GetFileById(string? fileName);
    bool Exists(string fileName);
    void Delete(string fileName);
}
