//Displayed Creativity by:
// - Condensing Reference class into one primary constructor with optional parameters
// - Replacing redudnant private fields in Reference class with primary constructor inputs
// - Creating Extensions class with an extension to turn string -> List<Word>, used by Scripture class.
// - Using LINQ in Scripture class for various things
// - Making Scripture class HideRandomWords not re-hide already hidden words
// - Selecting random from a pre-coded list of scriptures
public class Reference(string book, int chapter, int startVerse, int endVerse = 0)
{
    //I condensed the 4 private interal fields and the two constructors into one primary constrcutor because this is c# and I know how to do that, and it still is encapsulated.
    //I left it as shown in all other classes to show I understand the "expected" solution as well.
    public string GetDisplayText() => $"{book} {chapter}:{(endVerse > 0 ? $"{startVerse}-{endVerse}" : startVerse)}";
}
