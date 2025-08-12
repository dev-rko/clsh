using Microsoft.AspNetCore.Mvc;

namespace Calc.Rest.Controllers;

public class AppController : Controller
{
    public IActionResult Index()
    {
        return View("~/Views/ang-index.cshtml");
    }
}
