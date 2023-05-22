public static class MassExtensions
{
    public static int GetNextIndex<T>(this T[] mass, int currentIndex) =>
        currentIndex + 1 >= mass.Length ? 0 : currentIndex + 1;
}