using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSafeOfThePilotBrothers.Models;

namespace TheSafeOfThePilotBrothers.Pages;

public class Grid : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int? GridSize { get; set; }
    public string ErrorMessage { get; private set; }
    public List<Lever> Lever { get; set; }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (GridSize is >= 2)
        {
            return Page();
        }

        ErrorMessage = "Wrong size of the field. Size should be from 2 to 10.";
        return Page();
    }
}