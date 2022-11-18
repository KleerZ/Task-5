using Microsoft.AspNetCore.Mvc;

namespace Task.Mvc.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}