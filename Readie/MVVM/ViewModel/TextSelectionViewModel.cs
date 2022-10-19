using Readie.MVVM.Model;
using Readie.Services;

namespace Readie.MVVM.ViewModel;
public class TextSelectionViewModel : ViewModelBase
{
    public Text[] Texts { get; }
    public Command SelectCommand { get; }

    public TextSelectionViewModel()
    {
        SelectCommand = new Command<Text>(Select);

        Texts = ConfigurationService.ConfigurationData.Texts;
        OnPropertyChanged(nameof(Texts));
    }

    private void Select(Text selectedText)
    {
        ConfigurationService.ConfigurationData.SelectedText = selectedText;
        _ = ConfigurationService.SaveConfiguration();
        Shell.Current.GoToAsync("Preperation");
    }
}
