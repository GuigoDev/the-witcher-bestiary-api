using Microsoft.EntityFrameworkCore;
using BestiaryApi.Models;

namespace BestiaryApi.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext (DbContextOptions<DatabaseContext> options) : base(options) {}

    public DbSet<Beast> Beasts => Set<Beast>();
}