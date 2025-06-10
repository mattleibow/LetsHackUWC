using LetsHackUWCMauiApp.Models;
using LetsHackUWCMauiApp.Services;

namespace LetsHackUWCMauiApp.ViewModels;

public class NewHackathonViewModel
{
    private readonly IDatabase database;
    private readonly IShellNavigation shell;

    public NewHackathonViewModel(IDatabase database, IShellNavigation shell)
    {
        this.database = database;
        this.shell = shell;

        SaveHackathonCommand = new Command(SaveHackathon);
    }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime StartDate { get; set; }
    
    public TimeSpan StartTime { get; set; }

    public Command SaveHackathonCommand { get; }

    async void SaveHackathon()
    {
        var hackathon = new Hackathon
        {
            Name = Name,
            Description = Description,
            StartDate = StartDate.Add(StartTime)
        };

        database.AddHackathon(hackathon);

        await shell.GoToAsync("..");
    }
}
