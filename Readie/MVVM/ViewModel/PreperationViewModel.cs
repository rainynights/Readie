using Readie.MVVM.Model;

namespace Readie.MVVM.ViewModel;

[QueryProperty(nameof(SelectedText), nameof(SelectedText))]
public class PreperationViewModel : ViewModelBase
{
    public Command SelectTextCommand { get; }
    public Command SelectFileCommand { get; }
    public Command ReadCommand { get; }

    public string SelectedTextPreview => _selectedText?.GetPreview() ?? Text.DefaultPreview;

    private Text _selectedText;

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
    }

    private async void SelectText()
    {
        await Shell.Current.GoToAsync("TextSelection");
    }

    private void SelectFile()
    {

    }

    private void Read()
    {

    }
}
