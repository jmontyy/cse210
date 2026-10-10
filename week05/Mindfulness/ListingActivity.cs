// I showed creativity by making Reflection questions/prompts not repeating until all have been used
// I also animated the breathing section
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