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
