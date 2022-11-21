using MediatR;
using Microsoft.AspNetCore.Mvc;
using Task.Application.CommandQueries.People.Queries.GetPeopleList;

namespace Task.Mvc.Controllers;

public class PeopleController : Controller
{
    private readonly IMediator _mediator;

    public PeopleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(string country, int elementsOnPage, [FromBody] int seed)
    {
        var query = new GetPeopleListQuery
        {
            Country = country, Seed = seed,
            ElementsCountOnLoad = elementsOnPage
        };
        var peoples =  await _mediator.Send(query);

        return Ok(peoples);
    }
}