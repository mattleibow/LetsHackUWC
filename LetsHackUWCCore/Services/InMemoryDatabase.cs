using LetsHackUWCMauiApp.Models;
using System.Text.Json;

namespace LetsHackUWCMauiApp.Services;

public interface IDatabase
{
    List<Hackathon> GetHackathons();
    void AddHackathon(Hackathon hackathon);
}

public class InMemoryDatabase : IDatabase
{
    private List<Hackathon> hackathons = new List<Hackathon>();

    public List<Hackathon> GetHackathons()
    {
        return hackathons.ToList();
    }

    public void AddHackathon(Hackathon hackathon)
    {
        hackathons.Add(hackathon);
    }
}
