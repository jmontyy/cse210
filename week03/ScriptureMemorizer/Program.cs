//Displayed Creativity by:
// - Condensing Reference class into one primary constructor with optional parameters
// - Replacing redudnant private fields in Reference class with primary constructor inputs
// - Creating Extensions class with an extension to turn string -> List<Word>, used by Scripture class.
// - Using LINQ in Scripture class for various things
// - Making Scripture class HideRandomWords not re-hide already hidden words
// - Selecting random from a pre-coded list of scriptures
class Program
{
    static List<Scripture> scriptures = [
        new(new("John",3,16),"For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life"),
        new(new("Proverbs",3,5,6),"Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.")
    ];
    static void Main(string[] args)
    {
        var scripture = scriptures[Random.Shared.Next(scriptures.Count)];
        Console.WriteLine(scripture.GetDisplayText());
        while (!scripture.IsCompletelyHidden() && !CheckToQuit()) 
        {
            scripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }

    public static bool CheckToQuit() {
        var text = Console.ReadLine();
        return text.ToLower().Contains("quit");
    }
}