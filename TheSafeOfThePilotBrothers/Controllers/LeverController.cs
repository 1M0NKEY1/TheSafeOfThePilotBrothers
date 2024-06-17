using Microsoft.AspNetCore.Mvc;

namespace TheSafeOfThePilotBrothers.Controllers;

public class LeverController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}