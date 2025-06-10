using LetsHackUWCMauiApp.Models;
using System.Text.Json;

namespace LetsHackUWCMauiApp.Services;

public class JsonDatabase : IDatabase
{
    private List<Hackathon>? hackathons;

    public List<Hackathon> GetHackathons()
    {
        LoadData();

        // return the data
        return hackathons!;
    }

    public void AddHackathon(Hackathon hackathon)
    {
        LoadData();

        hackathons!.Add(hackathon);

        using var file = File.Create("hackathon-db.json");
        JsonSerializer.Serialize(file, hackathons);
    }

    private void LoadData()
    {
        // Try load the data
        if (hackathons is null)
        {
            try
            {
                using var file = File.OpenRead("hackathon-db.json");
                hackathons = JsonSerializer.Deserialize<List<Hackathon>>(file);
            }
            catch
            {
            }
        }

        // maybe there is no data
        if (hackathons is null)
        {
            hackathons = new List<Hackathon>();
        }
    }
}
