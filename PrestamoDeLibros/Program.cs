/*
Entity Framework Core (EFCore) es un ORM (Object-Relational Mapping) para .NET que permite trabajar con bases de datos de forma orientada a objetos.
Con EFCore, puedes realizar operaciones de consulta e inserción, actualización o eliminación de datos sin escribir SQL manualmente.
Es flexible, soporta múltiples tipos de bases de datos y facilita el desarrollo al manejar el mapeo entre clases y tablas de forma automática.

Code First (cuando la base de datos no existe)
Database First (cuando la base de datos ya existe)

Libros, Autores, Usuarios, Prestamos, Editoriales, Categorias, Ejemplares
*/
using System.Collections.Generic;
using Microsoft.VisualBasic;
using PrestamoDeLibros;

var db = new SqliteDbContext();
// db.Database.EnsureDeleted();
db.Database.EnsureCreated();

// CrearEditoriales(db);
// CrearAutores(db);
// DDL: Data Definition Language (CREATE, ALTER, DROP)
// DML: Data Manipulation Language (SELECT, INSERT, DELETE, UPDATE)

// var editorial = BuscarEditorialPorNombre("Planeta", db);
// if (editorial is not null)
//     System.Console.WriteLine(editorial.Nombre);

// GuardarLibroDeAlfredoWayne(db);
// ActualizarLaSinópsisDeUnLibro(db, titulo: "kjhdfkjahfdkjass", sinopsis: "Preguntale a Batman");
// CrearTresLibrosMas(db);

void CrearTresLibrosMas(SqliteDbContext db)
{
    var libros = new List<Libro>
    {
        new Libro { Título = "Uno", EditorialId = 1, Edición = 2000, Sinópsis = "..." },
        new Libro {Título="Dos",EditorialId=1,Edición=2001,Sinópsis="..."},
        new Libro {Título="Tres",EditorialId=1,Edición=2002,Sinópsis="..."}
    };
    db.Libros.AddRange(libros);
    db.SaveChanges();
}

void ActualizarLaSinópsisDeUnLibro(SqliteDbContext db, string titulo, string sinopsis)
{
    var libro = BuscarLibroPorTítulo(db, titulo: titulo);
    if (libro is not null)
    {
        libro.Sinópsis = sinopsis;
        db.SaveChanges();
        System.Console.WriteLine("Registro actualizado.");
    }
    else
        System.Console.WriteLine($"El libro con el título {titulo} no se encuentra");
}

static Libro? BuscarLibroPorTítulo(SqliteDbContext db, string titulo)
{
    return db.Libros
                .Where(l => l.Título.Contains(titulo))
                .FirstOrDefault();
}

static void GuardarLibroDeAlfredoWayne(SqliteDbContext db)
{
    var libroDeAlfredo = new Libro
    {
        Título = "Como atrapar al guasón",
        Edición = 1975,
        Sinópsis = "oh pues deja que funcione esto, ya casi es hora"
    };
    var editorial = BuscarEditorialPorNombre("Planeta", db);
    if (editorial is not null)
    {
        libroDeAlfredo.EditorialId = editorial.Id;
        db.Libros.Add(libroDeAlfredo);
        db.SaveChanges();
    }
    else
    {
        System.Console.WriteLine("No se encuentra la editorial");
    }
}

static Editorial? BuscarEditorialPorNombre(string nombre, SqliteDbContext db)
{
    return db.Editoriales.Where(e => e.Nombre == nombre).FirstOrDefault();
}

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