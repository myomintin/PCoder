using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class TownshipEqualityComparer : IEqualityComparer<Township>
{
    public bool Equals(Township? x, Township? y)
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

    public int GetHashCode([DisallowNull] Township obj)
    {
        return obj.GetHashCode();
    }
}
