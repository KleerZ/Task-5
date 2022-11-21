using Bogus;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;

namespace Task.Application.Common.Generators;

public class AddressGenerator
{
    private readonly Faker _faker;
    private readonly IApplicationContext _context;
    private readonly Random? _random;
    private readonly int _seed;

    public AddressGenerator(IApplicationContext context, Faker faker, int seed)
    {
        _context = context;
        _faker = faker;
        _seed = seed;
        _random = new Random(_seed);
    }

    public async Task<string> Generate(string country)
    {
        var countryId = (await _context.Countries
            .FirstOrDefaultAsync(c => c.Name == country))!.Id;

        _faker.Random = new Randomizer(_seed);

        var randomValue = _random!.Next(1, 3);

        switch (randomValue)
        {
            case 1:
            {
                var apartment = _faker.Address.SecondaryAddress();
                var building = _faker.Address.BuildingNumber();
                var city = _faker.Address.City();
                var state = _faker.Address.State();
                var street = _faker.Address.StreetName();

                return $"{city}, {state}, {street}, {building}, {apartment}";
            }
            case 2:
            {
                var villagesCount = _context.Villages.Count(c => c.Country.Id == countryId);
            
                var street = _faker.Address.StreetName();
                var building = _faker.Address.BuildingNumber();

                var index = _random.Next(villagesCount);
            
                var village = _context.Villages
                    .Where(c => c.Country.Id == countryId)
                    .ToArray()
                    .Where((_, i) => i == index)
                    .First().Name;
            
                return $"{village}, {street} {building}";
            }
            default: return string.Empty;
        }
    }
}