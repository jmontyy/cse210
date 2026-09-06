class Program
{
    static void Main(string[] args)
    {
        bool repeat = true;
        while (repeat)
        {
            Console.WriteLine("What is the magic number?");
            int number = 0;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("ERROR: Must be a valid integer");
                continue;
            }

            while (true)
            {
                Console.WriteLine("What is your guess?");
                int guess = 0;
                if (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.WriteLine("ERROR: Must be a valid integer");
                    continue;
                }
                if (guess == number)
                {
                    Console.WriteLine("You won! Play again?");
                    if (!(Console.ReadLine().ToLower() is "yes" or "y" or "true"))
                        repeat = false;
                    break;
                }
                Console.WriteLine(guess < number ? "Higher" : "Lower");
            }

        }
    }
}