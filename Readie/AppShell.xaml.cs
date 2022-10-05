namespace Readie;

public partial class AppShell : Shell
{
	public Command ChangeThemeCommand { get; }
	
	public ImageSource Moon { get; }
	public ImageSource Sun { get; }

	public AppShell()
	{
		ChangeThemeCommand = new Command(ChangeTheme);
		Moon = "moon.png";
		Sun = "sun.png";
        InitializeComponent();
		BindingContext = this;
	}

	private void ChangeTheme()
	{
		Application.Current.UserAppTheme = Application.Current.RequestedTheme == AppTheme.Light
			? AppTheme.Dark
			: AppTheme.Light;
    }
}
