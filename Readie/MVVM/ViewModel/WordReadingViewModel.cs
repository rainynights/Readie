using Readie.MVVM.Model;

namespace Readie.MVVM.ViewModel;

[QueryProperty(nameof(ReadingOptions), nameof(ReadingOptions))]
[QueryProperty(nameof(Text), nameof(Text))]
public class WordReadingViewModel : ViewModelBase
{
    public Command TriggerPlayPauseCommand { get; }
    public ReadingOptions ReadingOptions { get; set; }
    public bool IsPlaying => _isPlaying;

    private bool _isPlaying;

    private Text _text;
    public Text Text
    {
        get => _text;
        set
        {
            _text = value;
            WordsToDisplay = _text?.AllPagesAsWords[ReadingOptions.WordIndex] ?? "No text";

            if (_text == null)
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

            OnPropertyChanged();
        }
    }

    private string _wordsToDisplay;
    public string WordsToDisplay
    {
        get => _wordsToDisplay;
        set
        {
            _wordsToDisplay = value;
            OnPropertyChanged();
        }
    }

    public WordReadingViewModel()
    {
        TriggerPlayPauseCommand = new Command(TriggerPlayPause);
    }

    private void TriggerPlayPause()
    {
        if (Text == null)
            return;

        SetProperty<bool>(ref _isPlaying, !_isPlaying, nameof(IsPlaying));

        // TODO cancel all other tasks
        _ = DisplayUntilStops();
    }

    private async Task DisplayUntilStops()
    {
        int totalStepCount = (int)Text.AllPagesAsWords.Length / ReadingOptions.WordCountPerStep;
        if (Text.AllPagesAsWords.Length % ReadingOptions.WordCountPerStep > 0)
            totalStepCount++;

        int stepIndex = (int)ReadingOptions.WordIndex / ReadingOptions.WordCountPerStep;

        while (IsPlaying)
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
                SetProperty<bool>(ref _isPlaying, false, nameof(IsPlaying));
                break;
            }

            // TODO wpm yap
            await Task.Delay(1000 / ReadingOptions.Speed);
        }

        ReadingOptions.WordIndex = (stepIndex - 1) * ReadingOptions.WordCountPerStep;
        // TODO save step index vs.
    }
}
