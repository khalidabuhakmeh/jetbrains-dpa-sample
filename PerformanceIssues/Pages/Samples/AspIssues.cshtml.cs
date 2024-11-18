using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PerformanceIssues.Pages.Samples;

public class AspIssues : PageModel
{
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnGetSlow()
    {
        await Task.Delay(5_000);

        // lang=html
        return Content("""
                       <div class="fs-1">
                        And We're Back From The Razor Page Handler!
                       </div>
                       """);
    }
}

public class SlowViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        Thread.Sleep(3_000);
        return View();
    }
}