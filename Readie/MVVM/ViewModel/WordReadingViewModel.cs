using Readie.MVVM.Model;
using Readie.Services;
using System.Diagnostics;

namespace Readie.MVVM.ViewModel;

public class WordReadingViewModel : ViewModelBase
{
    public Text Text { get; }
    public bool IsPlaying { get; set; }
    public Command TriggerPlayPauseCommand { get; }
    public ReadingOptions ReadingOptions { get; set; }

    public string WordsToDisplay
    {
        get => _wordsToDisplay;
        set => SetProperty(ref _wordsToDisplay, value);
    }

    private string _wordsToDisplay;

    public WordReadingViewModel()
    {
        Text = ConfigurationService.ConfigurationData.SelectedText;
        ReadingOptions = ConfigurationService.ConfigurationData.ReadingOptions;
        TriggerPlayPauseCommand = new Command(TriggerPlayPause);

        InitializeWordsToDisplay();
    }

    private void InitializeWordsToDisplay()
    {
        WordsToDisplay = Text?.AllPagesAsWords[ReadingOptions.WordIndex] ?? "No text";

        if (Text == null)
            return;

        _ = DisplayUntilStops(initRun: true);
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

    private async Task DisplayUntilStops(bool initRun = false)
    {
        float stepInterval = 60_000 * ReadingOptions.WordCountPerStep / ReadingOptions.WordsPerMinute;

        // Increase step count by one if wordCountPerStep is not a divisor to complete the remainder
        int totalStepCount = Text.AllPagesAsWords.Length / ReadingOptions.WordCountPerStep;
        if (Text.AllPagesAsWords.Length % ReadingOptions.WordCountPerStep > 0)
            totalStepCount++;

        // Retrieve the last step
        int stepIndex = ReadingOptions.WordIndex / ReadingOptions.WordCountPerStep;

        if (initRun)
        {
            int startIndex = stepIndex * ReadingOptions.WordCountPerStep;
            WordsToDisplay = string.Join(' ', (stepIndex != totalStepCount - 1) ? Text.AllPagesAsWords[startIndex..(startIndex + ReadingOptions.WordCountPerStep)] : Text.AllPagesAsWords[startIndex..]);
            return;
        }

        bool firstStep = true;
        Stopwatch stopwatch = Stopwatch.StartNew();
        // initRun buraya girmez çünkü IsPlaying'e basılmadı
        while (IsPlaying)
        {
            if (firstStep || stopwatch.Elapsed.TotalMilliseconds >= stepInterval)
            {
                int startIndex = stepIndex * ReadingOptions.WordCountPerStep;
                WordsToDisplay = string.Join(' ', (stepIndex != totalStepCount - 1) ? Text.AllPagesAsWords[startIndex..(startIndex + ReadingOptions.WordCountPerStep)] : Text.AllPagesAsWords[startIndex..]);

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

        ConfigurationService.ConfigurationData.ReadingOptions = ReadingOptions;
        _ = ConfigurationService.SaveConfiguration();

        stopwatch.Stop();
    }
}
