using Microsoft.EntityFrameworkCore;

namespace PerformanceIssues.Models;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<Person> People => Set<Person>();
}

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
        = DateTimeOffset.Now;
}