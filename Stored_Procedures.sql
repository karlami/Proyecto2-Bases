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

CREATE PROCEDURE agregarPaciente(
	-- Atributos de Persona
      _cedula INTEGER, _nombre VARCHAR(40), _primerApellido VARCHAR(40), _segundoApellido VARCHAR(40),
      _telefono INTEGER, _fechaNacimiento DATE, _contrasena VARCHAR(40), _idDireccion INTEGER)
language plpgsql
as $$
begin
    --Genera una Persona
    INSERT INTO persona(cedula,	nombre,	primerApellido,	segundoApellido, telefono,
        fechaNacimiento, contrasena, idDireccion)
    VALUES (_cedula, _nombre, _primerApellido, _segundoApellido, _telefono,
        _fechaNacimiento, _contrasena, _idDireccion);

    -- Genera un Paciente
    INSERT INTO paciente(cedula)
    VALUES(_cedula);

    commit;
end;$$;

/*
--Para ejecutar agregarPaciente:

CALL agregarPaciente(
-- Atributos de Persona
11,
'Karla',
'Rivera',
'Sanchez',
85766410,
'1997-10-24',
'23df',
3);
*/


/*
CREATE PROCEDURE agregarPaciente(
	-- Atributos de Persona
      _cedula INTEGER, _nombre VARCHAR(40), _primerApellido VARCHAR(40), _segundoApellido VARCHAR(40),
      _telefono INTEGER, _fechaNacimiento DATE, _contrasena VARCHAR(40), _idDireccion INTEGER,
	-- Atributo para tipo de declaracion
	tipoOperacion VARCHAR(20) )
language plpgsql
as $$
begin

	IF tipoOperacion = 'Insert' THEN
			--Genera un CentroHospitalario
			INSERT INTO persona(cedula,	nombre,	primerApellido,	segundoApellido, telefono,
				fechaNacimiento, contrasena, idDireccion)
			VALUES (_cedula, _nombre, _primerApellido, _segundoApellido, _telefono,
				_fechaNacimiento, _contrasena, _idDireccion);

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
*/