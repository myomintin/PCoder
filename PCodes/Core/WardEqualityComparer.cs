using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class WardEqualityComparer : IEqualityComparer<Ward>
{
    public bool Equals(Ward? x, Ward? y)
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

    public int GetHashCode([DisallowNull] Ward obj)
    {
        return obj.GetHashCode();
    }
}
