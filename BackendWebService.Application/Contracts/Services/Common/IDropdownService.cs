using Application.Contracts.Features;
using Application.Features.Common;

namespace Application.Contracts.Services;
public interface IDropdownService
{
    Task<IResponse<DropDownResponse>> GetDropdownOptions(string tableName, string[] columnNames);
}

