using Readie.MVVM.Model;
using Readie.Services;
using System.Diagnostics;

namespace Readie.MVVM.ViewModel;

public class WordReadingViewModel : ViewModelBase
{
    public Text Text { get; }
    public ReadingOptions ReadingOptions { get; set; }
    public Command TriggerPlayPauseCommand { get; }

    public bool IsPlaying { get; set; }

    private string _wordsToDisplay;
    public string WordsToDisplay
    {
        get => _wordsToDisplay;
        set => SetProperty(ref _wordsToDisplay, value);
    }

    public WordReadingViewModel()
    {
        Text = ConfigurationService.Text;
        ReadingOptions = ConfigurationService.ReadingOptions;

        InitializeWordsToDisplay();

        TriggerPlayPauseCommand = new Command(TriggerPlayPause);
    }

    private void InitializeWordsToDisplay()
    {
        WordsToDisplay = Text?.AllPagesAsWords[ReadingOptions.WordIndex] ?? "No text";

        if (Text == null)
            return;

        // TODO burası kod tekrarı hoş değil
        int totalStepCount = (int)Text.AllPagesAsWords.Length / ReadingOptions.WordCountPerStep;
        int stepIndex = (int)ReadingOptions.WordIndex / ReadingOptions.WordCountPerStep;
        int startIndex = stepIndex * ReadingOptions.WordCountPerStep;
        if (stepIndex != totalStepCount - 1)
            WordsToDisplay = string.Join(" ", Text.AllPagesAsWords[startIndex..(startIndex + ReadingOptions.WordCountPerStep)]);
        else
            WordsToDisplay = string.Join(" ", Text.AllPagesAsWords[startIndex..]);
        // ------
    }

    private void TriggerPlayPause()
    {
        if (Text == null)
            return;

        IsPlaying = !IsPlaying;
        OnPropertyChanged(nameof(IsPlaying));

        if (IsPlaying)
            _ = DisplayUntilStops();
    }

    private async Task DisplayUntilStops()
    {
        int totalStepCount = (int)Text.AllPagesAsWords.Length / ReadingOptions.WordCountPerStep;
        if (Text.AllPagesAsWords.Length % ReadingOptions.WordCountPerStep > 0)
            totalStepCount++;

        int stepIndex = (int)ReadingOptions.WordIndex / ReadingOptions.WordCountPerStep;

        float stepInterval = 60_000 * ReadingOptions.WordCountPerStep / ReadingOptions.WordsPerMinute;
        bool firstStep = true;
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (IsPlaying)
        {
            if (firstStep || stopwatch.Elapsed.TotalMilliseconds >= stepInterval)
            {
                int startIndex = stepIndex * ReadingOptions.WordCountPerStep;
                if (stepIndex != totalStepCount - 1)
                    WordsToDisplay = string.Join(" ", Text.AllPagesAsWords[startIndex..(startIndex + ReadingOptions.WordCountPerStep)]);
                else
                    WordsToDisplay = string.Join(" ", Text.AllPagesAsWords[startIndex..]);

                stepIndex++;
                if (stepIndex == totalStepCount)
                {
                    stepIndex = 1; // Will subtract one

                    IsPlaying = false;
                    OnPropertyChanged(nameof(IsPlaying));

                    break;
                }

                firstStep = false;
                stopwatch.Restart();
            }

            await Task.Delay(1);
        }

        ReadingOptions.WordIndex = (stepIndex - 1) * ReadingOptions.WordCountPerStep;

        ConfigurationService.ReadingOptions = ReadingOptions;
        ConfigurationService.SaveConfiguration();

        stopwatch.Stop();
    }
}
