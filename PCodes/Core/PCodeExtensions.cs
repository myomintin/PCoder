using PCodes.Data;
using PCodes.Models;
using System.Data;
using System.Text;

namespace PCodes.Core;

public static class PCodeExtensions
{
    public static bool Invalid(this List<DataValidationResult> list)
    {
        return list.Any(x => !x.IsValid);
    }

    public static ParallelQuery<string> GetMessages(this List<DataValidationResult> list)
    {
        return from x in list.AsParallel()
               where !x.IsValid
               select $"{x.Row}, {x.GetMessage()}";
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    state.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    state.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    state.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    state.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    state.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    state.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    state.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    state.Remark = row.GetNullabeString(columnIndex);
                }
            }

            stateList.Add(state);
        }

        return true;
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    district.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    district.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    district.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    district.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    district.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    district.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    district.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    district.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
            }

            districtList.Add(district);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
        }

        return true;
    }

    public static bool TryParseSADSAZ(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    district.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    district.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    district.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    district.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    district.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    district.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    district.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    district.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
            }

            districtList.Add(district);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
        }

        return true;
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList, List<Township>? townshipList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        townshipList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            Township township = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    township.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    township.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    township.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    township.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    township.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    township.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    township.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    township.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "DistrictId")
                {
                    district.Id = row.GetString(columnIndex);
                    township.DistrictId = district.Id;
                }
                else if (col.Property == "DistrictName")
                {
                    district.Name = row.GetString(columnIndex);
                }
            }

            townshipList.Add(township);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
            if (!districtList.Any(x => x.Id == district.Id))
            {
                districtList.Add(district);
            }
        }

        return true;
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList, List<Township>? townshipList,
        List<Town>? townList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        townshipList ??= [];
        townList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            Township township = new();
            Town town = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    town.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    town.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    town.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Longitude")
                {
                    town.Longitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Latitude")
                {
                    town.Latitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    town.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    town.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    town.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    town.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    town.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "DistrictId")
                {
                    district.Id = row.GetString(columnIndex);
                    township.DistrictId = district.Id;
                }
                else if (col.Property == "DistrictName")
                {
                    district.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "TownshipId")
                {
                    township.Id = row.GetString(columnIndex);
                    town.TownshipId = township.Id;
                }
                else if (col.Property == "TownshipName")
                {
                    township.Name = row.GetString(columnIndex);
                }
            }

            townList.Add(town);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
            if (!districtList.Any(x => x.Id == district.Id))
            {
                districtList.Add(district);
            }
            if (!townshipList.Any(x => x.Id == township.Id))
            {
                townshipList.Add(township);
            }
        }

        return true;
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList, List<Township>? townshipList,
        List<VillageTract>? villageTractList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        townshipList ??= [];
        villageTractList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            Township township = new();
            VillageTract villageTract = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    villageTract.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    villageTract.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    villageTract.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    villageTract.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    villageTract.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    villageTract.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    villageTract.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    villageTract.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "DistrictId")
                {
                    district.Id = row.GetString(columnIndex);
                    township.DistrictId = district.Id;
                }
                else if (col.Property == "DistrictName")
                {
                    district.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "TownshipId")
                {
                    township.Id = row.GetString(columnIndex);
                    villageTract.TownshipId = township.Id;
                }
                else if (col.Property == "TownshipName")
                {
                    township.Name = row.GetString(columnIndex);
                }
            }

            villageTractList.Add(villageTract);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
            if (!districtList.Any(x => x.Id == district.Id))
            {
                districtList.Add(district);
            }
            if (!townshipList.Any(x => x.Id == township.Id))
            {
                townshipList.Add(township);
            }
        }

        return true;
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList, List<Township>? townshipList,
        List<Town>? townList, List<Ward>? wardList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        townshipList ??= [];
        townList ??= [];
        wardList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            Township township = new();
            Town town = new();
            Ward ward = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    ward.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    ward.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    ward.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    ward.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    ward.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    ward.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    ward.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    ward.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "DistrictId")
                {
                    district.Id = row.GetString(columnIndex);
                    township.DistrictId = district.Id;
                }
                else if (col.Property == "DistrictName")
                {
                    district.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "TownshipId")
                {
                    township.Id = row.GetString(columnIndex);
                    town.TownshipId = township.Id;
                }
                else if (col.Property == "TownshipName")
                {
                    township.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "TownId")
                {
                    town.Id = row.GetString(columnIndex);
                    ward.TownId = town.Id;
                }
                else if (col.Property == "TownName")
                {
                    town.Name = row.GetString(columnIndex);
                }
            }

            wardList.Add(ward);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
            if (!districtList.Any(x => x.Id == district.Id))
            {
                districtList.Add(district);
            }
            if (!townshipList.Any(x => x.Id == township.Id))
            {
                townshipList.Add(township);
            }
            if (!townList.Any(x => x.Id == town.Id))
            {
                townList.Add(town);
            }
        }

        return true;
    }

    public static bool TryParse(this DataTable? dataTable, ICollection<IndexProperty> mappings,
        List<State>? stateList, List<District>? districtList, List<Township>? townshipList,
        List<VillageTract>? villageTractList, List<Village>? villageList)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return false;
        }

        stateList ??= [];
        districtList ??= [];
        townshipList ??= [];
        villageTractList ??= [];
        villageList ??= [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State state = new();
            District district = new();
            Township township = new();
            VillageTract villageTract = new();
            Village village = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    double? id = row.GetNullableDouble(columnIndex);
                    if (!id.HasValue)
                    {
                        village.Id = row.GetString(columnIndex);
                    }
                    else
                    {
                        village.Id = id.Value.ToString();
                    }
                }
                else if (col.Property == "Name")
                {
                    village.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    village.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Longitude")
                {
                    village.Longitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Latitude")
                {
                    village.Latitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    village.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    village.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    village.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    village.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    village.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    state.Id = row.GetString(columnIndex);
                    district.StateId = state.Id;
                }
                else if (col.Property == "StateName")
                {
                    state.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "DistrictId")
                {
                    district.Id = row.GetString(columnIndex);
                    township.DistrictId = district.Id;
                }
                else if (col.Property == "DistrictName")
                {
                    district.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "TownshipId")
                {
                    township.Id = row.GetString(columnIndex);
                    villageTract.TownshipId = township.Id;
                }
                else if (col.Property == "TownshipName")
                {
                    township.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "VillageTractId")
                {
                    villageTract.Id = row.GetString(columnIndex);
                    village.VillageTractId = villageTract.Id;
                }
                else if (col.Property == "VillageTractName")
                {
                    villageTract.Name = row.GetString(columnIndex);
                }
            }

            villageList.Add(village);
            if (!stateList.Any(x => x.Id == state.Id))
            {
                stateList.Add(state);
            }
            if (!districtList.Any(x => x.Id == district.Id))
            {
                districtList.Add(district);
            }
            if (!townshipList.Any(x => x.Id == township.Id))
            {
                townshipList.Add(township);
            }
            if (!villageTractList.Any(x => x.Id == villageTract.Id))
            {
                villageTractList.Add(villageTract);
            }
        }

        return true;
    }

    public static List<State>? ToStates(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<State> stateList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            State value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    value.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
            }

            stateList.Add(value);
        }

        return stateList;
    }

    public static List<District>? ToDistricts(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<District> districtList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            District value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    value.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StateId")
                {
                    value.StateId = row.GetString(columnIndex);
                }
            }

            districtList.Add(value);
        }

        return districtList;
    }

    public static List<Township>? ToTownships(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<Township> townshipList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            Township value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    value.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "DistrictId")
                {
                    value.DistrictId = row.GetString(columnIndex);
                }
            }

            townshipList.Add(value);
        }

        return townshipList;
    }

    public static List<Town>? ToTowns(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<Town> townList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            Town value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    value.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Longitude")
                {
                    value.Longitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Latitude")
                {
                    value.Latitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "TownshipId")
                {
                    value.TownshipId = row.GetString(columnIndex);
                }
            }

            townList.Add(value);
        }

        return townList;
    }

    public static List<VillageTract>? ToVillageTracts(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<VillageTract> villageTractList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            VillageTract value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    value.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "TownshipId")
                {
                    value.TownshipId = row.GetString(columnIndex);
                }
            }

            villageTractList.Add(value);
        }

        return villageTractList;
    }

    public static List<Ward>? ToWards(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<Ward> wardList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            Ward value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    value.Id = row.GetString(columnIndex);
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "TownId")
                {
                    value.TownId = row.GetString(columnIndex);
                }
            }

            wardList.Add(value);
        }

        return wardList;
    }

    public static List<Village>? ToVillages(this DataTable? dataTable, ICollection<IndexProperty> mappings)
    {
        if (dataTable is null || mappings is null || mappings.Count == 0)
        {
            return null;
        }

        List<Village> villageList = [];
        foreach (DataRow row in dataTable.Rows.AsParallel())
        {
            Village value = new();
            foreach (IndexProperty col in mappings)
            {
                int columnIndex = col.Index - 1;
                if (col.Property == "Id")
                {
                    double? id = row.GetNullableDouble(columnIndex);
                    if (!id.HasValue)
                    {
                        value.Id = row.GetString(columnIndex);
                    }
                    else
                    {
                        value.Id = id.Value.ToString();
                    }
                }
                else if (col.Property == "Name")
                {
                    value.Name = row.GetString(columnIndex);
                }
                else if (col.Property == "NameMM")
                {
                    value.NameMM = row.GetString(columnIndex);
                }
                else if (col.Property == "Longitude")
                {
                    value.Longitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Latitude")
                {
                    value.Latitude = row.GetNullableDouble(columnIndex);
                }
                else if (col.Property == "Source")
                {
                    value.Source = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "StartDate")
                {
                    value.StartDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "ModifiedDate")
                {
                    value.ModifiedDate = row.GetNullabeDateTime(columnIndex);
                }
                else if (col.Property == "Active")
                {
                    value.Active = row.GetNullabeString(columnIndex).FromActiveToBoolean();
                }
                else if (col.Property == "Remark")
                {
                    value.Remark = row.GetNullabeString(columnIndex);
                }
                else if (col.Property == "VillageTractId")
                {
                    value.VillageTractId = row.GetString(columnIndex);
                }
            }

            villageList.Add(value);
        }

        return villageList;
    }
}
