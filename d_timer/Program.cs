using System.Threading;

class Timer
{
    //посилання на метод 
    private readonly Action action;
    //інтвервал між виконанням action
    private readonly int interval;
    //флаг таймер працює/ні
    private bool isRunning;
    //потік таймера
    private Thread thread;
    //конструктор класу
    public Timer(Action с_action, int с_interval) //метод для виконання, інтервал.
    {
        //якщо с_action == null кидає виняток
        action = с_action ?? throw new ArgumentNullException(nameof(с_action));
        //кидає виняток при с_interval менше 0
        interval = с_interval > 0 ? с_interval : throw new ArgumentException("Інтервал має бути більше 0 секунд");
    }
    //запуск таймера
    public void Start()
    {
        if (isRunning) return; //нічого не робимо якщо уже запущений
        isRunning = true; //перемикаємо флаг
        //новий потік в якому проходить метод безпосередьної роботи таймера
        thread = new Thread(Run) { IsBackground = true }; // IsBackground = true - зупиниться при закритті програми
        thread.Start();
    }
    private void Run()
    {
        while (isRunning) //поки таймер активний
        {
            action.Invoke(); //виконати передану дію
            Thread.Sleep(interval * 1000); //затримка на interval секунд. Thread.Sleep в мілісекндах тому множимо на 1к
        }
    }
    public void Stop()
    {
        isRunning = false; //пермикає флаг
        thread?.Join(); //Join() не дає основному потоку завершитись доки thread (потік таймера) не закічився
        //? щоб не виникло помилки з null
    }
}

class Program
{
    static void Main()
    {
        //створюємо таймери, що кожний інтервал пишуть час
        Timer timer1 = new Timer(() => Console.WriteLine($"Таймер 1: {DateTime.Now:HH:mm:ss}"), 2);
        Timer timer2 = new Timer(() => Console.WriteLine($"Таймер 2: {DateTime.Now:HH:mm:ss}"), 3);
        Timer timer3 = new Timer(() => Console.Clear(), 10);
        //запуск
        timer1.Start();
        timer2.Start();
        timer3.Start();
        //
        Console.WriteLine("Натисніть Enter для зупинки");
        Console.ReadLine();
        //
        timer1.Stop();
        timer2.Stop();
        timer3.Stop();
    }
}