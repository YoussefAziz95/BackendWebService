using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record FileLogAllRequest(
string FileName,
string FullPath,
string Extention,
int FileTypeId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<FileLogAllResponse>>
{
    public IValidator<FileLogAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<FileLogAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

