using Readie.MVVM.Model;
using Readie.Services;

namespace Readie.MVVM.ViewModel;

public class PreperationViewModel : ViewModelBase
{
    public const int Increment = 10;
    public const int MinWordsPerMinute = 30;
    public const int MaxWordsPerMinute = 500;
    public int[] WordCountsPerStep { get; } = new[] { 1, 2, 3, 4 };
    public Command SelectTextCommand { get; }
    public Command SelectFileCommand { get; }
    public Command ReadCommand { get; }
    public Command DecreaseWPMCommand { get; }
    public Command IncreaseWPMCommand { get; }
    public string SelectedTextPreview => SelectedText?.GetPreview() ?? Text.DefaultPreview;

    private Text _selectedText;
    public Text SelectedText
    {
        get => _selectedText;
        set => SetProperty(ref _selectedText, value);
    }


    private int _wordsPerMinute;
    public int WordsPerMinute
    {
        get => _wordsPerMinute;
        set
        {
            ConfigurationService.ConfigurationData.ReadingOptions.WordsPerMinute = value;
            SetProperty(ref _wordsPerMinute, value);
            _ = ConfigurationService.SaveConfiguration();
        }
    }

    private int _selectedWordCountPerStep;
    public int SelectedWordCountPerStep
    {
        get => _selectedWordCountPerStep;
        set
        {
            ConfigurationService.ConfigurationData.ReadingOptions.WordCountPerStep = value;
            _ = ConfigurationService.SaveConfiguration();
            SetProperty(ref _selectedWordCountPerStep, value);
        }
    }

    public PreperationViewModel()
    {
        SelectedText = ConfigurationService.ConfigurationData.SelectedText;
        WordsPerMinute = ConfigurationService.ConfigurationData.ReadingOptions.WordsPerMinute;
        SelectedWordCountPerStep = ConfigurationService.ConfigurationData.ReadingOptions.WordCountPerStep;
        OnPropertyChanged(nameof(SelectedWordCountPerStep));

        ReadCommand = new Command(Read);
        SelectTextCommand = new Command(SelectText);
        SelectFileCommand = new Command(SelectFile);
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
        await Shell.Current.GoToAsync("WordReading");
    }
}
