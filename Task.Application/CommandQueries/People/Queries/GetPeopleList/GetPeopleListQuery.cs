using MediatR;

namespace Task.Application.CommandQueries.People.Queries.GetPeopleList;

public class GetPeopleListQuery : IRequest<List<PersonDto>>
{
    public int Seed { get; set; }
    public string Country { get; set; }
    public int? ElementsCountOnLoad { get; set; }
    public double ErrorsCount { get; set; }
}