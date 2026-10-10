// I showed creativity by making Reflection questions/prompts not repeating until all have been used
// I also animated the breathing section
class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program, select an option:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            if (!int.TryParse(Console.ReadLine(), out int choice))
                choice = -1;
            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid option. Please choose 1-4.");
                    continue;
            }
            activity.Run();
            Console.WriteLine("Press Enter to return to the menu.");
            Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine("Thank you for taking time to practice mindfulness!");
    }
}

public abstract class Activity(string name, string description)
{
    private int _duration = 0;
    public string GetName() => name;
    public int GetDuration() => _duration;
    public void SetDuration(int duration) => _duration = duration;
    public void Run()
    {
        DisplayStartingMessage();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to {name}.");
        Console.WriteLine(description);
        Console.WriteLine();
        int duration;
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out duration) && duration > 0)
                break;
            Console.WriteLine("Please enter a positive whole number.");
        }
        _duration = duration;
    }
    public static void PrepareToBegin()
    {
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!!");
        Console.WriteLine($"You have completed {name}.");
        Console.WriteLine($"You spent {_duration} seconds on this activity.");
        ShowSpinner(3);
    }
    public static void ShowSpinner(int seconds)
    {
        char[] spinner = { '|', '/', '-', '\\' };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[index % spinner.Length]);
            Thread.Sleep(150);
            Console.Write('\b');
            index++;
        }
        Console.WriteLine(" ");
    }
    public static void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write('\b');
            Console.Write(' ');
            Console.Write('\b');
        }
        Console.WriteLine();
    }

    protected static string GetUnusedPrompt(ref List<string> unused, List<string> fullList)
    {
        if (unused.Count < 1)
            unused = [.. fullList];
        int index = Random.Shared.Next(unused.Count);
        string selected = unused[index];
        unused.RemoveAt(index);
        return selected;
    }
    public virtual void PerformActivity() { }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }
    public override void PerformActivity()
    {
        int elapsed = 0;
        int duration = GetDuration();
        while (elapsed < duration)
        {
            int inhaleSeconds = Math.Min(4, duration - elapsed);
            if (inhaleSeconds <= 0)
                break;

            Console.WriteLine();
            Console.WriteLine("Breathe in...");
            AnimateBreath(inhaleSeconds, true);
            elapsed += inhaleSeconds;
            if (elapsed >= duration)
                break;

            int exhaleSeconds = Math.Min(6, duration - elapsed);
            Console.WriteLine();
            Console.WriteLine("Breathe out...");
            AnimateBreath(exhaleSeconds, false);
            elapsed += exhaleSeconds;
        }
    }

    private static void AnimateBreath(int seconds, bool inhale)
    {
        for (int i = 1; i <= seconds; i++)
        {
            double progress = (double)i / seconds;

            int barLength = inhale
                ? (int)(progress * 20)
                : (int)((1 - progress) * 20);

            if (barLength < 1)
            {
                barLength = 1;
            }

            string bar = new('=', barLength);
            Console.Write($"\r[{bar,-20}] {i}");
            Thread.Sleep(1000);
        }

        Console.WriteLine();
    }
}

class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }
    private readonly List<string> _prompts =
        [
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ];

    private List<string> _unusedPrompts = [];
    private readonly List<string> _questions =
        [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];

    private List<string> _unusedQuestions = [];
    public override void PerformActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        string prompt = GetUnusedPrompt(ref _unusedPrompts, _prompts);
        Console.WriteLine(prompt);
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string question = GetUnusedPrompt(ref _unusedQuestions, _questions);
            Console.WriteLine();
            Console.WriteLine(question);
            int remaining = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            if (remaining <= 0)
                break;

            int pause = Math.Min(5, remaining);
            ShowSpinner(pause);
        }
    }
}
class ListingActivity : Activity
{
    private readonly List<string> _prompts =
        [
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ];

    private List<string> _unusedPrompts = [];

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    public override void PerformActivity()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        string prompt = GetUnusedPrompt(ref _unusedPrompts, _prompts);

        Console.WriteLine(prompt);
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items below.");
        Console.WriteLine("Press Enter after each item.");
        Console.WriteLine();
        List<string> responses = [];
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write($"Item {responses.Count + 1}: ");
            string response = Console.ReadLine();
            if (response == null)
                break;

            if (!string.IsNullOrWhiteSpace(response))
                responses.Add(response.Trim());
        }
        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} items!");
    }
}