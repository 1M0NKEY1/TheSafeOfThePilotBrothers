using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheSafeOfThePilotBrothers.Models;

namespace TheSafeOfThePilotBrothers.Pages;

public class Grid : PageModel
{
    private readonly LeverModel _leverModel;

    [BindProperty]
    public int GridSize { get; set; }
    
    public Grid()
    {
        _leverModel = new LeverModel();
    }

    public IActionResult OnGet()
    {
        return Page();
    }
    
    
    public IActionResult OnPostResizeGrid(int gridSize)
    {
        _leverModel.Resize(gridSize, gridSize);

        return new JsonResult(new { status = "success", message = "Data received successfully" });
    }
    
    public IActionResult OnPostToggleChangeColor(int row, int col)
    {
        _leverModel.ToggleCell(row, col);
        _leverModel.ToggleFullCol(col);
        _leverModel.ToggleFullRow(row);
        
        return new JsonResult(_leverModel.GetArray());
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