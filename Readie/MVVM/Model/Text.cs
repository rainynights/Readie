namespace Readie.MVVM.Model;

public class Text
{
    public const string DefaultPreview = "Preview..";

    public string Title { get; set; }
    public string[] Pages { get; set; }

    //TODO düzelt bunu
    public string AllPagesAsString
    {
        get
        {
            return string.Join(" ", Pages);
        }
    }
    private const int MaxPreviewLength = 100;
    //private const int MaxPageLength = 800;

    public string GetPreview()
    {
        if (Pages.Length < 0)
            return null;

        string pagesString = AllPagesAsString;

        if (pagesString.Length < MaxPreviewLength)
            return pagesString + "...";

        int maxPreviewLength = MaxPreviewLength;
        for (int i = MaxPreviewLength; i <= Math.Clamp(MaxPreviewLength + 15, 0, pagesString.Length); i++)
        {
            maxPreviewLength = i;

            if (pagesString[i] == ' ')
                break;
        }

        return pagesString[..maxPreviewLength] + "...";
    }
}
