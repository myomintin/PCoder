using ClosedXML.Excel;
using System.ComponentModel;
using System.Data;
using System.Reflection;

namespace PCoder.Core;

public static class ClosedXMLExtensions
{
    public static XLWorkbook Write<T>(this IEnumerable<T> list, string worksheetName,
        int row, int column, XLTableTheme theme)
    {
        using XLWorkbook workbook = new();
        workbook.AddWorksheet(worksheetName)
            .Cell(row, column)
            .InsertTable(list)
            .Theme = theme;

        return workbook;
    }

    public static XLWorkbook? GetXLWorkbook(string? filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            return null;
        }

        return new XLWorkbook(filePath);
    }

    public static IXLWorksheet? GetXLWorksheet(this XLWorkbook? workbook, int sheetIndex = 1)
    {
        if (workbook is null || sheetIndex < 1)
        {
            return null;
        }

        return workbook.Worksheets.ElementAtOrDefault(sheetIndex - 1);
    }

    public static IXLWorksheet? GetXLWorksheet(this XLWorkbook? workbook, string name)
    {
        if (workbook is null)
        {
            return null;
        }

        if (!workbook.TryGetWorksheet(name, out var worksheet))
        {
            return null;
        }

        return worksheet;
    }

    public static DataTable? GetDataTable(this XLWorkbook? workbook, int sheetIndex = 1)
    {
        if (workbook is null)
        {
            return null;
        }

        IXLWorksheet? worksheet = GetXLWorksheet(workbook, sheetIndex);
        if (worksheet == null)
        {
            return null;
        }

        if (worksheet.Tables.Any())
        {
            return worksheet.Table(0).AsNativeDataTable();
        }

        return GetDataTable(worksheet);
    }

    public static DataTable? GetDataTable(this XLWorkbook? workbook, string name)
    {
        return GetDataTable(GetXLWorksheet(workbook, name));
    }

    public static DataTable? GetDataTable(this IXLWorksheet? worksheet)
    {
        if (worksheet is null)
        {
            return null;
        }

        worksheet.AutoFilter.Clear();
        IXLRange rangeUsed = worksheet.RangeUsed();
        if (rangeUsed is null || rangeUsed.RowCount() == 0)
        {
            return null;
        }

        try
        {
            return rangeUsed.AsTable().AsNativeDataTable();
        }
        catch
        { }

        return null;
    }

    public static IEnumerable<string>? GetWorksheetNames(this XLWorkbook? workbook)
    {
        if (workbook is null)
        {
            return new List<string>().AsEnumerable();
        }

        return workbook.Worksheets.Select(x => x.Name);
    }

    public static DataTable? ToDataTable(this IXLTable? table, int headerRow = 0)
    {
        if (table is null || headerRow >= table.RowCount())
        {
            return null;
        }

        table.AutoFilter.Clear();
        DataTable dataTable = new(table.Name);
        foreach (IXLTableField item in table.Fields.Cast<IXLTableField>())
        {
            Type typeFromHandle = typeof(object);
            if (item.IsConsistentDataType())
            {
                switch (item.Column.Cells().Skip(headerRow).First()
                    .DataType)
                {
                    case XLDataType.Text:
                        typeFromHandle = typeof(string);
                        break;
                    case XLDataType.Boolean:
                        typeFromHandle = typeof(bool);
                        break;
                    case XLDataType.DateTime:
                        typeFromHandle = typeof(DateTime);
                        break;
                    case XLDataType.TimeSpan:
                        typeFromHandle = typeof(TimeSpan);
                        break;
                    case XLDataType.Number:
                        typeFromHandle = typeof(double);
                        break;
                }
            }

            string columnName = ((headerRow > 0) ? item.Name : item.Column.ColumnLetter());
            int j = 1;
            while (dataTable.Columns.Contains(columnName))
            {
                columnName += $"_{j}";
                j++;
            }
            dataTable.Columns.Add(columnName, typeFromHandle);
        }

        foreach (IXLRangeRow item2 in table.Rows().Skip(headerRow))
        {
            DataRow dataRow = dataTable.NewRow();
            int i = 0;
            foreach (IXLCell cell in item2.Cells())
            {
                dataRow[i] = ToObject(cell);
                i++;
            }
            dataTable.Rows.Add(dataRow);
        }

        return dataTable;
    }

    public static DataTable AsDataTable(this IXLTable table)
    {
        DataTable dataTable = new(table.Name);
        foreach (IXLTableField item in table.Fields.Cast<IXLTableField>())
        {
            Type typeFromHandle = typeof(object);
            if (item.IsConsistentDataType())
            {
                switch (item.Column.Cells().Skip(table.ShowHeaderRow ? 1 : 0).First()
                    .DataType)
                {
                    case XLDataType.Text:
                        typeFromHandle = typeof(string);
                        break;
                    case XLDataType.Boolean:
                        typeFromHandle = typeof(bool);
                        break;
                    case XLDataType.DateTime:
                        typeFromHandle = typeof(DateTime);
                        break;
                    case XLDataType.TimeSpan:
                        typeFromHandle = typeof(TimeSpan);
                        break;
                    case XLDataType.Number:
                        typeFromHandle = typeof(double);
                        break;
                }
            }
            dataTable.Columns.Add(item.Name, typeFromHandle);
        }

        foreach (IXLTableRow item2 in table.DataRange.Rows())
        {
            DataRow dataRow = dataTable.NewRow();
            foreach (IXLTableField field in table.Fields)
            {
                dataRow[field.Name] = ToObject(item2.Cell(field.Index + 1).Value);
            }
            dataTable.Rows.Add(dataRow);
        }

        return dataTable;
    }

    public static object? ToObject(this IXLCell value)
    {
        return value.DataType switch
        {
            XLDataType.Blank => null,
            XLDataType.Boolean => value.GetBoolean(),
            XLDataType.Number => value.GetDouble(),
            XLDataType.Text => value.GetText(),
            XLDataType.Error => value.GetError(),
            XLDataType.DateTime => value.GetDateTime(),
            XLDataType.TimeSpan => value.GetTimeSpan(),
            _ => throw new InvalidCastException(),
        };
    }

    public static object? ToObject(this XLCellValue value)
    {
        return value.Type switch
        {
            XLDataType.Blank => null,
            XLDataType.Boolean => value.GetBoolean(),
            XLDataType.Number => value.GetNumber(),
            XLDataType.Text => value.GetText(),
            XLDataType.Error => value.GetError(),
            XLDataType.DateTime => value.GetDateTime(),
            XLDataType.TimeSpan => value.GetTimeSpan(),
            _ => throw new InvalidCastException(),
        };
    }

    public static DataTable? ToDataTable<T>(this IList<T> data)
    {
        if (data is null)
        {
            return null;
        }

        PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new();
        for (int j = 0; j < props.Count; j++)
        {
            PropertyDescriptor prop = props[j];
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }

        object?[] values = new object[props.Count];
        foreach (T item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }
            table.Rows.Add(values);
        }

        return table;
    }

    public static List<T>? ToList<T>(this DataTable dt)
    {
        if (dt is null)
        {
            return null;
        }

        List<T> data = [];
        foreach (DataRow row in dt.Rows)
        {
            T item = GetItem<T>(row);
            data.Add(item);
        }

        return data;
    }

    public static T GetItem<T>(DataRow dr)
    {
        Type temp = typeof(T);
        T obj = Activator.CreateInstance<T>();

        foreach (DataColumn column in dr.Table.Columns)
        {
            PropertyInfo[] properties = temp.GetProperties();
            foreach (PropertyInfo pro in properties)
            {
                if (pro.Name == column.ColumnName)
                {
                    pro.SetValue(obj, dr[column.ColumnName], null);
                }
            }
        }

        return obj;
    }
}
