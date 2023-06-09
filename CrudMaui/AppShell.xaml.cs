using CrudMaui.ViewModel;
using CrudMaui.Views;

namespace CrudMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdateStudent),typeof(AddUpdateStudent));
	}
}
