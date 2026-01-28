namespace PCodes.Core;

public static class CoreExtensions
{
    public static string? Combine(this string separator, IEnumerable<string> values)
    {
        if (values is null)
        {
            return null;
        }

        string text = string.Join(separator, values.Where(m => !string.IsNullOrEmpty(m)));
        if (!string.IsNullOrEmpty(text))
        {
            return text;
        }

        return null;
    }

    public static string? Combine(this string separator, params string[] values)
    {
        return Combine(separator, values.AsEnumerable());
    }

    public static string? Combine(this string separator, IEnumerable<char> values)
    {
        if (values is null)
        {
            return null;
        }

        string text = string.Join(separator, values.Select(m => m));
        if (!string.IsNullOrEmpty(text))
        {
            return text;
        }

        return null;
    }

    public static string? Combine(this string separator, params char[] values)
    {
        return Combine(separator, values.AsEnumerable());
    }

    public static List<Exception> GetAllExceptions(this Exception ex, bool reverse = false)
    {
        List<Exception> list = [];
        for (Exception? ex2 = ex; ex2 != null; ex2 = ex2?.InnerException)
        {
            if (ex2 is not null)
            {
                list.Add(ex2);
            }
        }
        if (reverse)
        {
            list.Reverse();
        }

        return list;
    }

    public static string? ToString(this DateTime? value, string format)
    {
        if (value.HasValue)
        {
            return value.Value.ToString(format);
        }

        return null;
    }

    public static string? ConvertToString(this object value)
    {
        return value?.ToString();
    }

    public static string? XTrim(this string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return value.Trim();
        }

        return null;
    }

    public static bool FromActiveToBoolean(this string? value)
    {
        string? v = value.XTrim();
        if (string.IsNullOrWhiteSpace(v))
        {
            return false;
        }

        return v.Equals("active", StringComparison.InvariantCultureIgnoreCase);
    }
}
