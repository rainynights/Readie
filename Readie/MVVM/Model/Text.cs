namespace Readie.MVVM.Model;

public class Text
{
    public const string DefaultPreview = "Preview..";

    public string Title { get; set; }
    public string[] Pages { get; set; }

    private const int MaxPreviewLength = 100;

    public string GetPreview()
    {
        if (Pages.Length < 0)
            return string.Empty;

        string joinedPages = string.Join(" ", Pages);
        return joinedPages[..(joinedPages.Length > MaxPreviewLength ? MaxPreviewLength : joinedPages.Length)] + "...";
    }
}
