namespace Journal;

public class Journal 
{
    private readonly List<Entry> _entries = [];
    public void AddEntry(Entry entry) => _entries.Add(entry);
    public void DisplayAll() {
        foreach (var item in _entries)
        {
            item.Display();
            Console.WriteLine(); //Extra spacer between entries
        }
    }
    public void SaveToFile(string path) 
    {
        string filename = $"{path}.tsv";
        using StreamWriter outputFile = new StreamWriter(filename);
            foreach (Entry entry in _entries)
                outputFile.WriteLine(entry.BuildTSVLine());
    }
    public void LoadFromFile(string path) 
    {
        string filename = $"{path}.tsv";
        string[] lines = File.ReadAllLines(filename);

        _entries.Clear();
        foreach (string line in lines)
            _entries.Add(Entry.ParseTSVLine(line));
    }


}
