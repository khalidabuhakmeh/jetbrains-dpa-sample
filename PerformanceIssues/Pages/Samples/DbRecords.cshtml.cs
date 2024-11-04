using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceIssues.Models;

namespace PerformanceIssues.Pages.Samples;

public class DbRecords(Database db) : PageModel
{
    public async Task OnGet()
    {
        Results =
            // lang=sql
            await db.Database.SqlQuery<Row>(
                    $"""
                     WITH RECURSIVE
                         numbers(x) AS (
                             SELECT 1
                             UNION ALL
                             SELECT x+1 FROM numbers
                             WHERE x < 1000
                         )
                     SELECT x as Number
                     FROM numbers;
                     """)
                .ToListAsync();
    }

    public List<Row> Results { get; set; }
        = new();

    [UsedImplicitly]
    public record Row(int Number);
}