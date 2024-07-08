using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PCodes.Core;
using PCodes.Data;
using PCodes.Models;
using System.ComponentModel.DataAnnotations;

namespace PCoder.Core;

public static class AppHelper
{
    public static bool Upgrade(string filePath, Dictionary<string, ImportSettings?>? settings,
        DbContextOptions<ApplicationDbContext>? option, List<string>? messages)
    {
        messages ??= [];
        if (!File.Exists(filePath))
        {
            messages.Add("Error: " + filePath + " is not found");

            return false;
        }

        if (settings is null)
        {
            messages.Add("Error: Import Settings is null");

            return false;
        }

        if (option is null)
        {
            messages.Add("Error: DbContext Option is null");

            return false;
        }

        var stsetting = settings.FirstOrDefault(x => x.Key == "State");
        if (stsetting.Key == null || stsetting.Value == null)
        {
            messages.Add("Error: State Setting is null");

            return false;
        }

        var szsetting = settings.FirstOrDefault(x => x.Key == "SAD_SAZ");
        if (szsetting.Key == null || szsetting.Value == null)
        {
            messages.Add("Error: SAD or SAZ Setting is null");

            return false;
        }

        var dssetting = settings.FirstOrDefault(x => x.Key == "District");
        if (dssetting.Key == null || dssetting.Value == null)
        {
            messages.Add("Error: District Setting is null");

            return false;
        }

        var tssetting = settings.FirstOrDefault(x => x.Key == "Township");
        if (tssetting.Key == null || tssetting.Value == null)
        {
            messages.Add("Error: Township Setting is null");

            return false;
        }

        var tnsetting = settings.FirstOrDefault(x => x.Key == "Town");
        if (tnsetting.Key == null || tnsetting.Value == null)
        {
            messages.Add("Error: Town Setting is null");

            return false;
        }

        var wdsetting = settings.FirstOrDefault(x => x.Key == "Ward");
        if (wdsetting.Key == null || wdsetting.Value == null)
        {
            messages.Add("Error: Ward Setting is null");

            return false;
        }

        var vtsetting = settings.FirstOrDefault(x => x.Key == "VillageTract");
        if (vtsetting.Key == null || vtsetting.Value == null)
        {
            messages.Add("Error: Village Tract Setting is null");

            return false;
        }

        var vlsetting = settings.FirstOrDefault(x => x.Key == "Village");
        if (vlsetting.Key == null || vlsetting.Value == null)
        {
            messages.Add("Error: Village Setting is null");

            return false;
        }

        var workbook = ClosedXMLExtensions.GetXLWorkbook(filePath);
        if (workbook is null)
        {
            messages.Add("Error: Workbook is null");

            return false;
        }

        var sttable = workbook.GetDataTable(stsetting.Value.SheetIndex);
        if (sttable is null)
        {
            messages.Add("Error: Cannot extract State Data from the file");

            return false;
        }

        var sztable = workbook.GetDataTable(szsetting.Value.SheetIndex);
        if (sztable is null)
        {
            messages.Add("Error: Cannot extract SAD or SAZ Data from the file");

            return false;
        }

        var dstable = workbook.GetDataTable(dssetting.Value.SheetIndex);
        if (dstable is null)
        {
            messages.Add("Error: Cannot extract District Data from the file");

            return false;
        }

        var tstable = workbook.GetDataTable(tssetting.Value.SheetIndex);
        if (tstable is null)
        {
            messages.Add("Error: Cannot extract Township Data from the file");

            return false;
        }

        var tntable = workbook.GetDataTable(tnsetting.Value.SheetIndex);
        if (tntable is null)
        {
            messages.Add("Error: Cannot extract Town Data from the file");

            return false;
        }

        var wdtable = workbook.GetDataTable(wdsetting.Value.SheetIndex);
        if (wdtable is null)
        {
            messages.Add("Error: Cannot extract Ward Data from the file");

            return false;
        }

        var vttable = workbook.GetDataTable(vtsetting.Value.SheetIndex);
        if (vttable is null)
        {
            messages.Add("Error: Cannot extract Village Tract Data from the file");

            return false;
        }

        var vltable = workbook.GetDataTable(vlsetting.Value.SheetIndex);
        if (vltable is null)
        {
            messages.Add("Error: Cannot extract Village Data from the file");

            return false;
        }

        List<State> states = [];
        List<District> districts = [];
        List<Township> townships = [];
        List<Town> towns = [];
        List<Ward> wards = [];
        List<VillageTract> villageTracts = [];
        List<Village> villages = [];

        if (!sttable.TryParse(stsetting.Value.ColumnMappings, states))
        {
            messages.Add("Error: Cannot convert State Data");

            return false;
        }

        if (!dstable.TryParse(dssetting.Value.ColumnMappings, states, districts))
        {
            messages.Add("Error: Cannot convert District Data");

            return false;
        }

        if (!sztable.TryParseSADSAZ(szsetting.Value.ColumnMappings, states, districts))
        {
            messages.Add("Error: Cannot convert SAD or SAZ Data");

            return false;
        }

        if (!tstable.TryParse(tssetting.Value.ColumnMappings, states, districts, townships))
        {
            messages.Add("Error: Cannot convert Township Data");

            return false;
        }

        if (!tntable.TryParse(tnsetting.Value.ColumnMappings, states, districts, townships, towns))
        {
            messages.Add("Error: Cannot convert Town Data");

            return false;
        }

        if (!wdtable.TryParse(wdsetting.Value.ColumnMappings, states, districts, townships, towns, wards))
        {
            messages.Add("Error: Cannot convert Ward Data");

            return false;
        }

        if (!vttable.TryParse(vtsetting.Value.ColumnMappings, states, districts, townships, villageTracts))
        {
            messages.Add("Error: Cannot convert Village Tract Data");

            return false;
        }

        if (!vltable.TryParse(vlsetting.Value.ColumnMappings, states, districts, townships, villageTracts, villages))
        {
            messages.Add("Error: Cannot convert Village Data");

            return false;
        }

        List<DataValidationResult> stateVL = ValidateData(states);
        if (stateVL.Invalid())
        {
            messages.Add("Error: State Data Validation");
            messages.AddRange(stateVL.GetMessages());

            return false;
        }

        List<DataValidationResult> districtVL = ValidateData(districts);
        if (districtVL.Invalid())
        {
            messages.Add("Error: District Data Validation");
            messages.AddRange(districtVL.GetMessages());

            return false;
        }

        List<DataValidationResult> townshipVL = ValidateData(townships);
        if (townshipVL.Invalid())
        {
            messages.Add("Error: Township Data Validation");
            messages.AddRange(townshipVL.GetMessages());

            return false;
        }

        List<DataValidationResult> townVL = ValidateData(towns);
        if (townVL.Invalid())
        {
            messages.Add("Error: Town Data Validation");
            messages.AddRange(townVL.GetMessages());

            return false;
        }

        List<DataValidationResult> wardVL = ValidateData(wards);
        if (wardVL.Invalid())
        {
            messages.Add("Error: Ward Data Validation");
            messages.AddRange(wardVL.GetMessages());

            return false;
        }

        List<DataValidationResult> villageTractVL = ValidateData(villageTracts);
        if (villageTractVL.Invalid())
        {
            messages.Add("Error: Village Tract Data Validation");
            messages.AddRange(villageTractVL.GetMessages());

            return false;
        }

        List<DataValidationResult> villageVL = ValidateData(villages);
        if (villageVL.Invalid())
        {
            messages.Add("Error: Village Data Validation");
            messages.AddRange(villageVL.GetMessages());

            return false;
        }

        bool flag = false;
        using (ApplicationDbContext context = new(option))
        {
            flag = context.Upgrade(states, districts, townships, towns, wards, villageTracts, villages, messages);
        }

        return messages.Count <= 0 && flag;
    }

