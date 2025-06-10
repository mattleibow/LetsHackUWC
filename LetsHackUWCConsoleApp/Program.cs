using Spectre.Console;

var hackathons = new List<string>();

var navigation = new List<Action>();
navigation.Add(Screen_MainMenu);

while (true)
{
    AnsiConsole.Clear();

    AnsiConsole.MarkupLine("[bold green]Welcome to Let's Hack UWC while Wouter is not here![/]");
    AnsiConsole.WriteLine();

    var screen = navigation.Last();
    
    screen.Invoke();
}

void Screen_MainMenu()
{
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("[blue]Home[/]");
    AnsiConsole.WriteLine();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[red]Main Menu[/]")
        .AddChoices(["Manage Hackathon", "Exit"]));
    
    switch (choice)
    {
        case "Manage Hackathon":
            navigation.Add(Screen_ManageHackathon);
            break;
        case "Exit":
            AnsiConsole.MarkupLine("Exiting...");
            Environment.Exit(0);
            break;
    }
}

void Screen_ManageHackathon()
{
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("Manage Hackathon");
    AnsiConsole.WriteLine();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Options")
        .AddChoices(
        [
            "Add Hackathon",
            "List Hackathons",
            "Remove Hackathon",
            "Manage Teams",
            "Back"
        ]));

    switch (choice)
    {
        case "Add Hackathon":
            AnsiConsole.WriteLine();
            var hackathonName = AnsiConsole.Ask<string>("Enter a name:");
            hackathons.Add(hackathonName);

            AnsiConsole.Progress()
                .Start(ctx =>
                {
                    // Define tasks
                    var task1 = ctx.AddTask("[green]Reticulating splines[/]");
                    var task2 = ctx.AddTask("[green]Folding space[/]");


                    while (!ctx.IsFinished)
                    {
                        task1.Increment(1.5);
                        task2.Increment(0.5);
                    
                        Thread.Sleep(100);
                    }
                });

            //AnsiConsole.Progress()
            //    .Start(async ctx =>
            //    {
            //        var addingTask = ctx.AddTask("Adding a new hackathon");

            //        addingTask.Pro

            //        AnsiConsole.MarkupLine($"You added a hackathon: {hackathonName}");

            //    });
            break;
        case "List Hackathons":
            navigation.Add(Screen_ListHackathons);
            break;
        case "Back":
            navigation.Remove(navigation.Last());
            break;
    }
}

void Screen_ListHackathons()
{
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine("List Hackathons");
    AnsiConsole.WriteLine();

    AnsiConsole.MarkupLine("Hackathons: ");
    foreach (var hackathon in hackathons)
    {
        AnsiConsole.MarkupLine($" - {hackathon}");
    }
    AnsiConsole.WriteLine();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Options")
        .AddChoices(
        [
            "Back"
        ]));

    switch(choice)
    {
        case "Back":
            navigation.Remove(navigation.Last());
            break;
    }
}
