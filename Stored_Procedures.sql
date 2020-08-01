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
-- Hospital_TECNológico - Stored Procedures
--------------------------------------------------------------------

/*
Proceso para modificar datos de CentroHospitalario
*/

CREATE PROCEDURE modifyPaciente(
	-- Atributos de CentroHospitalario
	idCentroHospitalario INT,
	nombre VARCHAR(200),
	capacidad INT,
	capacidadUci INT,
	contacto VARCHAR(50),
	irector VARCHAR(30),
	pais VARCHAR(75),
	egion VARCHAR(75),
	-- Atributo para tipo de declaracion
	tipoOperacion VARCHAR(20) )
language plpgsql
as $$
begin

	IF tipoOperacion = 'Insert' THEN
			--Genera un CentroHospitalario
			INSERT INTO CentroHospitalario (
				nombre,
				capacidad,
				capacidadUci,
				contacto,
				director,
				idUbicacion )
			VALUES (
				@nombre,
				@capacidad,
				@capacidadUci,
				@contacto,
				@director,
				dbo.getIdUbicacionFromRegionPais(@region, @pais) );

	ELSIF @statementType = 'Update' THEN
			--Actualiza un CentroHospitalario con idCentroHospitalario especifico
			UPDATE CentroHospitalario
			SET nombre = @nombre,
				capacidad = @capacidad,
				capacidadUci = @capacidadUci,
				contacto = @contacto,
				director = @director,
				idUbicacion = dbo.getIdUbicacionFromRegionPais(@region, @pais)
			--Verifica que este actualizando el idCentroHospitalario que es
			WHERE idCentroHospitalario = @idCentroHospitalario
				AND @capacidadUci <= @capacidad; --Verifica que las capacidades coincidan
				IF (@capacidadUci > @capacidad) THEN
				END IF;

	ELSIF @statementType = 'Delete' THEN
		--Actualiza el idCentroHospitalario que se borra del Paciente y le asigna uno random
		UPDATE Paciente
			SET idCentroHospitalario = (SELECT TOP 1 idCentroHospitalario From CentroHospitalario ORDER BY NEWID())
			--Verifica que este actualizando el idCentroHospitalario que es
			WHERE idCentroHospitalario = (SELECT idCentroHospitalario FROM CentroHospitalario WHERE idCentroHospitalario = @idCentroHospitalario)
		--Elimina el centroHospitalario
		DELETE FROM CentroHospitalario WHERE idCentroHospitalario = @idCentroHospitalario;


	ELSE
		PRINT ('Error en modifyCentroHospitalario')

	END IF;

    commit;
end;$$;
/*
--Para ejecutar modifyCentroHospitalario:

EXEC modifyCentroHospitalario
-- Atributos de CentroHospitalario
@idCentroHospitalario = 202,
@nombre = 'Vicente de Paul',
@capacidad = 176,
@capacidadUci = 175,
@contacto = '(506) 123456',
@director = '100397538',
@pais = 'Costa Rica',
@region = 'Heredia',
-- Atributo para tipo de declaracion
@statementType = 'Insert';
*/
