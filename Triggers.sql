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
Trigger Estados Predefinidos en EstadoPaciente
No permite que se eliminen los estados predefinidos de los pacientes (Primeros 4 ids).
*/
CREATE FUNCTION etapa_default() RETURNS trigger AS $etapa_default$
    BEGIN
        IF OLD.id >= 1 AND OLD.id <= 20 THEN
            RAISE EXCEPTION 'No se puede eliminar o actualizar, es un valor default';
		ELSE
			RETURN OLD;
		END IF;

    END;
$etapa_default$ LANGUAGE plpgsql;