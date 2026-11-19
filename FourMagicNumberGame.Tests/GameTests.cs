using Bunit;
using FourMagicNumberGame.Components;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using Xunit;

namespace FourMagicNumberGame.Tests;

public class GameTests
{
    private static BunitContext CreateContext()
    {
        var context = new BunitContext();
        context.Services.AddMudServices();
        context.JSInterop.Mode = JSRuntimeMode.Loose;
        return context;
    }

    [Theory]
    [InlineData("0", "0 is 4")]
    [InlineData("4", "4 is 4")]
    [InlineData("123", "123 is 21|21 is 9|9 is 4")]
    [InlineData("1000", "1000 is 11|11 is 6|6 is 3|3 is 5|5 is 4")]
    public async Task PlaysUntilFour(string number, string expectedSteps)
    {
        await using var context = CreateContext();
        var game = context.Render<Game>();

        game.Find("input").Change(number);
        game.FindAll("button").Single(button => button.TextContent.Trim() == "Do The Magic").Click();

        var lines = game.FindComponents<MudText>().Skip(1).Select(text => text.Find("*").TextContent.Trim());
        Assert.Equal(expectedSteps.Split('|').Append("Four is the magic number!"), lines);
    }

    [Fact]
    public async Task PlayingAgainReplacesPreviousResults()
    {
        await using var context = CreateContext();
        var game = context.Render<Game>();
        game.Find("input").Change("123");
        game.FindAll("button").Single(button => button.TextContent.Trim() == "Do The Magic").Click();

        game.Find("input").Change("4");
        game.FindAll("button").Single(button => button.TextContent.Trim() == "Do The Magic").Click();

        var lines = game.FindComponents<MudText>().Skip(1).Select(text => text.Find("*").TextContent.Trim());
        Assert.Equal(["4 is 4", "Four is the magic number!"], lines);
    }
}
