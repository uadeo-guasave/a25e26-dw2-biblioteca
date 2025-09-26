-- SQLite
select * from autores;

select * from editoriales;

select * from editoriales
where nombre = 'Planeta';
/* Id = 2*/

INSERT INTO libros (Título,Edición,EditorialId)
values ('Como atrapar al guasón',1975,2);


select * from libros;

