using Application.Validators.Common;

namespace Application.DTOs.Common
{
    /// <summary>
    /// Request model for fetching dropdown options.
    /// </summary>
    public class DropDownRequest : BaseValidationModel<DropDownRequest>
    {
        /// <summary>
        /// Gets or sets the table name from which to fetch dropdown options.
        /// </summary>
        public required string tableName { get; set; }

        /// <summary>
        /// Gets or sets the column names to include in the dropdown options.
        /// </summary>
        public required string[] columnNames { get; set; }

    }
}

