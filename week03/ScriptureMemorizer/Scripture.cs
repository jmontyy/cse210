//Displayed Creativity by:
// - Condensing Reference class into one primary constructor with optional parameters
// - Replacing redudnant private fields in Reference class with primary constructor inputs
// - Creating Extensions class with an extension to turn string -> List<Word>, used by Scripture class.
// - Using LINQ in Scripture class for various things
// - Making Scripture class HideRandomWords not re-hide already hidden words
// - Selecting random from a pre-coded list of scriptures
public class Scripture(Reference reference, string text)
{
    Reference _reference = reference;
    List<Word> _words = text.ToWordList();

    public void HideRandomWords(int numberToHide)
    {
        for (int i = 0; i < numberToHide; i++)
        {
            if (IsCompletelyHidden())
                return;
            var notHidden = _words.Where(x => !x.IsHidden()).ToList();
            notHidden[Random.Shared.Next(notHidden.Count)].Hide();
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + "\n";
        foreach (var item in _words)
        {
            displayText += item.GetDisplayText() + " ";
        }
        return displayText;
    }

    public bool IsCompletelyHidden() => _words.All(x => x.IsHidden());
}
