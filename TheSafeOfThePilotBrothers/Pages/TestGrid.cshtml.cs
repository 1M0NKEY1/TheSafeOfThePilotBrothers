using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSafeOfThePilotBrothers.Models;

namespace TheSafeOfThePilotBrothers.Pages;

public class TestGrid : PageModel
{
    [BindProperty(SupportsGet = true)]
    public LeverModel Lever { get; set; }

    public IActionResult OnGet(int startSize = 4)
    {
        Lever = new LeverModel
        {
            LeverArray = new int[startSize, startSize]
        };

        Random rnd = new Random();
        for (int i = 0; i < startSize; i++)
        {
            for (int j = 0; j < startSize; j++)
            {
                Lever.LeverArray[i, j] = rnd.Next(2);
            }
        }

        return Page();
    }

    public IActionResult OnPost(int size)
    {
        if (size <= 0)
        {
            size = 2;
        }

        if (Lever.LeverArray.GetLength(0) != size || Lever.LeverArray.GetLength(1) != size)
        {
            int[,] tmpLeverArray = new int[size, size];
            int minSize = Math.Min(size, Lever.LeverArray.GetLength(0));
            for (int i = 0; i < minSize; i++)
            {
                for (int j = 0; j < minSize; j++)
                {
                    tmpLeverArray[i, j] = Lever.LeverArray[i, j];
                }
            }
            Lever.LeverArray = tmpLeverArray;
        }

        return RedirectToPage("/TestGrid", new { size });
    }
}