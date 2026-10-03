public class Comment(string name, string text)
{
    //private fields handled automatically by primary constructor in c#
    public void Display()
    {
        Console.WriteLine($"{name} commented:\n{text}");
    }
}