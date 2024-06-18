using Microsoft.AspNetCore.Mvc;

namespace TheSafeOfThePilotBrothers.Controllers;

public class LeverController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}