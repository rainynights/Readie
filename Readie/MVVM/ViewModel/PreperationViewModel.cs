using Readie.MVVM.Model;

namespace Readie.MVVM.ViewModel;

[QueryProperty(nameof(SelectedText), nameof(SelectedText))]
public class PreperationViewModel : ViewModelBase
{
    public const int Increment = 10;
    public const int MinWordsPerMinute = 30;
    public const int MaxWordsPerMinute = 320;

    private Text _selectedText;
    private int _wordsPerMinute;

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

    public int WordsPerMinute
    {
        get => _wordsPerMinute;
        set => SetProperty(ref _wordsPerMinute, value);
    }

    public int[] WordsToShow { get; } = new[] { 1, 2, 3 };
    public int SelectedWordsToShow { get; set; }

    public Command SelectTextCommand { get; }
    public Command SelectFileCommand { get; }
    public Command ReadCommand { get; }
    public Command DecreaseWPMCommand { get; }
    public Command IncreaseWPMCommand { get; }

    public PreperationViewModel()
    {
        SelectTextCommand = new Command(SelectText);
        SelectFileCommand = new Command(SelectFile);
        ReadCommand = new Command(Read);

        _wordsPerMinute = MinWordsPerMinute;
        DecreaseWPMCommand = new Command(() => WordsPerMinute = Math.Clamp(WordsPerMinute - Increment, MinWordsPerMinute, MaxWordsPerMinute));
        IncreaseWPMCommand = new Command(() => WordsPerMinute = Math.Clamp(WordsPerMinute + Increment, MinWordsPerMinute, MaxWordsPerMinute));
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
            {"ReadingOptions", new ReadingOptions(4, 0 ,2) }
        });
    }
}
