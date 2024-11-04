using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PerformanceIssues.Pages.Samples;

public class SOH : PageModel
{
    public List<int> Numbers { get; set; }
        = new();

    public string Number { get; set; } = "0";
    
    public void OnGet()
    {
        for (var i = 0; i < 10_000; i++)
        {
            // Small Object Heap
            Numbers = [..Numbers, Random.Shared.Next(1, 100)];
            // boxing
            Number = $"{(object)i}";
        }
    }
}