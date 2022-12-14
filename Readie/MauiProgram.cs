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
				fonts.AddFont("PTMono-Regular.ttf", "PTMonoRegular");
			});

		Routing.RegisterRoute("Preperation", typeof(PreperationPage));
		Routing.RegisterRoute("TextSelection", typeof(TextSelectionPage));
		Routing.RegisterRoute("WordReading", typeof(WordReadingPage));

		return builder.Build();
	}
}
