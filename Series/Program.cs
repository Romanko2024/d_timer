class Program
{
    delegate double SeriesElem(int i);
    //рахуємо ітий член першого ряду.
    static double FirstSeries(int i) => 1.0 / Math.Pow(2, i - 1);

    //рахуємо ітий член другого ряду
    static double SecondSeries(int i)
    {
        double factorial = 1;
        for (int j = 1; j <= i; j++)
        {
            //j=1 factorial= 1*1=1
            //j=2 factorial= 1*2=2
            //j=3 factorial= 2*3=6
            factorial *= j;
        }
        return 1.0 / factorial;
    }

    //рахуємо ітий член другого ряду
    //в Math.Pow перше число, друге степінь числа!!
    //+ - чередується через парність/непарність степені
    static double ThirdSeries(int i) => Math.Pow(-1, i) / Math.Pow(2, i - 1);

    static double SeriesSumCycle(SeriesElem elem, double precision)
    {
        double sum = 0;
        int i = 1;
        double currentElem = elem(i);
        
        while (Math.Abs(currentElem) >= precision)
        {
            sum += currentElem;
            i++;
            //переходимо до настпн елемента
            currentElem = elem(i); 
        }

        return sum;
    }
    static void Main() 
    {
        Console.WriteLine("Введіть точність обчислення (наприклад 0.001): ");
        double precision;
        //повторяэться доки не буде правлиьного значення. без out ламаэться
        while (!double.TryParse(Console.ReadLine(), out precision) || precision <= 0)
        {
            Console.Write("Некоректне значення.");
        }

        Console.WriteLine("Сума першого ряду: " + SeriesSumCycle(FirstSeries, precision));
        Console.WriteLine("Сума другого ряду: " + SeriesSumCycle(SecondSeries, precision));
        Console.WriteLine("Сума третього ряду: " + SeriesSumCycle(ThirdSeries, precision));
    }
}
