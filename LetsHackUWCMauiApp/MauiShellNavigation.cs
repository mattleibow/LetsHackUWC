using LetsHackUWCMauiApp.Services;

public class MauiShellNavigation : IShellNavigation
{
    public Task GoToAsync(string location)
    {
        return Shell.Current.GoToAsync(location);
    }
}
