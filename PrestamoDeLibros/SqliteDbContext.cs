using Microsoft.EntityFrameworkCore;
using System.IO;

namespace PrestamoDeLibros;

public class SqliteDbContext : DbContext
{
    // definición de los DbSet
    public DbSet<Editorial> Editoriales { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<LibroAutor> LibrosAutores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Obtener el directorio base donde está el ejecutable
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var dbDirectory = Path.Combine(baseDirectory, "Db");
        
        // Crear el directorio si no existe
        if (!Directory.Exists(dbDirectory))
        {
            Directory.CreateDirectory(dbDirectory);
        }
        
        var dbPath = Path.Combine(dbDirectory, "biblioteca.db");
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TODO: describir indices, relaciones, etc.
        // FLUENT API
        modelBuilder.Entity<Editorial>().HasIndex(e => e.Nombre).IsUnique();

        modelBuilder.Entity<LibroAutor>().HasKey(la => new { la.LibroId, la.AutorId });

        base.OnModelCreating(modelBuilder);
    }
}
