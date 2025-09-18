using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record AttachmentAllRequest(
int EmailId,
int FileId,
int FileFieldValidatorId,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<AttachmentAllResponse>>
{
    public IValidator<AttachmentAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<AttachmentAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

