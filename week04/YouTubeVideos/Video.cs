public class Video(string title, string author, int length, List<Comment> comments)
{
//private fields handled automatically by primary constructor in c#
    public int GetCommentCount() => comments.Count;
    public void Display()
    {

        Console.WriteLine($"\"{title}\" by {author}");
        Console.WriteLine($"{length} seconds long with {GetCommentCount()} comments");
        foreach (var item in comments)
            item.Display();
    }
}
