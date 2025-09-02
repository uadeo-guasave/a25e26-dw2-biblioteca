using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoDeLibros;

// metaprogramación
// [Atributos]
[Table("Autores")]
public class Autor
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string? Nombres { get; set; }

    [Required, MaxLength(50)]
    public string? Apellidos { get; set; }

    // propiedades para EFCore
    [NotMapped]
    public List<LibroAutor>? LibrosAutores { get; set; }
}
