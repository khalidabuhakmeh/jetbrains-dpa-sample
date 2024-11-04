using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerformanceIssues.Models;

namespace PerformanceIssues.Pages.Samples;

public class DbConnections(IServiceProvider services) : PageModel
{
    public async Task OnGet()
    {
        List<Database> databases = new(100);
        
        for (var i = 0; i < 25; i++) {
            databases.Add(services.GetRequiredService<Database>());
        }

        await Parallel.ForEachAsync(databases, async (Database db, CancellationToken token) =>
        {
            _ = await db
                .Database
                .SqlQuery<Row>($"SELECT 1 as Number")
                .FirstAsync(cancellationToken: token);
            
            await db.DisposeAsync();
        });
        
        Result = 42;
    }

    public int Result { get; set; }
    
    [UsedImplicitly]
    public record Row(int Number);
}

