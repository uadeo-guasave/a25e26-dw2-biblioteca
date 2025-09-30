-- SQLite
select * from autores;

select * from editoriales;

select * from editoriales
where nombre = 'Planeta';
/* Id = 2*/

INSERT INTO libros (Título,Edición,EditorialId)
values ('Como atrapar al guasón',1975,2);


select * from libros;

UPDATE Libros SET
Sinópsis = 'Pregúntale a Batman'
WHERE Id = 1;

DELETE FROM Libros
WHERE Id = ?;

/* consulta para mostrar todos los libros con el nombre de la editorial */
SELECT
    l.*,
    e.nombre Editorial
FROM Libros l
JOIN Editoriales e
  ON l.editorialid = e.id
