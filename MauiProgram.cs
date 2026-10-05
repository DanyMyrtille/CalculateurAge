using CalculateurAge.ViewModels;

namespace CalculateurAge;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder().UseMauiApp<App>();
        builder.Services.AddTransient<MainPage>().AddTransient<MainViewModel>();
        builder.Services.AddTransient<ResultPage>().AddTransient<ResultViewModel>();
        return builder.Build();
    }
}
