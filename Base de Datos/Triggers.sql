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
-- Hospital_TECNológico - Triggers
--------------------------------------------------------------------
*/

/*
Trigger Procedimientos Medico
No permite que se eliminen los procedimientos de los pacientes.
*/
CREATE FUNCTION procedimiento() RETURNS trigger AS $procedimiento$
    BEGIN
        RAISE EXCEPTION 'No se pueden eliminar procedimientos';
    END;
$procedimiento$ LANGUAGE plpgsql;

CREATE TRIGGER procedimiento BEFORE DELETE ON procedimiento
    FOR EACH ROW EXECUTE PROCEDURE procedimiento();

/*
Trigger Equipos Medicos
No permite que se eliminen los equipos de las camas.
*/
CREATE FUNCTION equipo() RETURNS trigger AS $equipo$
    BEGIN
        RAISE EXCEPTION 'No se pueden eliminar equipos medicos';
    END;
$equipo$ LANGUAGE plpgsql;

CREATE TRIGGER equipo BEFORE DELETE ON equipo
    FOR EACH ROW EXECUTE PROCEDURE equipo();