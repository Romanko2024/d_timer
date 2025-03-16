public static class ReferenceSorts
{
    // Еталонні методи сортування
    static void SelectionSort(int[] array)
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
    static void ShakerSort(int[] array)
    {
        int left = 0, right = array.Length - 1;
        bool swapped;

        do
        {
            swapped = false;
            int lastSwapIndex = right;

            //прохід зліва направо
            for (int i = left; i < right; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    swapped = true;
                    lastSwapIndex = i;
                }
            }
            right = lastSwapIndex;

            if (!swapped) break;//вихід if не було обмінів

            swapped = false;
            lastSwapIndex = left;

            //прохід справа наліво
            for (int i = right; i > left; i--)
            {
                if (array[i] < array[i - 1])
                {
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);
                    swapped = true;
                    lastSwapIndex = i;
                }
            }
            left = lastSwapIndex;

        } while (swapped);
    }
    //
}
