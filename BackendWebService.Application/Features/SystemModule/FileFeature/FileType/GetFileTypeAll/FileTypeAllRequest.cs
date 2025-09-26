using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record FileTypeAllRequest(
FileTypeEnum Type,
string Extentions,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<FileTypeAllResponse>>
{
    public IValidator<FileTypeAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<FileTypeAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

