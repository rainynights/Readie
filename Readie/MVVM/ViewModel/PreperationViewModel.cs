using Readie.MVVM.Model;
using Readie.Services;

namespace Readie.MVVM.ViewModel;

public class PreperationViewModel : ViewModelBase
{
    public const int Increment = 10;
    public const int MinWordsPerMinute = 30;
    public const int MaxWordsPerMinute = 500;
    public Command ReadCommand { get; set; }
    public Command SelectTextCommand { get; set; }
    public Command SelectFileCommand { get; set; }
    public Command DecreaseWPMCommand { get; set; }
    public Command IncreaseWPMCommand { get; set; }
    public int[] WordCountsPerStep { get; } = new[] { 1, 2, 3, 4 };
    public string SelectedTextPreview => SelectedText?.GetPreview() ?? Text.DefaultPreview;

    public Text SelectedText
    {
        get => _selectedText;
        set => SetProperty(ref _selectedText, value);
    }
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

    private Text _selectedText;
    private int _wordsPerMinute;
    private int _selectedWordCountPerStep;

    public PreperationViewModel()
    {
        InitializeCommands();
        InitializeWordSelection();
    }

    private void InitializeCommands()
    {
        ReadCommand = new Command(Read);
        SelectTextCommand = new Command(SelectText);
        SelectFileCommand = new Command(SelectFile);
        DecreaseWPMCommand = new Command(() => WordsPerMinute = Math.Clamp(WordsPerMinute - Increment, MinWordsPerMinute, MaxWordsPerMinute));
        IncreaseWPMCommand = new Command(() => WordsPerMinute = Math.Clamp(WordsPerMinute + Increment, MinWordsPerMinute, MaxWordsPerMinute));
    }

    private void InitializeWordSelection()
    {
        SelectedText = ConfigurationService.ConfigurationData.SelectedText;
        WordsPerMinute = ConfigurationService.ConfigurationData.ReadingOptions.WordsPerMinute;
        SelectedWordCountPerStep = ConfigurationService.ConfigurationData.ReadingOptions.WordCountPerStep;
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
