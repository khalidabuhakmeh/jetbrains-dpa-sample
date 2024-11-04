using Microsoft.AspNetCore.Mvc.RazorPages;
using PerformanceIssues.Models;

namespace PerformanceIssues.Pages.Samples;

public class Closures : PageModel
{
    public List<string> Fruits { get; set; }
        = new();

    public void OnGet()
    {
        var list = Fruit.All.Select(x => x.Name).ToList();
        for (var i = 0; i < 100_000; i++)
        {
            // about 3.0 MB of allocations
            Fruits = GetFruit(list, 100);
        }
    }

    public List<string> GetFruit(List<string> list, int length)
    {
        return StringUtils.Filter(list, s => s.Length < length);
    }
}

public static class StringUtils
{
    public static List<string> Filter(List<string> source, Func<string, bool> condition)
    {
        var result = new List<string>();

        foreach (var item in source)
        {
            if (condition(item))
                result.Add(item);
        }

        return result;
    }
}