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

		builder.Services.AddSingleton<PreperationPage>();

		Routing.RegisterRoute("Preperation", typeof(PreperationPage));
		Routing.RegisterRoute("TextSelection", typeof(TextSelectionPage));

		return builder.Build();
	}
}
