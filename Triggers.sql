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
Trigger Procedimientos Predefinidos
No permite que se actualicen los procedimientos predefinidos de los pacientes
Corresponden a los primeros 8 id's.
*/
CREATE FUNCTION procedimiento_default() RETURNS trigger AS $procedimiento_default$
    BEGIN
        IF OLD.idprocedimiento >= 1 AND OLD.idprocedimiento < 8 THEN
            RAISE EXCEPTION 'No se puede actualizar, es un valor default';
		ELSE
			RETURN OLD;
		END IF;

    END;
$procedimiento_default$ LANGUAGE plpgsql;

CREATE TRIGGER procedimiento_default BEFORE UPDATE ON procedimiento
    FOR EACH ROW EXECUTE PROCEDURE procedimiento_default();

/*
Trigger Equipos Predefinidos
No permite que se actualicen los equipos predefinidos de las camas
Corresponden a los primeros 7 id's.
*/
CREATE FUNCTION equipo_default() RETURNS trigger AS $equipo_default$
    BEGIN
        IF OLD.idequipo >= 1 AND OLD.idequipo < 7 THEN
            RAISE EXCEPTION 'No se puede actualizar, es un valor default';
		ELSE
			RETURN OLD;
		END IF;
    END;
$equipo_default$ LANGUAGE plpgsql;

CREATE TRIGGER equipo_default BEFORE UPDATE ON equipo
    FOR EACH ROW EXECUTE PROCEDURE equipo_default();