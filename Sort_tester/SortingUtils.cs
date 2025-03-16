using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
public static class SortingUtils
{
    //сортування с заміром
    public static (int[]?, long) MeasureTime(Action<int[]> sortMethod, int[] inputArray, int timeoutMs)
    {
        int[] copy = (int[])inputArray.Clone();
        var sw = Stopwatch.StartNew();

        try
        {
            var cts = new CancellationTokenSource(timeoutMs);
            Task.Run(() => sortMethod(copy), cts.Token).Wait(cts.Token);
            return (copy, sw.Elapsed.Milliseconds);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
            return (null, -1);
        }
        finally
        {
            sw.Stop();
        }
    }

    public static void TestSorting(Action<int[]> referenceMethod, Action<int[]> studentMethod, int[] testArray)
    {
        int timeoutMs = 5000;

        //запуск еталонного сортування
        var (refSorted, refTime) = MeasureTime(referenceMethod, testArray, timeoutMs);
        if (refSorted == null)
        {
            Console.WriteLine("Помилка в еталонному сортуванні!");
            return;
        }

        //запуск студ сорту
        var (studSorted, studTime) = MeasureTime(studentMethod, testArray, timeoutMs);
        bool isSortedCorrectly = studSorted != null && refSorted.SequenceEqual(studSorted);

        //перевірка часу
        bool isTimeValid = studTime >= Math.Max(0, refTime / 5 - 200) && studTime <= 5 * refTime + 200;

        //результати
        Console.WriteLine($"Результат: {(isSortedCorrectly && isTimeValid ? "Успішно" : "Невдача")}");
        Console.WriteLine($"Час еталону: {refTime} мс | Час студента: {studTime} мс");
        Console.WriteLine("---");
    }
}
