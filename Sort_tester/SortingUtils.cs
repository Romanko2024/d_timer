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
    public static (int[], long) MeasureTime(Action<int[]> sortMethod, int[] inputArray, int timeoutMs)
    {
        //клонує вхідний масив
        int[] copy = (int[])inputArray.Clone();
        //запуск тайцмера
        var sw = Stopwatch.StartNew();

        try
        {
            //максимальний час на виконання
            var cts = new CancellationTokenSource(timeoutMs);
            //запуск сорт. в потоці
            var task = Task.Run(() => sortMethod(copy), cts.Token);
            //очікує завершення/перериває якщо
            task.Wait(cts.Token);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час сортування: {ex.Message}");
        }
        //
        sw.Stop();
        //повертає відсторт. масив + час
        return (copy, sw.ElapsedMilliseconds);
    }

    public static void TestSorting(Action<int[]> referenceMethod, Action<int[]> studentMethod, int[] testArray)
    {
        //виклик еталонного та студ сорта і заміри
        var (refSorted, refTime) = MeasureTime(referenceMethod, testArray, 5000);
        var (studSorted, studTime) = MeasureTime(studentMethod, testArray, 5000);
        //чи посортовано правильно
        bool isCorrect = refSorted.SequenceEqual(studSorted);
        
        Console.WriteLine($"Результат тесту: {isCorrect}");
        Console.WriteLine($"Час еталонного: {refTime} мс, Час студентського: {studTime} мс");
    }
}
