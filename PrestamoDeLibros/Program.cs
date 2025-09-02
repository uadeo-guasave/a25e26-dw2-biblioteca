/*
Entity Framework Core (EFCore) es un ORM (Object-Relational Mapping) para .NET que permite trabajar con bases de datos de forma orientada a objetos.
Con EFCore, puedes realizar operaciones de consulta e inserción, actualización o eliminación de datos sin escribir SQL manualmente.
Es flexible, soporta múltiples tipos de bases de datos y facilita el desarrollo al manejar el mapeo entre clases y tablas de forma automática.

Code First (cuando la base de datos no existe)
Database First (cuando la base de datos ya existe)

Libros, Autores, Usuarios, Prestamos, Editoriales, Categorias, Ejemplares
*/
using PrestamoDeLibros;

var autor1 = new Autor
{
    Nombres = "Luisa Marcella",
    Apellidos = "Gaxiola"
};

var editorial1 = new Editorial
{
    Nombre = "Del Rancho"
};

var libro1 = new Libro
{
    Título = "Base de datos avanzadas",
    Editorial = editorial1
};

libro1.Autores.Add(autor1);

// agregar otro autor
var autor2 = new Autor();
autor2.Nombres = "Honorio";
autor2.Apellidos = "Haro";
libro1.Autores.Add(autor2);

Console.WriteLine($"Libro: {libro1.Título}");
foreach (var autor in libro1.Autores)
{
    Console.WriteLine($"Autor: {autor.Nombres} {autor.Apellidos}");
}
Console.WriteLine($"Editorial: {libro1.Editorial.Nombre}");
