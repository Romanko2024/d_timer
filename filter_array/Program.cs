class Program
{
    //делегат на який посилаються методи(лямбда вирази)
    delegate bool FilterDelegate(int number, int k); //прийма числа викидає так/ні
    static void Main()
    {
        //початковий масив
        //int[] numbers = { 10, 15, 20, 25, 30, 35, 40, 45, 50 };

        Console.Write("Введіть числа через пробіл: ");
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.Write("Введіть число відносно якого буде перевірятися кратність: ");
        int k = int.Parse(Console.ReadLine());
        //прив'язуємо лямбда вираз до змінної типу створеного делегата 
        FilterDelegate isMultiple = (number, divisor) => number % divisor == 0;

        //виклик фільтр. першим спос
        int[] filtered = Filter_Where(numbers, k, isMultiple);
        Console.WriteLine("Результат першим способом: " + string.Join(", ", filtered));
        //викл. другий спосіб
        int[] filteredManual = FilterManual(numbers, k, isMultiple);
        Console.WriteLine("Результат другим способом: " + string.Join(", ", filteredManual));
    }

    //філтрування першим методом
    static int[] Filter_Where(int[] array, int k, FilterDelegate filter)
    {
        return array.Where(num => filter(num, k)).ToArray();
    }

    //другим способом
    static int[] FilterManual(int[] array, int k, FilterDelegate filter)
    {
        int count = 0;
        //скільки елементів підходить умові
        for (int i = 0; i < array.Length; i++)
        {
            if (filter(array[i], k))
                count++;
        }

        //новий масив
        int[] result = new int[count];

        //заповнення масиву
        int index = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (filter(array[i], k))
                result[index++] = array[i];
        }
        return result;
    }
}