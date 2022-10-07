﻿using Readie.MVVM.Model;

namespace Readie.MVVM.ViewModel;

[QueryProperty(nameof(Text), nameof(Text))]
[QueryProperty(nameof(ReadingOptions), nameof(ReadingOptions))]
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
            WordsToDisplay = _text?.AllPagesAsWords[ReadingOptions.StepIndex] ?? "No text";
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
        SetProperty<bool>(ref _isPlaying, !_isPlaying, nameof(IsPlaying));

        _ = DisplayUntilStops();
    }

    private async Task DisplayUntilStops()
    {
        int totalStepCount = (int)Text.AllPagesAsWords.Length / ReadingOptions.WordCountPerStep;
        if (Text.AllPagesAsWords.Length % ReadingOptions.WordCountPerStep > 0)
            totalStepCount++;

        while (IsPlaying)
        {
            int startIndex = ReadingOptions.StepIndex * ReadingOptions.WordCountPerStep;
            if (ReadingOptions.StepIndex != totalStepCount - 1)
                WordsToDisplay = string.Join(" ", Text.AllPagesAsWords[startIndex..(startIndex + ReadingOptions.WordCountPerStep)]);
            else
                WordsToDisplay = string.Join(" ", Text.AllPagesAsWords[startIndex..]);

            // TODO wpm yap
            await Task.Delay(1000 / ReadingOptions.Speed);
            ReadingOptions = new ReadingOptions(ReadingOptions.Speed, ReadingOptions.StepIndex + 1, ReadingOptions.WordCountPerStep);
        }
    }
}
