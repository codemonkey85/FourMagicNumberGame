using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace FourMagicNumberGame.Components
{
    public partial class Game
    {
        [Parameter] public int Min { get; set; }

        [Parameter] public int Max { get; set; }

        private int? numberChosen;

        private readonly List<string> outputLines = new();

        private void DoTheMagic()
        {
            if (numberChosen == null)
            {
                return;
            }
            int currentNumber = numberChosen ?? 0;
            outputLines.Clear();
            int currentLength = NumbersToWords.ConvertToWords(currentNumber, true).Length;
            Console.WriteLine(currentLength);
            if (currentLength == 4)
            {
                outputLines.Add($"{currentNumber} is {currentLength}");
                Console.WriteLine($"{currentNumber} is {currentLength}");
            }
            else
            {
                do
                {
                    outputLines.Add($"{currentNumber} is {currentLength}");
                    Console.WriteLine($"{currentNumber} is {currentLength}");
                    currentNumber = currentLength;
                    currentLength = NumbersToWords.ConvertToWords(currentNumber, true).Length;
                }
                while (currentLength != 4);
                outputLines.Add($"{currentNumber} is {currentLength}");
                Console.WriteLine($"{currentNumber} is {currentLength}");
            }
        }
    }
}
