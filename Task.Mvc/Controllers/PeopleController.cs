using Microsoft.AspNetCore.Mvc;

namespace Task.Mvc.Controllers;

public class PeopleController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}