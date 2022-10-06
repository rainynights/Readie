using Readie.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            WordsToDisplay = _text?.Pages[0].Split(" ")[0] ?? "No text";
            OnPropertyChanged();
        }
    }


    private int _wordIndex;
    public int WordIndex
    {
        get => _wordIndex;
        set
        {
            _wordIndex = value;
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
    }
}
