using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string folderPath = @"C:\Users\Ron\source\repos\d_timer\Sort_tester\StudentSorts";
        var testCases = ReadTestCases(folderPath);

        foreach (var testArray in testCases)
        {
            Console.WriteLine("\n=== Тест нового масиву ===");

            //тест сортування вибором
            SortingUtils.TestSorting(
                ReferenceSorts.SelectionSort,
                StudentSelectionSort.SelectionSort,
                testArray
            );

            //тест шейкерного сортування
            SortingUtils.TestSorting(
                ReferenceSorts.ShakerSort,
                StudentShakerSort.ShakerSort,
                testArray
            );
        }
    }

    static int[][] ReadTestCases(string folderPath)
    {
        var files = Directory.GetFiles(folderPath, "*.txt");
        return files.Select(f => File.ReadAllLines(f).Select(int.Parse).ToArray()).ToArray();
    }
}
