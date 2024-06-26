namespace FourMagicNumberGame.Shared;

public partial class MainLayout
{
    private const string AppTitle = "Four Is The Magic Number!";

    private bool isDarkMode;
    private MudThemeProvider? mudThemeProvider;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && mudThemeProvider is not null)
        {
            isDarkMode = await mudThemeProvider.GetSystemPreference();
            await mudThemeProvider.WatchSystemPreference(OnSystemPreferenceChanged);
            StateHasChanged();
        }
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

    private async Task OnSystemPreferenceChanged(bool newValue)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

    {
        isDarkMode = newValue;
        StateHasChanged();
    }
}
