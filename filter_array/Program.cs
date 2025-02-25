class Program
{
    //делегат на який посилаються методи(лямбда вирази)
    delegate bool FilterDelegate(int number, int k); //прийма числа викидає так/ні
    static void Main()
    {
        //початковий масив
        int[] numbers = { 10, 15, 20, 25, 30, 35, 40, 45, 50 };
        Console.Write("Введіть число відносно якого буде перевірятися кратність: ");
        int k = int.Parse(Console.ReadLine());
        //прив'язуємо лямбда вираз до змінної типу створеного делегата 
        FilterDelegate isMultiple = (number, divisor) => number % divisor == 0;

        //виклик фільтр. першим спос
        int[] filtered1 = Filter_Where(numbers, k, isMultiple);
        Console.WriteLine("Результат першим способом: " + string.Join(", ", filtered1));
    }
    //філтрування першим методом
    static int[] Filter_Where(int[] array, int k, FilterDelegate filter)
    {
        return array.Where(num => filter(num, k)).ToArray();
    }

    //тут буде другий спосіб....

}