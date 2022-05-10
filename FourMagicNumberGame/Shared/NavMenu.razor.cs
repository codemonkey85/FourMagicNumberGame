namespace FourMagicNumberGame.Shared;

public partial class NavMenu
{
    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : string.Empty;

    private void ToggleNavMenu() => collapseNavMenu = !collapseNavMenu;
}
