using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class DistrictEqualityComparer : IEqualityComparer<District>
{
    public bool Equals(District? x, District? y)
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

    public int GetHashCode([DisallowNull] District obj)
    {
        return obj.Id.GetHashCode();
    }
}
