/*
Entity Framework Core (EFCore) es un ORM (Object-Relational Mapping) para .NET que permite trabajar con bases de datos de forma orientada a objetos.
Con EFCore, puedes realizar operaciones de consulta e inserción, actualización o eliminación de datos sin escribir SQL manualmente.
Es flexible, soporta múltiples tipos de bases de datos y facilita el desarrollo al manejar el mapeo entre clases y tablas de forma automática.

Code First (cuando la base de datos no existe)
Database First (cuando la base de datos ya existe)

Libros, Autores, Usuarios, Prestamos, Editoriales, Categorias, Ejemplares
*/
using PrestamoDeLibros;

var db = new SqliteDbContext();
db.Database.EnsureCreated();
