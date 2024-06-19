using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSafeOfThePilotBrothers.Controllers;

namespace TheSafeOfThePilotBrothers.Pages;

public class TestGrid : PageModel
{
    private readonly LeverController _leverController;

    public TestGrid(int startSize)
    {
        _leverController = new LeverController(startSize, startSize);
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPostToggleCellColor(int row, int col)
    {
        _leverController.ToggleCellColor(row, col);

        return new OkResult();
    }

    public IActionResult OnPostResizeGrid(int size)
    {
        if (size <= 0)
        {
            size = 2;
        }

        _leverController.Resize(size, size);

        return RedirectToPage("/TestGrid", new { size });
    }
}