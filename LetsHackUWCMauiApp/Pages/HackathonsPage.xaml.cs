using LetsHackUWCMauiApp.ViewModels;
using System.Collections.ObjectModel;

namespace LetsHackUWCMauiApp.Pages;

public partial class HackathonsPage : ContentPage
{
    public HackathonsPage(HackathonManagerViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        Appearing += (sender, e) =>
        {
            viewModel.OnAppearing();
        };
    }
}
