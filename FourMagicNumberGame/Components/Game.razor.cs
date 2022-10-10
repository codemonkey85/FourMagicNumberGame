namespace FourMagicNumberGame.Components;

public partial class Game
{
    private int? _numberChosen = 0;

    private readonly List<string> _outputLines = new();

    private void DoTheMagic()
    {
        if ((_numberChosen ?? 0) < 0)
        {
            return;
        }

        var currentNumber = _numberChosen ?? 0;
        _outputLines.Clear();
        var currentLength = NumbersToWords.ConvertToWords(currentNumber, true).Length;
        Console.WriteLine(currentLength);
        if (currentLength == 4)
        {
            _outputLines.Add($"{currentNumber} is {currentLength}");
        }
        else
        {
            do
            {
                _outputLines.Add($"{currentNumber} is {currentLength}");
                currentNumber = currentLength;
                currentLength = NumbersToWords.ConvertToWords(currentNumber, true).Length;
            } while (currentLength != 4);

            _outputLines.Add($"{currentNumber} is {currentLength}");
        }
    }
}
