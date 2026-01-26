using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class VillageTractEqualityComparer : IEqualityComparer<VillageTract>
{
    public bool Equals(VillageTract? x, VillageTract? y)
    {
        if (x == y)
        {
            return true;
        }

        if (x is null || y is null)
        {
            return false;
        }

        return x.Id == y.Id;
    }

    public int GetHashCode([DisallowNull] VillageTract obj)
    {
        return obj.GetHashCode();
    }
}
