using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoDeLibros;

[Table("Editoriales")]
public class Editorial
{
    public int Id { get; set; } // EditorialId

    [Required, MaxLength(30)]
    public string? Nombre { get; set; } // unique

    [Url]
    public string? SitioWeb { get; set; }

    // propiedades controladas por EFCore
    [NotMapped]
    public List<Libro>? Libros { get; set; }
}
