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
-- Hospital_TECNológico - Vistas
--------------------------------------------------------------------
*/


/*
Vista para Historial Clinico
Obtiene la siguiente informaci�n de los Pacientes:
Nombre Completo, C�dula, Edad, Nacionalidad, Regi�n, Patolog�as, Estado, Medicamentos, Internado y UCI.
*/

CREATE VIEW viewHistorial AS
	SELECT
	    hc.idhistorial AS idhistorial,
	    pa.idpaciente AS idpac,
		getNombreCompleto(pa.cedula) AS nombrepaciente,
		proc.nombre AS procedimiento,
	    hc.tratamiento AS tratam,
	    hc.fecha AS fechaProc,
	    proc.diasrecuperacion AS dias
	FROM
		historial_clinico as hc
		JOIN paciente as pa ON pa.idpaciente = hc.idpaciente
		JOIN procedimiento as proc ON proc.idprocedimiento=hc.idprocedimiento;

SELECT *
FROM viewhistorial
WHERE idpac = 2;

