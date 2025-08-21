using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record DealDocumentAllResponse(
int? Score,
string? Comment,
string? RichText,
int? StatusId,
int DealId,
int CriteriaId,
int FileId,
int FileFieldValidatorId,
Deal Deal,
Criteria Criteria,
FileLog File,
FileFieldValidator FileFieldValidator
 );
