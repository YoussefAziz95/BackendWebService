using Application.Contracts.Features;
using Application.Profiles;
using Domain;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;

public record AddFileLogRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
AddFileTypeRequest FileType) : IConvertibleToEntity<FileLog>, IRequest<int>
{
    public FileLog ToEntity() => new FileLog
    {
        FileName = FileName,
        FullPath = FullPath,
        Extention = Extention,
        FileTypeId = FileTypeId,
        FileType = FileType.ToEntity()
    };
}