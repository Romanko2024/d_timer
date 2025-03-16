using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StudentShakerSort
{
    public static void ShakerSort(int[] array)
    {
        int left = 0, right = array.Length - 1;
        while (left < right)
        {
            for (int i = left; i < right; i++)
                if (array[i] > array[i + 1])
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);

            right--;

            for (int i = right; i > left; i--)
                if (array[i] < array[i - 1])
                    (array[i], array[i - 1]) = (array[i - 1], array[i]);

            left++;
        }
    }
}
