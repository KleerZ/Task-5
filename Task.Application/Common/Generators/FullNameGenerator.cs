using Bogus;

namespace Task.Application.Common.Generators;

public class FullNameGenerator
{
    private readonly Faker _faker;

    public FullNameGenerator(Faker faker)
    {
        _faker = faker;
    }

    public string Generate(int seed)
    {
        _faker.Random = new Randomizer(seed);
        
        var firstName = _faker.Name.FirstName();
        var lastName = _faker.Name.LastName();

        return $"{firstName} {lastName}";
    }
}