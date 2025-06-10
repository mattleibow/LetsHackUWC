using LetsHackUWCMauiApp.Models;
using LetsHackUWCMauiApp.Services;
using System.Collections.ObjectModel;

namespace LetsHackUWCMauiApp.ViewModels;

public class HackathonManagerViewModel
{
    private readonly IDatabase database;
    private readonly IShellNavigation shell;

    public HackathonManagerViewModel(IDatabase database, IShellNavigation shell)
    {
        this.database = database;
        this.shell = shell;
        NewHackathonCommand = new Command(NewHackathon);
    }

    public ObservableCollection<Hackathon> Hackathons { get; } = new ObservableCollection<Hackathon>();

    public Command NewHackathonCommand { get; }

    public void OnAppearing()
    {
        var hackathons = database.GetHackathons();

        Hackathons.Clear();
        foreach (var hack in hackathons)
            Hackathons.Add(hack);
    }

    private async void NewHackathon()
    {
        await shell.GoToAsync("new");
    }
}
