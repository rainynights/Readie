namespace Readie;

public partial class AppShell : Shell
{
	public Command ChangeThemeCommand { get; }
	public string ThemeIcon => (Application.Current.RequestedTheme == AppTheme.Light) ? "sun.png" : "moon.png";

	public AppShell()
	{
		ChangeThemeCommand = new Command(ChangeTheme);
        InitializeComponent();
		BindingContext = this;
	}

	private void ChangeTheme()
	{
		Application.Current.UserAppTheme = (Application.Current.RequestedTheme == AppTheme.Light) ? AppTheme.Dark : AppTheme.Light;
		OnPropertyChanged(nameof(ThemeIcon));
    }
}
