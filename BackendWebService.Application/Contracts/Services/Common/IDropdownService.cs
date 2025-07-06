using Application.Contracts.Features;
using Application.Features;
namespace Application.Contracts.Services;
public interface IDropdownService
{
    Task<IResponse<DropDownResponse>> GetDropdownOptions(string tableName, string[] columnNames);
}

