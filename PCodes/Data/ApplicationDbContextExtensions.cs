using Microsoft.EntityFrameworkCore;
using PCodes.Models;
using System.Linq.Expressions;

namespace PCodes.Data;

public partial class ApplicationDbContext
{
    public bool Upgrade(List<State> states, List<District> districts,
        List<Township> townships, List<Town> towns, List<Ward> wards,
        List<VillageTract> villageTracts, List<Village> villages,
        List<string> messages)
    {
        int stateCount = States.Count();
        int districtCount = Districts.Count();
        int townshipCount = Townships.Count();
        int townCount = Towns.Count();
        int wardCount = Wards.Count();
        int villageTractCount = VillageTracts.Count();
        int villageCount = Villages.Count();
        bool flag = false;

        try
        {
            DeleteSaveChanges<Village>();
            DeleteSaveChanges<VillageTract>();
            DeleteSaveChanges<Ward>();
            DeleteSaveChanges<Town>();
            DeleteSaveChanges<Township>();
            DeleteSaveChanges<District>();
            DeleteSaveChanges<State>();
            AddSaveChanges(states);
            AddSaveChanges(districts);
            AddSaveChanges(townships);
            AddSaveChanges(towns);
            AddSaveChanges(wards);
            AddSaveChanges(villageTracts);
            AddSaveChanges(villages);
            flag = true;
        }
        catch (Exception ex)
        {
            messages.Add("Error: Upgrade Data");
            messages.Add(ex.Message);
            if (ex.InnerException != null)
            {
                messages.Add(ex.InnerException.Message);
            }
        }

        if (flag)
        {
            messages.Add("Upgrade successfully");
            messages.Add($"States :: previous : {stateCount}, now : {States.Count()}");
            messages.Add($"Districts :: previous : {districtCount}, now : {Districts.Count()}");
            messages.Add($"Townships :: previous : {townshipCount}, now : {Townships.Count()}");
            messages.Add($"Towns :: previous : {townCount}, now : {Towns.Count()}");
            messages.Add($"Wards :: previous : {wardCount}, now : {Wards.Count()}");
            messages.Add($"Village Tracts :: previous : {villageTractCount}, now : {VillageTracts.Count()}");
            messages.Add($"Villages :: previous : {villageCount}, now : {Villages.Count()}");
        }

        return flag;
    }

    public async Task<bool> UpgradeAsync(List<State> states, List<District> districts,
        List<Township> townships, List<Town> towns, List<Ward> wards,
        List<VillageTract> villageTracts, List<Village> villages,
        List<string> messages)
    {
        int stateCount = States.Count();
        int districtCount = Districts.Count();
        int townshipCount = Townships.Count();
        int townCount = Towns.Count();
        int wardCount = Wards.Count();
        int villageTractCount = VillageTracts.Count();
        int villageCount = Villages.Count();
        bool flag = false;

        try
        {
            await DeleteSaveChangesAsync<Village>();
            await DeleteSaveChangesAsync<VillageTract>();
            await DeleteSaveChangesAsync<Ward>();
            await DeleteSaveChangesAsync<Town>();
            await DeleteSaveChangesAsync<Township>();
            await DeleteSaveChangesAsync<District>();
            await DeleteSaveChangesAsync<State>();
            await AddSaveChangesAsync(states);
            await AddSaveChangesAsync(districts);
            await AddSaveChangesAsync(townships);
            await AddSaveChangesAsync(towns);
            await AddSaveChangesAsync(wards);
            await AddSaveChangesAsync(villageTracts);
            await AddSaveChangesAsync(villages);
            flag = true;
        }
        catch (Exception ex)
        {
            messages.Add("Error: Upgrade Data");
            messages.Add(ex.Message);
            if (ex.InnerException != null)
            {
                messages.Add(ex.InnerException.Message);
            }
        }

        if (flag)
        {
            messages.Add("Upgrade successfully");
            messages.Add($"States :: previous : {stateCount}, now : {States.Count()}");
            messages.Add($"Districts :: previous : {districtCount}, now : {Districts.Count()}");
            messages.Add($"Townships :: previous : {townshipCount}, now : {Townships.Count()}");
            messages.Add($"Towns :: previous : {townCount}, now : {Towns.Count()}");
            messages.Add($"Wards :: previous : {wardCount}, now : {Wards.Count()}");
            messages.Add($"Village Tracts :: previous : {villageTractCount}, now : {VillageTracts.Count()}");
            messages.Add($"Villages :: previous : {villageCount}, now : {Villages.Count()}");
        }

        return flag;
    }

    #region Methods

    public bool AddSaveChanges<T>(ICollection<T> list)
        where T : class
    {
        Set<T>().AddRange(list);
        SaveChanges();

        return true;
    }

    public async Task<bool> AddSaveChangesAsync<T>(ICollection<T> list)
        where T : class
    {
        await Set<T>().AddRangeAsync(list);
        await SaveChangesAsync();

        return true;
    }

    public bool DeleteSaveChanges<T>()
        where T : class
    {
        //Set<T>().RemoveRange(Set<T>());
        //SaveChanges();
        Set<T>().ExecuteDelete();

        return true;
    }

    public async Task<bool> DeleteSaveChangesAsync<T>()
        where T : class
    {
        //Set<T>().RemoveRange(Set<T>());
        //await SaveChangesAsync();
        await this.Set<T>().ExecuteDeleteAsync();

        return true;
    }

    public bool DeleteRangeSaveChanges<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        //IQueryable<T> models = Set<T>().Where(predicate);

        //Set<T>().RemoveRange(models);
        //SaveChanges();
        this.Set<T>().Where(predicate).ExecuteDelete();

        return true;
    }

    public async Task<bool> DeleteRangeSaveChangesAsync<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        //IQueryable<T> models = Set<T>().Where(predicate);

        //Set<T>().RemoveRange(models);
        //await SaveChangesAsync();
        await this.Set<T>().Where(predicate).ExecuteDeleteAsync();

        return true;
    }

    public bool DeleteSaveChanges<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        T? model = Set<T>().FirstOrDefault(predicate);
        if (model is null)
        {
            return false;
        }

        Set<T>().Remove(model);
        SaveChanges();

        return true;
    }

    public async Task<bool> DeleteSaveChangesAsync<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        T? model = await Set<T>().FirstOrDefaultAsync(predicate);
        if (model is null)
        {
            return false;
        }

        Set<T>().Remove(model);
        await SaveChangesAsync();

        return true;
    }

    public bool Any<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        return Set<T>().Any(predicate);
    }

    public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        return await Set<T>().AnyAsync(predicate);
    }

    public void AsTracking()
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    public void AsNoTracking()
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public void AsNoTrackingWithIdentityResolution()
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
    }

    #endregion
}
