using Xunit;

namespace FourMagicNumberGame.Tests;

public class NumbersToWordsTests
{
    [Theory]
    [InlineData(0, "Zero")]
    [InlineData(4, "Four")]
    [InlineData(11, "Eleven")]
    [InlineData(21, "Twenty One")]
    [InlineData(100, "One Hundred")]
    [InlineData(123, "One Hundred Twenty Three")]
    [InlineData(1000, "One Thousand")]
    [InlineData(1000000, "One Million")]
    [InlineData(1000000000, "One Billion")]
    [InlineData(int.MaxValue, "Two Billion One Hundred Forty Seven Million Four Hundred Eighty Three Thousand Six Hundred Forty Seven")]
    public void ConvertsNumbersWithAndWithoutSpaces(int number, string expected)
    {
        Assert.Equal(expected, NumbersToWords.ConvertToWords(number));
        Assert.Equal(expected.Replace(" ", string.Empty), NumbersToWords.ConvertToWords(number, removeSpaces: true));
    }
}
