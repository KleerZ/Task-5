namespace Task.Application.Common.Data;

public class PhoneCodes
{
    private readonly Dictionary<string, int?> _phoneCodes = new()
    {
        ["en"] = 44,
        ["it"] = 39,
        ["es"] = 34
    };
    
    public int? GetPhoneCode(string country) => _phoneCodes[country];
}