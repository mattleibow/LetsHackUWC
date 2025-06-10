using LetsHackUWCMauiApp.ViewModels;

namespace LetsHackUWCMauiApp.Pages;

public partial class NewHackathonPage : ContentPage
{
	public NewHackathonPage(NewHackathonViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}