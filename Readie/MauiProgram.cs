using Readie.MVVM.View;

namespace Readie;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		MauiAppBuilder builder = MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("PTMono-Regular.ttf", "PTMonoRegular");
			});

		Routing.RegisterRoute("testPage", typeof(PreperationPage));

		return builder.Build();
	}
}
