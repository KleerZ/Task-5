using Bogus;
using MediatR;
using Task.Application.Common.Generators;
using Task.Application.Common.Interfaces;

namespace Task.Application.CommandQueries.People.Queries.GetPeopleList;

public class GetPeopleListQueryHandler : IRequestHandler<GetPeopleListQuery, List<PersonDto>>
{
    private readonly IApplicationContext _context;

    public GetPeopleListQueryHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task<List<PersonDto>> Handle(GetPeopleListQuery request,
        CancellationToken cancellationToken)
    {
        var elementsOnPage = request.ElementsCountOnLoad ?? 10;
        var faker = new Faker(request.Country);
        var people = new List<PersonDto>();

        for (var seed = request.Seed; seed < request.Seed + elementsOnPage; seed++)
        {
            faker.Random = new Randomizer(seed);

            var firstName = faker.Name.FirstName();
            var lastName = faker.Name.LastName();
            var phone = new PhoneGenerator(faker).Generate(request.Country, seed);
            var address = new AddressGenerator(_context, faker, seed).Generate(request.Country);

            var person = new PersonDto
            {
                Address = await address,
                Phone = phone,
                FullName = $"{firstName} {lastName}"
            };
            
            people.Add(person);
        }
        
        return people;
    }
}