using Application.Contracts.Features;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record FileLogRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId) : IRequest<FileLogResponse>
{
    public IValidator<FileLogRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<FileLogRequest> validator)
    {
        throw new NotImplementedException();
    }
}

