using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerformanceIssues.Models;
using PerformanceIssues.Pages.Samples;

namespace PerformanceIssues.Controllers;

[Route("[controller]")]
public class SlowController(Database database) : Controller
{
    [HttpGet, Route("")]
    public async Task<IActionResult> Index()
    {
        await Task.Delay(5_000);
        // lang=html
        return Content("""
                       <div class="fs-1">
                        And We're Back From The Controller!
                       </div>
                       """);
    }

    [HttpGet, Route("with-vc")]
    public IActionResult WithViewComponent()
    {
        return View("WithViewComponent");
    }
}