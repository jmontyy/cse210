class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        DisplayResult(PromptUserName(), SquareNumber(PromptUserNumber()));
    }

    static void DisplayWelcome() => Console.WriteLine("Welcome to the program!");

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name:");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        while (true)
        {
            Console.WriteLine("Please enter your favorite number:");
            int number = 0;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("ERROR: Must be a valid integer");
                continue;
            }
            return number;
        }
    }

    static int SquareNumber(int num) => (int)Math.Pow(num, 2);

    static void DisplayResult(string name, int num) => Console.WriteLine($"{name}, the square of your favorite number is {num}");
}