    public static List<DataValidationResult> ValidateData<T>(List<T> list)
        where T : class
    {
        List<DataValidationResult> result = [];
        List<ValidationResult> vr = [];
        int row = 0;
        foreach (T item in list.AsParallel())
        {
            row++;
            vr.Clear();
            if (!Validator.TryValidateObject(item, new ValidationContext(item), vr, validateAllProperties: true))
            {
                DataValidationResult dvr = new()
                {
                    Row = row,
                    IsValid = false
                };

                dvr.Results.AddRange(vr);
                result.Add(dvr);
            }
        }

        return result;
    }

    public static string GetConnectionInfo(string? connection)
    {
        string connectionString = string.Empty;
        if (!string.IsNullOrEmpty(connection))
        {
            try
            {
                SqlConnectionStringBuilder builder = new(connection);
                connectionString = "Server=" + builder.DataSource + ";DB=" + builder.InitialCatalog;
            }
            catch
            { }
        }

        return connectionString;
    }

    public static DbContextOptions<ApplicationDbContext> CreateDbContextOptions(string connection)
    {
        return new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connection).Options;
    }

    public static bool IsDbOK(string connection)
    {
        bool flag = false;
        try
        {
            using SqlConnection db = new(new SqlConnectionStringBuilder(connection)
            {
                ConnectTimeout = 10
            }.ConnectionString);
            db.Open();
            db.Close();
            flag = true;
        }
        catch
        { }

        return flag;
    }

    public static string GetExcelFilter()
    {
        return "Excel files (*.xlsx;*.xlsm)|*.xlsx;*.xlsm";
    }

    public static string GetExcelCsvFilters()
    {
        return "Excel files (*.xlsx)|*.xlsx|CSV files (*.csv)|*.csv";
    }

    public static string GetExcelCsvTextFilters()
    {
        return "Excel files (*.xlsx)|*.xlsx|CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
    }

    public static string GetCsvTextFilters()
    {
        return "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
    }

    public static string GetCsvFilters()
    {
        return "CSV files (*.csv)|*.csv";
    }
}
