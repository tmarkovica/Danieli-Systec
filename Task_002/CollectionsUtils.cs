namespace Task_002;

public static class CollectionsUtils
{
    public static int MinValueIndex<T>(T[] arr) where T : IComparable<T>
    {
        if (arr.Length == 0)
            return -1;

        int indexOfMinValue = 0;
        T minValue = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(minValue) < 0) 
            {
                indexOfMinValue = i;
                minValue = arr.ElementAt(i);
            }
        }
        return indexOfMinValue;
    }

    public static int MaxValueIndex<T>(T[] arr) where T : IComparable<T>
    {
        if (arr.Length == 0)
            return -1;

        int indexOfMaxValue = 0;
        T maxValue = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i].CompareTo(maxValue) > 0)
            {
                indexOfMaxValue = i;
                maxValue = arr[i];
            }
        }
        return indexOfMaxValue;
    }
}
