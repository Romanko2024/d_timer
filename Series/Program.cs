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
    static void Main() 
    { 

    }
}
