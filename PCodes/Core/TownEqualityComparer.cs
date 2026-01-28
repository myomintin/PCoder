using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class TownEqualityComparer : IEqualityComparer<Town>
{
    public bool Equals(Town? x, Town? y)
    {
        //if (x == y)
        //{
        //    return true;
        //}

        if (x is null || y is null)
        {
            return false;
        }

        return x == y || x.Id == y.Id;
    }

    public int GetHashCode([DisallowNull] Town obj)
    {
        return obj.GetHashCode();
    }
}
