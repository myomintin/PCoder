using PCodes.Core;
using System.Data;

namespace PCodes.Data;

public static class DataExtensions
{
    public static DateTime? GetNullabeDateTime(this DataRow row, int columnIndex)
    {
        DateTime? value = null;
        try
        {
            value = row.Field<DateTime?>(columnIndex);

            return value;
        }
        catch
        { }

        return value;
    }

    public static double? GetNullableDouble(this DataRow row, int columnIndex)
    {
        double? value = null;
        try
        {
            value = row.Field<double?>(columnIndex);

            return value;
        }
        catch
        { }

        return value;
    }

    public static string GetString(this DataRow row, int columnIndex)
    {
        string? value = null;
        try
        {
            value = row.Field<string?>(columnIndex).XTrim();
        }
        catch
        { }

        return value ?? string.Empty;
    }

    public static string? GetNullabeString(this DataRow row, int columnIndex)
    {
        string? value = null;
        try
        {
            value = row.Field<string?>(columnIndex).XTrim();
        }
        catch
        { }

        return value;
    }
}
