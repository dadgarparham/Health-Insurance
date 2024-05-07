using System;
using System.Collections.Generic;
using System.Linq;

namespace Health_Insurance.Domain.Extensions;

public static class EnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IList<T> input)
    {
        return input == null || !input.Any();
    }
}
