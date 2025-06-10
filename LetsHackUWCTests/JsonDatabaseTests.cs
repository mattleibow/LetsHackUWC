using LetsHackUWCMauiApp.Models;
using LetsHackUWCMauiApp.Services;

namespace LetsHackUWCTests;

public class JsonDatabaseTests
{
    [Fact]
    public void AddingHackathonAddsToDatabase()
    {
        var db = new JsonDatabase();

        db.AddHackathon(new Hackathon { Name = "Test Hack" });

        var loadedHacks = db.GetHackathons();
        Assert.Single(loadedHacks);
        Assert.Equal("Test Hack", loadedHacks[0].Name);
    }

    [Fact]
    public void AddingHackathonSavesDatabase()
    {
        {
            var db = new JsonDatabase();
            db.AddHackathon(new Hackathon { Name = "Test Hack" });
        }

        {
            var db = new JsonDatabase();
            var loadedHacks = db.GetHackathons();
            Assert.Single(loadedHacks);
            Assert.Equal("Test Hack", loadedHacks[0].Name);
        }
    }
}