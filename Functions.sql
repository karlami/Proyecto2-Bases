/*
--------------------------------------------------------------------
-- Proyecto #2 - Hospital TECNológico
--------------------------------------------------------------------
-- Instituto Tecnológico de Costa Rica
-- Área Académica de Ingeniería en Computadores
-- Bases de Datos (CE3101)
-- I Semestre 2020
-- Prof. Luis Diego Noguera Mena
-- Cristhofer Azofeifa, Fiorella Delgado, Karla Rivera & Rubén Salas
--------------------------------------------------------------------
-- Hospital_TECNológico - Funciones
--------------------------------------------------------------------
*/


/*
Obtiene el nombre completo de una persona al ingresar su cedula.
param: cedula INT
return: nombre completo concatenado
*/
/*
CREATE OR REPLACE FUNCTION Presupuesto1()
RETURNS TABLE (
	Nombre_etapa varchar (60),
	nombre_obra varchar(60),
	Precio_Etapa float
)
AS $$
BEGIN
RETURN QUERY
    SELECT E.nombre, O.nombre_obra,SUM(R.cantidad * M.precio_unitario) as Precio_Etapa
	FROM Requiere R
	INNER JOIN Obra O
	ON R.id_obra = O.id
	INNER JOIN Material M
	ON M.codigo = R.codigo_material
	INNER JOIN Etapa E
	ON E.id = R.id_etapa
	GROUP BY O.id, E.nombre;
END; $$
LANGUAGE 'plpgsql';

CREATE OR REPLACE FUNCTION Planilla()
RETURNS TABLE (
	nombre_obra varchar (60),
	id int,
	nombre varchar(60),
	semana int,
	pago_semana float
)
AS $$
BEGIN
	RETURN QUERY
	SELECT	O.nombre_obra, O.id, E.nombre,L.semana,(E.pago_hora * L.horas_laboradas) as Pago_Semana
	FROM Labora_en L
	INNER JOIN Empleado E
	ON L.id_empleado = E.id
	INNER JOIN Obra O
	ON O.id = L.id_obra;
END;
$$ LANGUAGE 'plpgsql';

*/