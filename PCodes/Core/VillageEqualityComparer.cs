using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class VillageEqualityComparer : IEqualityComparer<Village>
{
    public bool Equals(Village? x, Village? y)
    {
        if (x == y)
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        return x.Id == y.Id;
    }

    public int GetHashCode([DisallowNull] Village obj)
    {
        return obj.GetHashCode();
    }
}
