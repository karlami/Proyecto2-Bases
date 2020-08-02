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
Vista para Paciente
Obtiene la siguiente informaci�n de los Pacientes:
Nombre Completo, C�dula, Edad, Nacionalidad, Regi�n, Patolog�as, Estado, Medicamentos, Internado y UCI.
*/
/*
CREATE VIEW viewPaciente AS
	SELECT
		dbo.getNombreCompleto(pr.cedula) AS NombreCompleto,
		pr.cedula AS Cedula,
		dbo.getEdad(fechaNacimiento) AS Edad,
		nacionalidad AS Nacionalidad,
		region AS Region,
		dbo.getPatologias(pr.cedula) AS Patologias,
		estado as Estado,
		idCentroHospitalario as CentroHospitalario,
		dbo.getMedicamentos(pa.idPaciente) as Medicamentos,
		internado as Internado,
		uci as UCI,
		pa.idPaciente as IdPaciente
	FROM
		Persona as pr
		JOIN Paciente as pa ON pa.cedula = pr.cedula
		JOIN Ubicacion as u ON pr.idUbicacion=u.idUbicacion
		JOIN EstadoPaciente as ep ON pa.idEstadoPaciente=ep.idEstadoPaciente;

*/