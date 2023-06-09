using CrudMaui.ViewModel;
using SQLiteDemo.ViewModels;

namespace CrudMaui.Views;

public partial class AddUpdateStudent : ContentPage
{
	public AddUpdateStudent(AddUpdateStudentDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}