
namespace Journal;

//Design specs didn't say for these to be static but they're easier to use that way and don't contain any data that should be instanced, so i made it all static.
public static class PromptGenerator {

    private static List<string> _prompts = 
    [
        "What was the best thing that happened today?",
        "If you could redo one thing, what would you do?",
        "How did you improve from yesterday?",
        "How can you improve tomorrow?",
        "What was the strongest emotion I felt today?",
        "Who was the most interesting person I interacted with today?"
    ];
    public static string GetPrompt() => _prompts[Random.Shared.Next(_prompts.Count)];
}