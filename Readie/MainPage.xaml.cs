namespace Readie;

public partial class MainPage : ContentPage
{
    public Command ReadCommand { get; }

    public MainPage()
    {
        ReadCommand = new Command(Read);
        InitializeComponent();
        BindingContext = this;
    }

    private async void Read()
    {
        await Shell.Current.GoToAsync("Preperation");
    }
}
