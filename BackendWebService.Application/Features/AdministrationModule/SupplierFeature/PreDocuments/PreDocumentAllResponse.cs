using Domain;
using Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace Application.Features;
public record PreDocumentAllResponse(
   string Name,
    bool IsRequired,
    bool IsMultiple,
    bool IsLocal,
    int FileTypeId
 );
