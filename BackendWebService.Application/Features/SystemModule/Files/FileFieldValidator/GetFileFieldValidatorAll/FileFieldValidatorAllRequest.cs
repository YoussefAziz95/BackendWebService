using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record FileFieldValidatorAllRequest(
int FileTypeId,
ValidatorEnum Validator,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<FileFieldValidatorAllResponse>>
{
    public IValidator<FileFieldValidatorAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<FileFieldValidatorAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

