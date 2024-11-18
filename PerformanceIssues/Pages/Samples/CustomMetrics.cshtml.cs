using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PerformanceIssues.Pages.Samples;

public class CustomMetrics : PageModel
{
    public const string MeterName = "Dice";
    private static readonly Meter Meter = new(MeterName);
    private static readonly Gauge<int> RollResultGauge =
        Meter.CreateGauge<int>(
            "Result",
            null, 
            "the result of the roll");

    public int Result { get; set; }
    
    public void OnGet()
    {
        Result = Random.Shared.Next(1, 7);
        RollResultGauge.Record(Result);
    }
}