using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheSafeOfThePilotBrothers.Pages;

public class Rules : PageModel
{
    private readonly ILogger<Rules> _logger;

    public Rules(ILogger<Rules> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}