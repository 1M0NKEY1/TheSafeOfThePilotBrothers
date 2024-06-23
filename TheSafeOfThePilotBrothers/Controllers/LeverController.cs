using Microsoft.AspNetCore.Mvc;
using TheSafeOfThePilotBrothers.Models;

namespace TheSafeOfThePilotBrothers.Controllers;

public class LeverController : Controller
{
    private readonly LeverModel _leverModel;
    [BindProperty]
    public int GridSize { get; set; }

    public LeverController()
    {
        _leverModel = new LeverModel();
    }
    
    [HttpPost]
    public IActionResult OnPostResizeGrid()
    {
        _leverModel.Resize(GridSize, GridSize);

        return Json(new { status = "success", message = "Data received successfully" });
    }
}