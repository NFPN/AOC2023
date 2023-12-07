// See https://aka.ms/new-console-template for more information

using System.Text;

public class Day1Puzzle
{
    private string[]? inputFile;

    public string Solve()
    {
        var builder = new StringBuilder();
        builder.AppendLine(TextFormat(SolvePart1(), 1));
        builder.AppendLine(TextFormat(SolvePart2(), 2));

        return builder.ToString();

        static string TextFormat(string result, int day)
        {
            return $"part {day} result: {result}";
        }
    }

    // Read File and get first and last numbers
    private string SolvePart1()
    {
        inputFile = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "Data", "day-1-input.txt"));

        var combination = 0;

        for (int line = 0; line < inputFile.Length; line++)
        {
            GetDigits(line, out var firstDigit, out var lastDigit);
            combination += int.Parse($"{firstDigit}{lastDigit}");
        }

        return combination.ToString();
    }

    // Read File and get first and last numbers, but checking words too
    private string SolvePart2()
    {
        var combination = 0;
        var strNumArray = "one;two;three;four;five;six;seven;eight;nine".Split(";", StringSplitOptions.RemoveEmptyEntries);

        for (int line = 0; line < inputFile.Length; line++)
        {
            var currentLine = inputFile[line];

            GetDigits(line, out var firstDigit, out var lastDigit);
            GetIndexedWords(currentLine, strNumArray, out var firstWordIndexed, out var lastWordIndexed);

            var firstWord = firstWordIndexed[0];
            var lastWord = lastWordIndexed[0];
            var firstWordIndex = int.Parse(firstWordIndexed[1]);
            var lastWordIndex = int.Parse(lastWordIndexed[1]);

            var firstDigitIndex = currentLine.IndexOf(firstDigit);
            var lastDigitIndex = currentLine.LastIndexOf(lastDigit);

            var firstNumber = firstWordIndex > firstDigitIndex ? int.Parse(firstDigit.ToString()) : ParseWordToInt(firstWord);
            var lastNumber = lastWordIndex < lastDigitIndex ? int.Parse(lastDigit.ToString()) : ParseWordToInt(lastWord);

            combination += int.Parse($"{firstNumber}{lastNumber}");
        }

        return combination.ToString();
    }

    private void GetIndexedWords(string line, string[] strNumArray, out string[] firstWordIndexed, out string[] lastWordIndexed)
    {
        firstWordIndexed = ["-", line.Length.ToString()];
        lastWordIndexed = ["-", "-1"];

        foreach (var word in strNumArray)
        {
            int firstWordIndex = line.IndexOf(word);
            int lastwordIndex = line.LastIndexOf(word);

            if (firstWordIndex != -1 && int.Parse(firstWordIndexed[1]) > firstWordIndex)
            {
                firstWordIndexed[0] = word;
                firstWordIndexed[1] = firstWordIndex.ToString();
            }

            if (lastwordIndex != -1 && int.Parse(lastWordIndexed[1]) < lastwordIndex)
            {
                lastWordIndexed[0] = word;
                lastWordIndexed[1] = lastwordIndex.ToString();
            }
        }
    }

    private static int ParseWordToInt(string numericWord)
    {
        return numericWord switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => 0,
        };
    }

    private void GetDigits(int line, out char firstDigit, out char lastDigit)
    {
        firstDigit = lastDigit = '0';

        if (inputFile == null) { return; }

        firstDigit = inputFile[line].First(c => char.IsDigit(c));
        lastDigit = inputFile[line].Last(c => char.IsDigit(c));
    }
}