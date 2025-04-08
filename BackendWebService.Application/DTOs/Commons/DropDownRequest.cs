namespace Application.DTOs.Common;

public class DropDownRequest
{
    public required string tableName { get; set; }
    public required string[] columnNames { get; set; }

}

