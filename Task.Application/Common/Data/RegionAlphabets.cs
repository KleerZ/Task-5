namespace Task.Application.Common.Data;

public static class RegionAlphabets
{
    private static readonly Dictionary<string, string?> Alphabet = new()
    {
        ["en"] = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz",
        ["it"] = "AaBbCcDdEeFfGgHhIiLlMmNnOoPpQqRrSsTtUuVvZz",
        ["es"] = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnÑñOoPpQqRrSsTtUuVvWwXxYyZz"
    };

    public static string? GetAlphabet(string country) => Alphabet[country];
}