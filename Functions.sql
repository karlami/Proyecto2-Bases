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
param: _cedula INTEGER
return: nombre completo concatenado
*/

CREATE OR REPLACE FUNCTION getNombreCompleto(_cedula INTEGER)
RETURNS VARCHAR(255)
AS $$
DECLARE NombreCompleto VARCHAR(50);
BEGIN
    SELECT
        CONCAT((SELECT persona.nombre FROM persona
		WHERE _cedula=persona.cedula),' ',
            (SELECT persona.primerApellido FROM persona
		WHERE _cedula=persona.cedula),' ',
            (SELECT persona.segundoApellido FROM persona
		WHERE _cedula=persona.cedula)) INTO NombreCompleto;
	RETURN NombreCompleto;
END; $$
LANGUAGE 'plpgsql';

-- SELECT getNombreCompleto(200765074);

