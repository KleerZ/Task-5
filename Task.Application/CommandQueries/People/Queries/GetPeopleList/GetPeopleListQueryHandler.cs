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
        var errorGenerator = new ErrorGenerator(request.Country, request.Seed, request.ErrorsCount);
        
        var elementsOnPage = request.ElementsCountOnLoad ?? 10;
        var faker = new Faker(request.Country);
        var people = new List<PersonDto>();

        for (var seed = request.Seed; seed < request.Seed + elementsOnPage; seed++)
        {
            faker.Random = new Randomizer(seed);

            var fullName = new FullNameGenerator(faker).Generate(seed);
            var phone = new PhoneGenerator(faker).Generate(request.Country);
            var address = await new AddressGenerator(_context, faker, seed).Generate(request.Country);
            
            var lines = errorGenerator
                .Generate(address, phone, fullName);

            var person = new PersonDto
            {
                Address = lines[0],
                Phone = lines[1],
                FullName = lines[2]
            };
            
            people.Add(person);
        }
        
        return people;
    }
}