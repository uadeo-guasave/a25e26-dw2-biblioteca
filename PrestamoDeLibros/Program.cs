/*
Entity Framework Core (EFCore) es un ORM (Object-Relational Mapping) para .NET que permite trabajar con bases de datos de forma orientada a objetos.
Con EFCore, puedes realizar operaciones de consulta e inserción, actualización o eliminación de datos sin escribir SQL manualmente.
Es flexible, soporta múltiples tipos de bases de datos y facilita el desarrollo al manejar el mapeo entre clases y tablas de forma automática.

Code First (cuando la base de datos no existe)
Database First (cuando la base de datos ya existe)

Libros, Autores, Usuarios, Prestamos, Editoriales, Categorias, Ejemplares
*/
using System.Collections.Generic;
using PrestamoDeLibros;

var db = new SqliteDbContext();
// db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// CrearEditoriales(db);
// CrearAutores(db);

static void CrearEditoriales(SqliteDbContext db)
{
    // Editoriales
    var editorial1 = new Editorial();
    editorial1.Nombre = "Trillas";
    var editorial2 = new Editorial { Nombre = "Planeta" };

    // operaciones con la base de datos
    // guardar las editoriales INSERT INTO ... values (val1, val2...);
    db.Editoriales.Add(editorial1);
    db.Editoriales.Add(editorial2);
    db.SaveChanges();
}

static void CrearAutores(SqliteDbContext db)
{
    // Autores
    var autor1 = new Autor { Nombres = "Marcella", Apellidos = "Jones" };
    var autor2 = new Autor { Nombres = "José Luis", Apellidos = "Kingpin" };
    var autor3 = new Autor { Nombres = "Alfred", Apellidos = "Wayne" };

    // guardar los autores INSERT INTO ... values (val1,val2...),(val3,val4...)...
    db.Autores.AddRange(new List<Autor> { autor1, autor2, autor3 });
    db.SaveChanges();
}