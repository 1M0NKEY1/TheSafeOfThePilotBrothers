using Microsoft.AspNetCore.Mvc;
using TheSafeOfThePilotBrothers.Models;

namespace TheSafeOfThePilotBrothers.Controllers;

public class LeverController : Controller
{
    private readonly LeverModel _leverModel;

    public LeverController(int rows, int cols)
    {
        _leverModel = new LeverModel(rows, cols);
    }

    public IActionResult Index()
    {
        return View(_leverModel.GetArray());
    }

    [HttpPost]
    public IActionResult ToggleCellColor(int row, int col)
    {
        _leverModel.ToggleCell(row, col);
        
        _leverModel.ToggleFullRow(row);
        
        _leverModel.ToggleFullCol(col);

        return Ok();
    }

    [HttpPost]
    public IActionResult Resize(int rows, int cols)
    {
        _leverModel.Resize(rows, cols);
        return RedirectToAction("Index");
    }
}