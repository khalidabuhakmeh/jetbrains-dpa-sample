using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceIssues.Models;

namespace PerformanceIssues.Pages.Samples;

public class DbCommandTime(Database db) : PageModel
{
    // lang=sql
    public const string RecursiveSql = """
                               WITH RECURSIVE r(i) AS (
                                 VALUES(0)
                                 UNION ALL
                                 SELECT i FROM r
                                 LIMIT 10000000
                               )
                               SELECT i FROM r WHERE i = 1;
                               """;
    
    public async Task<ContentResult> OnGetSlow()
    {
        await db.Database.ExecuteSqlRawAsync(RecursiveSql);
        return Content("Done");
    }
}