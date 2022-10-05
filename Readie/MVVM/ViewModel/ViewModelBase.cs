using CommunityToolkit.Mvvm.ComponentModel;

namespace Readie.MVVM.ViewModel;

public abstract partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string _title;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    public bool IsNotBusy => !_isBusy;
}
