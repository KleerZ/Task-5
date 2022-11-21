using Bogus;
using Task.Application.Common.Data;

namespace Task.Application.Common.Generators;

public class PhoneGenerator
{
    private readonly Faker _faker;

    public PhoneGenerator(Faker faker)
    {
        _faker = faker;
    }

    public string Generate(string country, int seed)
    {
        var phoneCode = new PhoneCodes().GetPhoneCode(country);
        var phone = _faker.Phone.PhoneNumber();

        return $"+{phoneCode} {phone}";
    }
}