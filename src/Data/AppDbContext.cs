using Microsoft.EntityFrameworkCore;
using PocEf.Models;

namespace PocEf.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
}