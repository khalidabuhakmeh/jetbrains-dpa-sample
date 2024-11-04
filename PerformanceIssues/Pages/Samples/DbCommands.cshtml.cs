using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceIssues.Models;

namespace PerformanceIssues.Pages.Samples;

public class DbCommands(Database db) : PageModel
{
    public async Task OnGet()
    {
        for (var i = 0; i < 100; i++)
        {
            _ = await db.Database.ExecuteSqlAsync($"SELECT 1");
        }
    }
}