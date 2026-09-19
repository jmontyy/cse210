namespace Journal;

class Program
{
    static void Main(string[] args)
    {
        bool keepRunning = true;
        Journal journal = new();
        Console.WriteLine("Welcome to the Journal program!");
        while (keepRunning)
        {
            Console.WriteLine("Please Select one of the following choices:\n1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice is < 1 or > 5)
            {
                Console.WriteLine("Please input a number from 1 to 5");
                continue;
            }

            switch (choice)
            {
                case 1:
                    {
                        var prompt = PromptGenerator.GetPrompt();
                        Console.WriteLine(prompt);
                        string input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrEmpty(input))
                            journal.AddEntry(new(prompt, input));
                        break;
                    }
                case 2:
                    {
                        journal.DisplayAll();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("What filename do you want to load?");
                        string input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrEmpty(input))
                            journal.LoadFromFile(input);
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("What filename do you want to save to?");
                        string input = Console.ReadLine() ?? "";
                        if (!string.IsNullOrEmpty(input))
                            journal.SaveToFile(input);
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Thank you for using the journal program!");
                        keepRunning = false;
                        break;
                    }
            }

        }
    }
}
