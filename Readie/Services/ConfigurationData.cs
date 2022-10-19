using Readie.MVVM.Model;

namespace Readie.Services;

public class ConfigurationData
{
    public Text[] Texts { get; set; }
    public Text SelectedText { get; set; }
    public ReadingOptions ReadingOptions { get; set; }
}
