using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrestamoDeLibros;

public class Libro
{
    public int Id { get; set; }
    // si EF detecta una propiedad llamada Id de tipo int
    // la utilizará como PK y autonumérica al convertirla

    [Required, MaxLength(100)]
    public string? Título { get; set; }

    [MaxLength(20)]
    public string? ISBN { get; set; }

    [Required]
    public int Edición { get; set; }

    [Required, MaxLength(400)]
    public string? Sinópsis { get; set; }

    // FK_ClaseActual_PropiedadActual_ClaseExterna_PKExterna
    [Required, ForeignKey("FK_Libro_EditorialId_Editorial_Id")]
    public int EditorialId { get; set; }

    // Propiedades utilizadas por EFCore
    // N:1 Libros:Editoriales
    [NotMapped]
    public Editorial? Editorial { get; set; }

    // 1:N Libros:LibroAutor
    [NotMapped]
    public List<LibroAutor>? LibrosAutores { get; set; }
}
