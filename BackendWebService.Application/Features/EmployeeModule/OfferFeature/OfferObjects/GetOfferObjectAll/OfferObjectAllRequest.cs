using Application.Contracts.Features;
using Domain.Enums;
using FluentValidation;
using SharedKernel.ValidationBase;

namespace Application.Features;
public record OfferObjectAllRequest(
int OfferId,
int ObjectId,
string Notes,
string ObjectType,
int PageNumber = 1,
int PageSize = 100,
string FilterBy = "none",
string? SortBy = "asc") : IRequest<List<OfferObjectAllResponse>>
{
    public IValidator<OfferObjectAllRequest> ValidateApplicationModel(ApplicationBaseValidationModelProvider<OfferObjectAllRequest> validator)
    {
        throw new NotImplementedException();
    }
}

