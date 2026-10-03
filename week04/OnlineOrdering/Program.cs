//In this assignment, i left the private fields in despite being unneeded with primary constructors just to display I understand encapsulation when primary constructors aren't used
class Program
{
    static void Main(string[] args)
    {
        List<Order> orders =
        [
            new([
                new("Keyboard", 101, 49.99f, 1),
                new("Mouse", 102, 24.99f, 2),
                new("USB Cable", 103, 9.99f, 3)
                ],
                new("John Smith", new("123 Main Street", "Dallas", "Texas", "USA"))),
            new([
                new("Monitor", 201, 199.99f, 1),
                new("Webcam", 202, 59.99f, 2),
                new("Headset", 203, 79.99f, 1)
                ],
                new("Jane Doe", new("45 Maple Avenue", "Toronto", "Ontario", "Canada")))
        ];

        foreach (var item in orders)
        {
            Console.WriteLine("==========");
            Console.WriteLine();
            Console.WriteLine(item.GetPackagingLabel());
            Console.WriteLine();
            Console.WriteLine(item.GetShippingLabel());
            Console.WriteLine();
            Console.WriteLine($"Total Price: ${item.GetTotalCost():F2}");
        }
    }
}
