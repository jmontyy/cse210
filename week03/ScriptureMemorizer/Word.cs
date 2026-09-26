//Displayed Creativity by:
// - Condensing Reference class into one primary constructor with optional parameters
// - Replacing redudnant private fields in Reference class with primary constructor inputs
// - Creating Extensions class with an extension to turn string -> List<Word>, used by Scripture class.
// - Using LINQ in Scripture class for various things
// - Making Scripture class HideRandomWords not re-hide already hidden words
// - Selecting random from a pre-coded list of scriptures
public class Word(string text)
{
    string _text = text;
    bool _isHidden;

    public void Hide() => _isHidden = true;

    public void Show() => _isHidden = false;

    public bool IsHidden() => _isHidden;

    public string GetDisplayText() => _isHidden ? new string('_', _text.Length) : _text;
}