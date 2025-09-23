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
        // FLUENT API
        modelBuilder.Entity<Editorial>().HasIndex(e => e.Nombre).IsUnique();
        modelBuilder.Entity<LibroAutor>().HasKey(la => new { la.LibroId, la.AutorId });

        // Libros -> Editoriales N:1
        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Editorial)
            .WithMany(e => e.Libros)
            .HasForeignKey(l => l.EditorialId);

        // LibrosAutores -> Libros N:1
        modelBuilder.Entity<LibroAutor>()
            .HasOne(la => la.Libro)
            .WithMany(l => l.LibrosAutores)
            .HasForeignKey(la => la.LibroId);

        // LibrosAutores -> Autores N:1
        modelBuilder.Entity<LibroAutor>()
            .HasOne(la => la.Autor)
            .WithMany(a => a.LibrosAutores)
            .HasForeignKey(la => la.AutorId);

        base.OnModelCreating(modelBuilder);
    }
}
