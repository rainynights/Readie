namespace Readie.MVVM.Model;

public class Text
{
    public const string DefaultPreview = "Preview..";

    public string Title { get; set; }
    public string[] Pages { get; set; }

    private const int MaxPreviewLength = 100;
    //private const int MaxPageLength = 800;

    public string GetPreview()
    {
        if (Pages.Length < 0)
            return null;

        string pagesString = string.Join(" ", Pages);

        if (pagesString.Length < MaxPreviewLength)
            return pagesString + "...";

        int maxPreviewLength = MaxPreviewLength;
        for (int i = MaxPreviewLength; i <= Math.Clamp(MaxPreviewLength + 15, 0, pagesString.Length); i++)
        {
            maxPreviewLength = i;
            if (pagesString[i] == ' ' || pagesString[i] == '\r' || pagesString[i] == '\n')
                break;
        }

        return pagesString[..maxPreviewLength] + "...";
    }
}
