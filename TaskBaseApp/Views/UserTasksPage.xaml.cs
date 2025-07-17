using TaskBaseApp.ViewModels;

namespace TaskBaseApp.Views;

public partial class UserTasksPage : ContentPage
{
	public UserTasksPage(UserTasksPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		//	var vm = BindingContext as UserTasksPageViewModel;
		//	vm?.LoadDataCommand.Execute(null);
		//}
	}
}