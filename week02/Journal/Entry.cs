namespace Journal;

public class Entry(string prompt, string entry, string? date = null)
{
    private string _date = date ?? DateTime.Now.ToShortDateString();
    private string _prompt = prompt;
    private string _entry = entry;
    public void Display() => Console.WriteLine($"Date: {_date} - Prompt:{_prompt}\n{_entry}");

    //These two were not in the original spec but I felt that using them better suited the principles of abstraction so I added them in
    public string BuildTSVLine() => $"{_date}\t{_prompt}\t{_entry}";
    public static Entry ParseTSVLine(string line) 
    {
        string[] parts = line.Split("\t");
        return new Entry(parts[1], parts[2], parts[0]);
    }
}