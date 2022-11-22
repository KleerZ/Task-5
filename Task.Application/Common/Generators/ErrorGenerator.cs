using System.Text;
using Task.Application.Common.Data;

namespace Task.Application.Common.Generators;

public class ErrorGenerator
{
    private readonly Random _random;
    private readonly string _country;
    private readonly double _errorCount;

    public ErrorGenerator(string country, int seed, double errorCount)
    {
        _random = new Random(seed);
        _country = country;
        _errorCount = errorCount;
    }

    public string[] Generate(params string[] lines)
    {
        var errorsCount = GetErrorsCount(_errorCount);
        var probability = GetProbability(_errorCount);
        int changeLineIndex;

        if (errorsCount == 0)
            return lines;

        for (var i = 0; i < errorsCount; i++)
        {
            changeLineIndex = _random.Next(0, lines.Length);

            var operation = GetRandomOperation();
            lines[changeLineIndex] = operation(lines[changeLineIndex]);
        }

        if (_random.Next(1, 101) <= probability * 100) 
        {
            changeLineIndex = _random.Next(0, lines.Length);

            var operation = GetRandomOperation();
            lines[changeLineIndex] = operation(lines[changeLineIndex]);
        }

        return lines;
    }

    private string RemoveSymbolOnRandomPosition(string line)
    {
        if (line.Length <= 10) return line;

        var symbolIndex = _random.Next(line.Length);
        return line.Remove(symbolIndex, 1);
    }

    private string InsertSymbolOnRandomPosition(string line)
    {
        if (line.Length <= 10) return line;

        var data = _random.Next(1, 3) == 1
            ? RegionAlphabets.GetAlphabet(_country)
            : _random.Next(1, 11).ToString();

        var alphabetSymbolPosition = _random.Next(data!.Length);
        var symbol = data[alphabetSymbolPosition].ToString();

        return line.Insert(_random.Next(line.Length), symbol);
    }

    private string ReplaceSymbols(string line)
    {
        if (line.Length <= 10) return line;

        var stringBuilder = new StringBuilder(line);
        var symbolPosition = _random.Next(line.Length - 2);

        var firstSymbol = stringBuilder[symbolPosition];
        var secondSymbol = stringBuilder[symbolPosition + 1];

        stringBuilder[symbolPosition] = secondSymbol;
        stringBuilder[symbolPosition + 1] = firstSymbol;

        return stringBuilder.ToString();
    }

    private int GetErrorsCount(double errors)
    {
        var errorsString = errors.ToString();
        var errorsCount = errorsString.Split('.',',')[0];
        return Convert.ToInt32(errorsCount);
    }

    private int GetProbability(double errors)
    {
        int probability = 0;
        var error = errors.ToString();

        if (error.Split('.', ',').Length == 1)
            probability = Convert.ToInt32(error) * 10;
        else if (error.Split('.', ',')[1].Length == 1)
            probability = Convert.ToInt32(error.Split('.', ',')[1]) * 10;
        else if (error.Split('.', ',')[1].Length >= 2)
            probability = Convert.ToInt32(error.Split('.', ',')[1]);
        else if(error.Split('.', ',').Length > 99)
            probability = Convert.ToInt32(error);

        return probability;
    }

    private Func<string, string> GetRandomOperation()
    {
        var randomValue = _random.NextDouble() * 100;

        return randomValue switch
        {
            > 0 and <= 33.333 => RemoveSymbolOnRandomPosition,
            > 33.333 and <= 66.666 => ReplaceSymbols,
            > 66.666 and <= 100 => InsertSymbolOnRandomPosition,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}