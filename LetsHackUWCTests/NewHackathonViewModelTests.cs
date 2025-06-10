using LetsHackUWCMauiApp.Models;
using LetsHackUWCMauiApp.Services;
using LetsHackUWCMauiApp.ViewModels;
using NSubstitute;

namespace LetsHackUWCTests;

public class NewHackathonViewModelTests
{
    [Fact]
    public void AddingHackathonSavesSingleHackathonToDatabase()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        var shell = Substitute.For<IShellNavigation>();
        var newHackVM = Substitute.For<NewHackathonViewModel>(db, shell);

        // Act
        newHackVM.Name = "Test Hack";
        newHackVM.Description = "Test Description";
        newHackVM.SaveHackathonCommand.Execute(null);

        // Assert
        db.Received(1).AddHackathon(Arg.Any<Hackathon>());
    }

    [Fact]
    public void AddingHackathonSavesCorrectHackathonToDatabase()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        var shell = Substitute.For<IShellNavigation>();
        var newHackVM = Substitute.For<NewHackathonViewModel>(db, shell);

        // Act
        newHackVM.Name = "Test Hack";
        newHackVM.Description = "Test Description";
        newHackVM.SaveHackathonCommand.Execute(null);

        // Assert
        db.Received(1).AddHackathon(Arg.Is<Hackathon>(hack =>
            hack.Name == "Test Hack" && hack.Description == "Test Description"));
    }

    [Fact]
    public void AddingHackathonNavigatesBack()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        var shell = Substitute.For<IShellNavigation>();
        var newHackVM = Substitute.For<NewHackathonViewModel>(db, shell);

        // Act
        newHackVM.Name = "Test Hack";
        newHackVM.Description = "Test Description";
        newHackVM.SaveHackathonCommand.Execute(null);

        // Assert
        shell.Received(1)
            .GoToAsync(Arg.Is<string>(loc => loc == ".."));
    }

    [Fact]
    public void AddingHackathonSavesCorrectStartDate()
    {
        // Arrange
        var db = Substitute.For<IDatabase>();
        var shell = Substitute.For<IShellNavigation>();
        var newHackVM = Substitute.For<NewHackathonViewModel>(db, shell);

        // Act
        newHackVM.Name = "Test Hack";
        newHackVM.StartDate = new DateTime(2025, 06, 10);
        newHackVM.StartTime = TimeSpan.FromHours(15, 04);
        newHackVM.SaveHackathonCommand.Execute(null);

        // Assert
        db.Received(1).AddHackathon(Arg.Is<Hackathon>(hack =>
            hack.StartDate == new DateTime(2025, 06, 10, 15, 04, 00)));
    }
}
