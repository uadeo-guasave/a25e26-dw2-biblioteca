using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoDeLibros;

[Table("LibrosAutores")]
public class LibroAutor
{
    // debes formar una nueva llave PK
    // con las PK's de ambas tablas
    // cada una a su vez será FK
    [ForeignKey("FK_LibroAutor_LibroId_Libro_Id")]
    public int LibroId { get; set; }

    [ForeignKey("FK_LibroAutor_AutorId_Autor_Id")]
    public int AutorId { get; set; }

    // propiedades para EFCore
    [NotMapped]
    public Libro? Libro { get; set; }

    [NotMapped]
    public Autor? Autor { get; set; }
}
