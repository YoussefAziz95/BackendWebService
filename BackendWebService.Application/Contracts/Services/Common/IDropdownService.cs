using Application.Contracts.DTOs;
using Application.DTOs.Common;

namespace Application.Contracts.Services;
public interface IDropdownService
{
    Task<IResponse<DropDownResponse>> GetDropdownOptions(string tableName, string[] columnNames);
}

