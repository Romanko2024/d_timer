class SortingTester
{
    // Еталонні методи сортування
    static void SelectionSortReference(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[j] < array[minIndex])
                    minIndex = j;

            (array[i], array[minIndex]) = (array[minIndex], array[i]);
        }
    }
    //
}
