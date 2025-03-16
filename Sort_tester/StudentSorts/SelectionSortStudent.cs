using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StudentSelectionSort
{
    public static void SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[j] > array[maxIndex]) //має бути <
                    maxIndex = j;

            (array[i], array[maxIndex]) = (array[maxIndex], array[i]);
        }
    }
}
