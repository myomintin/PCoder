using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class TownEqualityComparer : IEqualityComparer<Town>
{
    public bool Equals(Town? x, Town? y)
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

    public int GetHashCode([DisallowNull] Town obj)
    {
        return obj.GetHashCode();
    }
}
