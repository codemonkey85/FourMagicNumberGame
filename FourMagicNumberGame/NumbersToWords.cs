namespace FourMagicNumberGame;

public static class NumbersToWords
{
    private static string Ones(string numberString) => int.TryParse(numberString, out var number) ? Ones(number) : string.Empty;

    private static string Ones(int number) => number switch
    {
        1 => "One",
        2 => "Two",
        3 => "Three",
        4 => "Four",
        5 => "Five",
        6 => "Six",
        7 => "Seven",
        8 => "Eight",
        9 => "Nine",
        _ => string.Empty,
    };

    private static string Tens(string numberString) => int.TryParse(numberString, out var number) ? Tens(number) : string.Empty;

    private static string Tens(int number) => number switch
    {
        10 => "Ten",
        11 => "Eleven",
        12 => "Twelve",
        13 => "Thirteen",
        14 => "Fourteen",
        15 => "Fifteen",
        16 => "Sixteen",
        17 => "Seventeen",
        18 => "Eighteen",
        19 => "Nineteen",
        20 => "Twenty",
        30 => "Thirty",
        40 => "Forty",
        50 => "Fifty",
        60 => "Sixty",
        70 => "Seventy",
        80 => "Eighty",
        90 => "Ninety",
        > 0 => $"{Tens($"{number.ToString()[..1]}0")} {Ones(number.ToString()[1..])}",
        _ => string.Empty
    };

    private static string ConvertWholeNumber(string Number)
    {
        var word = string.Empty;
        try
        {
            var beginsZero = false; //tests for 0XX
            var isDone = false; //test if already translated
            var dblAmt = Convert.ToDouble(Number);
            //if ((dblAmt > 0) && number.StartsWith("0"))
            if (dblAmt > 0)
            {
                //test for zero or digit zero in a nuemric
                beginsZero = Number.StartsWith("0");

                var numDigits = Number.Length;
                var pos = 0; //store digit grouping
                var place = string.Empty; //digit grouping name:hundres,thousand,etc...
                switch (numDigits)
                {
                    case 1: //ones' range
                        word = Ones(Number);
                        isDone = true;
                        break;
                    case 2: //tens' range
                        word = Tens(Number);
                        isDone = true;
                        break;
                    case 3: //hundreds' range
                        pos = (numDigits % 3) + 1;
                        place = " Hundred ";
                        break;
                    case 4: //thousands' range
                    case 5:
                    case 6:
                        pos = (numDigits % 4) + 1;
                        place = " Thousand ";
                        break;
                    case 7: //millions' range
                    case 8:
                    case 9:
                        pos = (numDigits % 7) + 1;
                        place = " Million ";
                        break;
                    case 10: //Billions's range
                    case 11:
                    case 12:
                        pos = (numDigits % 10) + 1;
                        place = " Billion ";
                        break;
                    //add extra case options for anything above Billion...
                    default:
                        isDone = true;
                        break;
                }
                if (!isDone)
                {
                    //if transalation is not done, continue...(Recursion comes in now!!)
                    if (Number[..pos] != "0" && Number[pos..] != "0")
                    {
                        try
                        {
                            word = $"{ConvertWholeNumber(Number[..pos])}{place}{ConvertWholeNumber(Number[pos..])}";
                        }
                        catch { }
                    }
                    else
                    {
                        word = $"{ConvertWholeNumber(Number[..pos])}{ConvertWholeNumber(Number[pos..])}";
                    }

                    //check for trailing zeros
                }
                //ignore digit grouping names
                if (word.Trim().Equals(place.Trim()))
                {
                    word = string.Empty;
                }
            }
        }
        catch { }
        return word.Trim();
    }

    public static string ConvertToWords(int number, bool removeSpaces = false) =>
        number == 0 ? "Zero" : ConvertToWords(number.ToString(), removeSpaces).Trim();

    public static string ConvertToWords(string numberString, bool removeSpaces = false)
    {
        var val = string.Empty;
        try
        {
            val = $"{ConvertWholeNumber(numberString).Trim()}";
        }
        catch { }
        return removeSpaces ? val.Replace(" ", string.Empty) : val;
    }
}
