using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Readie.MVVM.ViewModel;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    protected virtual bool SetProperty<T>(ref T source, T value, [CallerMemberName] string name = null)
    {
        if (EqualityComparer<T>.Default.Equals(source, value))
            return false;

        source = value;
        OnPropertyChanged(name);
        return true;
    }
}
