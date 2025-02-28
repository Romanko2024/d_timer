class Program
{
    static void Main()
    {
        Console.WriteLine("Вводьте рядки у форматі: <функція> <число>");
        Console.WriteLine("Функції: 0 - sqrt(abs(x)), 1 - x^3, 2 - x + 3.5");
        while (true)
        {
            try
            {
                var input = Console.ReadLine();
                var values = input.Split().Select(double.Parse).ToArray();
                //викликати виконання оепрацыъ через індексв масиві лабда функцій що тепер треба зробити..
                Console.WriteLine(whatever[(int)values[0]](values[1]));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
                //Console.WriteLine("Бажаємо всього найкращого!");
                //Console.WriteLine("Щасливої дороги!");
                break;
            }
        }
    }

}
