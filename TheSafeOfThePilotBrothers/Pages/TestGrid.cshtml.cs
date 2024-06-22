using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSafeOfThePilotBrothers.Models;

namespace TheSafeOfThePilotBrothers.Pages;

public class TestGrid : PageModel
{
    private readonly LeverModel _leverModel;

    public TestGrid(int startSize = 4)
    {
        _leverModel = new LeverModel(startSize, startSize);
    }

    public IActionResult OnGet()
    {
        return Page();
    }
    
    public IActionResult OnPostResizeGrid(int newSize)
    {
        if (newSize <= 0)
        {
            newSize = 2;
        }

        _leverModel.Resize(newSize, newSize);

        return RedirectToPage("/TestGrid", new { size = newSize });
    }
    
    public IActionResult OnPostToggleChangeColor(int row, int col)
    {
        _leverModel.ToggleCell(row, col);
        _leverModel.ToggleFullCol(col);
        _leverModel.ToggleFullRow(row);

        var cellValue = _leverModel.GetArray()[row, col];
        return new JsonResult(cellValue.ToString());
    }

    private IActionResult OnPostWinResult()
    {
        var counterForAllGreen = 0;
        var counterForAllRed = 0;
        var size = _leverModel.GetArray().GetLength(0);
        for (var i = 0; i < size; i++)
        {
            for (var j = 0; j < size; j++)
            {
                if (_leverModel.GetArray()[i, j] == 1)
                {
                    counterForAllGreen++;
                }

                if (_leverModel.GetArray()[i, j] == 0)
                {
                    counterForAllRed++;
                }
            }
        }

        if (counterForAllGreen == size * size || counterForAllRed == size * size)
        {
            return RedirectToPage("/WinPage");
        }

        return new OkResult();
    }

    public int[,] GetLeverArray()
    {
        return _leverModel.GetArray();
    }
}