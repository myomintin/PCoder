namespace PCodes.Core;

public class ImportSettings
{
    public int SheetIndex { get; set; }
    public int HeaderRow { get; set; }

    public HashSet<IndexProperty> ColumnMappings { get; set; }

    public ImportSettings()
    {
        ColumnMappings = [];
    }
}
