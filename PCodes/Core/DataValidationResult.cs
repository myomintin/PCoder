using System.ComponentModel.DataAnnotations;

namespace PCodes.Core;

public class DataValidationResult
{
    public int Row { get; set; }
    public bool IsValid { get; set; }
    public List<ValidationResult> Results { get; set; }

    public DataValidationResult()
    {
        Results = [];
    }

    public string? GetMessage()
    {
        IEnumerable<string> query = from x in Results
                                    where !string.IsNullOrEmpty(x.ErrorMessage)
                                    select x.ErrorMessage;

        return ", ".Combine(query);
    }
}
