namespace FourMagicNumberGame.Components;

public partial class Game
{
    private int? numberChosen = 0;

    private readonly List<string> outputLines = new();

    private void DoTheMagic()
    {
        if ((numberChosen ?? 0) < 0)
        {
            return;
        }
        var currentNumber = numberChosen ?? 0;
        outputLines.Clear();
        var currentLength = NumbersToWords.ConvertToWords(currentNumber, true).Length;
        Console.WriteLine(currentLength);
        if (currentLength == 4)
        {
            outputLines.Add($"{currentNumber} is {currentLength}");
        }
        else
        {
            do
            {
                outputLines.Add($"{currentNumber} is {currentLength}");
                currentNumber = currentLength;
                currentLength = NumbersToWords.ConvertToWords(currentNumber, true).Length;
            }
            while (currentLength != 4);
            outputLines.Add($"{currentNumber} is {currentLength}");
        }
    }
}
