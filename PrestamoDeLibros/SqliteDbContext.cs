using Microsoft.EntityFrameworkCore;

namespace PrestamoDeLibros;

public class SqliteDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Db/biblioteca.db");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: describir indices, relaciones, etc.
        base.OnModelCreating(modelBuilder);
    }
}
