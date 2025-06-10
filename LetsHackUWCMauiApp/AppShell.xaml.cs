using LetsHackUWCMauiApp.Pages;

namespace LetsHackUWCMauiApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("hackathons/new", typeof(NewHackathonPage));
    }
}
