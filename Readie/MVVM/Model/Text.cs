using System.Text;
using System.Text.RegularExpressions;

namespace Readie.MVVM.Model;

public class Text
{
    public const string DefaultPreview = "Preview..";
    public string Title { get; set; }
    public string[] Pages { get; set; }
    public string[] AllPagesAsWords
    {
        get
        {
            var allPagesAsString = GetAllPagesAsString();
            if (allPagesAsString == null)
                return null;

            if (_allPagesAsWords == null)
                _allPagesAsWords = allPagesAsString.Split(" ");

            return _allPagesAsWords;
        }
    }

    private string[] _allPagesAsWords;
    private const int MaxPreviewLength = 100;

    private string GetAllPagesAsString()
    {
        if (Pages == null || Pages.Any() == false)
            return null;

        StringBuilder pagesStringBuiler = new StringBuilder();
        foreach (var page in Pages)
        {
            if (string.IsNullOrWhiteSpace(page))
                continue;

            string modifiedPage = page.Replace("\n", " ").Replace("\r", " ");
            modifiedPage = Regex.Replace(modifiedPage, @"\s+", " ");
            modifiedPage = modifiedPage.TrimEnd();

            pagesStringBuiler.Append(modifiedPage + " ");
        }

        return pagesStringBuiler.ToString().TrimEnd();
    }

    public string GetPreview()
    {
        if (Pages.Length < 0)
            return null;

        string pagesString = GetAllPagesAsString();

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
