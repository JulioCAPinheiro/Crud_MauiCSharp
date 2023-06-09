using CrudMaui.ViewModel;

namespace CrudMaui.View;

public partial class StudentListPage : ContentPage
{
	private StudentListPageVIewModel _viewMode;
	public StudentListPage(StudentListPageVIewModel viewModel)
	{
		InitializeComponent();
		_viewMode = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetStudentsListCommand.Execute(null);
    }
}