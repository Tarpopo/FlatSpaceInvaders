using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MassExtensions
{
    public static int GetNextIndex<T>(this T[] mass, int currentIndex) =>
        currentIndex + 1 >= mass.Length ? 0 : currentIndex + 1;

    public static T GetRandElement<T>(this T[] mass) => mass[Random.Range(0, mass.Length)];

    public static T GetRandElement<T>(this IEnumerable<T> mass)
    {
        var enumerable = mass as T[] ?? mass.ToArray();
        return enumerable.GetRandElement();
    }
}