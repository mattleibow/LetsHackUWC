using LetsHackUWCMauiApp.Models;
using LetsHackUWCMauiApp.Services;
using LetsHackUWCMauiApp.ViewModels;
using NSubstitute;

namespace LetsHackUWCTests;

public class HackathonManagerViewModelTest
{
    [Fact]
    public void LoadingViewModelLoadsData()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        db.GetHackathons()
            .Returns(new List<Hackathon>
            {
                new Hackathon { Name = "Test Hack" }
            });

        var shell = Substitute.For<IShellNavigation>();
        var managerVM = Substitute.For<HackathonManagerViewModel>(db, shell);

        // Act
        managerVM.OnAppearing();

        // Assert
        Assert.Single(managerVM.Hackathons);
        Assert.Equal("Test Hack", managerVM.Hackathons[0].Name);
    }
}
