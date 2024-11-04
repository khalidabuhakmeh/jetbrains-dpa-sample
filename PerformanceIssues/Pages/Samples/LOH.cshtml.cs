using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PerformanceIssues.Pages.Samples;

public class LOH : PageModel
{
    public void OnGet()
    {
        // Allocate to the large object heap (LOH) by creating a large array
        for (var reps = 0; reps < 100; reps++)
        {
            var bigBoi = new int[85_000]; // This array will likely be allocated on the LOH due to its size
            for (var index = 0; index < bigBoi.Length; index++)
            {
                bigBoi[index] = 2;
            }

            Sum = bigBoi.Sum();
        }
    }

    public int Sum { get; set; }
}