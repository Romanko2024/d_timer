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
                //зчитати рядок
                //викликати виконання оепрацыъ
            }
            catch
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
                //Console.WriteLine("Бажаємо всього найкращого!");
                //Console.WriteLine("Щасливої дороги!");
                break;
            }
        }
    }

}
