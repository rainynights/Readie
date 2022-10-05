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

		Routing.RegisterRoute("testPage", typeof(TextSelectionPage));

		return builder.Build();
	}
}
