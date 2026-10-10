// I showed creativity by making Reflection questions/prompts not repeating until all have been used
// I also animated the breathing section
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
