using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace FourMagicNumberGame.Components
{
    public partial class Game
    {
        [Parameter] public int Min { get; set; }

        [Parameter] public int Max { get; set; }

        private int? numberChosen;

        List<string> outputLines = new();

        private void DoTheMagic()
        {
            if (numberChosen == null)
            {
                return;
            }
            outputLines.Clear();
            int currentLength = NumbersToWords.ConvertToWords(numberChosen ?? 0).Length;
            Console.WriteLine(currentLength);
            if (currentLength == 4)
            {
                outputLines.Add($"{numberChosen} is {currentLength}");
                Console.WriteLine($"{numberChosen} is {currentLength}");
            }
            else
            {
                do
                {
                    outputLines.Add($"{numberChosen} is {currentLength}");
                    Console.WriteLine($"{numberChosen} is {currentLength}");
                    numberChosen = currentLength;
                    currentLength = NumbersToWords.ConvertToWords(numberChosen ?? 0).Length;
                }
                while (currentLength != 4);
                outputLines.Add($"{numberChosen} is {currentLength}");
                Console.WriteLine($"{numberChosen} is {currentLength}");
            }
        }
    }
}
