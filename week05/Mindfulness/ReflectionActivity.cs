// I showed creativity by making Reflection questions/prompts not repeating until all have been used
// I also animated the breathing section
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
