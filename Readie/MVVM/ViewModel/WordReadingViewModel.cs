using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.ViewModel;

public class WordReadingViewModel : ViewModelBase
{
	private bool _isPlaying;

	public Command TriggerPlayPauseCommand { get; }

	public bool IsPlaying => _isPlaying;

	public WordReadingViewModel()
	{
		TriggerPlayPauseCommand = new Command(TriggerPlayPause);
	}

	private void TriggerPlayPause()
	{
		SetProperty<bool>(ref _isPlaying, !_isPlaying, nameof(IsPlaying));
	}
}
