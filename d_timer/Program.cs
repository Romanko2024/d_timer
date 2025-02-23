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
        
    }
}

class Program
{
    static void Main()
    {

    }
}