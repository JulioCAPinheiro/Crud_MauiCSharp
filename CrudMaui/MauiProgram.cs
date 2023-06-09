using CrudMaui.Services;
using CrudMaui.View;
using CrudMaui.ViewModel;
using CrudMaui.Views;
using SQLiteDemo.ViewModels;

namespace CrudMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		//Services
		builder.Services.AddSingleton<IStudentService, StudentService>();

		//Views Registration

		builder.Services.AddSingleton<StudentListPage>();
		builder.Services.AddTransient<AddUpdateStudent>();

		//View Modles
		builder.Services.AddSingleton<StudentListPageVIewModel>();
		builder.Services.AddTransient<AddUpdateStudentDetailViewModel>();

		return builder.Build();
	}
}
