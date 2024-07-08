using PCodes.Models;
using System.Diagnostics.CodeAnalysis;

namespace PCodes.Core;

public class StateEqualityComparer : IEqualityComparer<State>
{
    public bool Equals(State? x, State? y)
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

    public int GetHashCode([DisallowNull] State obj)
    {
        return obj.GetHashCode();
    }
}
