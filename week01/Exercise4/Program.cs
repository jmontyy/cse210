class Program
{
    static void Main(string[] args)
    {
        List<int> list = [];
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while (true)
        {
            Console.WriteLine("Enter Number");
            int number = 0;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("ERROR: Must be a valid integer");
                continue;
            }
            if (number == 0)
                break;
            list.Add(number);
        }

        //these could be done with foreach loops, but linq expressions are so much easier to read and write.
        //will redo with a foreach loop if needed.

        Console.WriteLine("The sum is: " + list.Sum());
        Console.WriteLine("The average is: " + (list.Sum() / (float)list.Count()));
        //Sort then first to get largest number easily. Could foreach and compare the sizes of each number but this is cleaner
        //Could linq orderby to not adjust the normal list but it doesn't matter here.
        list.Sort();
        Console.WriteLine("The largest number is: " + list.Last());
        Console.WriteLine("The smallest positive number is: " + list.First(x => x > 0));

    }
}