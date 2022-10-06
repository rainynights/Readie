using Readie.MVVM.Model;

namespace Readie.MVVM.ViewModel;

[QueryProperty(nameof(SelectedText), nameof(SelectedText))]
public class PreperationViewModel : ViewModelBase
{
    private Text _selectedText;

    public Command SelectTextCommand { get; }
    public Command SelectFileCommand { get; }
    public Command ReadCommand { get; }

    public string SelectedTextPreview => _selectedText?.GetPreview() ?? Text.DefaultPreview;
    public Text SelectedText
    {
        get => _selectedText;
        set
        {
            _selectedText = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SelectedTextPreview));
        }
    }

    public PreperationViewModel()
    {
        SelectTextCommand = new Command(SelectText);
        SelectFileCommand = new Command(SelectFile);
        ReadCommand = new Command(Read);
    }

    private async void SelectText()
    {
        await Shell.Current.GoToAsync("TextSelection");
    }

    private void SelectFile()
    {

    }

    private async void Read()
    {
        await Shell.Current.GoToAsync("WordReading", parameters: new Dictionary<string, object>
        {
            {"Text" ,SelectedText },
            {"ReadingOptions", new ReadingOptions() }
        });
    }
}
