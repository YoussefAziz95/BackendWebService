using Application.Contracts.DTOs;
using Application.DTOs.Common;
using System;
using System.Threading.Tasks;


namespace Application.Contracts.Services
{
    /// <summary>
    /// Defines operations for retrieving dropdown options.
    /// </summary>
    public interface IDropdownService
    {
        /// <summary>
        /// Retrieves dropdown options asynchronously based on the specified table name and column names.
        /// </summary>
        /// <param name="tableName">The name of the table from which to retrieve dropdown options.</param>
        /// <param name="columnNames">An array of column names whose values will be used for dropdown options.</param>
        /// <param name="userType">The type of user for which to retrieve dropdown options. Default is "Companies".</param>
        /// <returns>A task representing the asynchronous operation, containing the response with dropdown options.</returns>
        Task<IResponse<DropDownResponse>> GetDropdownOptions(string tableName, string[] columnNames);
    }
}

