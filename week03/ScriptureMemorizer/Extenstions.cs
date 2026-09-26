//Displayed Creativity by:
// - Condensing Reference class into one primary constructor with optional parameters
// - Replacing redudnant private fields in Reference class with primary constructor inputs
// - Creating Extensions class with an extension to turn string -> List<Word>, used by Scripture class.
// - Using LINQ in Scripture class for various things
// - Making Scripture class HideRandomWords not re-hide already hidden words
// - Selecting random from a pre-coded list of scriptures
public static class Extenstions
{
    public static List<Word> ToWordList(this string text)
    {
        var wordsString = text.Split(' ');
        var words = new List<Word>();
        foreach (var item in wordsString)
            words.Add(new(item));
        return words;
    }
}
