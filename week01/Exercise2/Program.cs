class Program
{
    static void Main(string[] args)
    {
        // I know that using a switch and all that isn't in the level of the course right now,
        // but I'm experienced in C# and switches are nicer to read and write.
        // If needed to be redone with only if statements, can be done.


        Console.WriteLine("What is your grade?");
        string input = Console.ReadLine();
        float score = 0;
        while (!float.TryParse(input, out score))
        {
            Console.WriteLine("Error: Please input a valid number without a percentage sign.");
            Console.WriteLine("What is your grade?");
            input = Console.ReadLine();
        }

        string letterGrade = "F";
        switch (score)
        {
            case >= 90:
                letterGrade = "A";
                break;
            case >= 80:
                letterGrade = "B";
                break;
            case >= 70:
                letterGrade = "C";
                break;
            case >= 60:
                letterGrade = "D";
                break;
        }

        // Add +/- to grades unless they're F or higher than A.
        if (score is >= 60 and < 95)
            switch (score % 10)
            {
                case < 3:
                    letterGrade += "-";
                    break;
                case >= 7:
                    letterGrade += "+";
                    break;
            }


        Console.WriteLine($"Your letter grade is: {letterGrade}");

    }
}