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
Proceso para modificar datos de Empleado
*/

CREATE PROCEDURE modificarPersonal(
      _idempleado INTEGER, _cedula INTEGER, _nombre VARCHAR(40), _primerApellido VARCHAR(40), _segundoApellido VARCHAR(40),
      _telefono INTEGER, _fechanacimiento DATE, _contrasena VARCHAR(40), _idDireccion INTEGER, _fechaingreso DATE,
       _idpuesto INTEGER,
	-- Atributo para tipo de declaracion
	    tipoOperacion VARCHAR(20) )
language plpgsql
as $$
begin

	IF tipoOperacion = 'Insert' THEN
			--Genera una Persona
			INSERT INTO persona(cedula,	nombre,	primerApellido,	segundoApellido, telefono,
				fechaNacimiento, contrasena, idDireccion)
			VALUES (_cedula, _nombre, _primerApellido, _segundoApellido, _telefono,
				_fechaNacimiento, _contrasena, _idDireccion);
            --Genera un Empleado
            INSERT INTO empleado(fechaingreso, cedula, idpuesto)
			VALUES (_fechaingreso, _cedula, _idpuesto);


	ELSIF tipoOperacion = 'Update' THEN
			--Actualiza una Persona con cedula especifica
			UPDATE persona
            SET nombre = _nombre,
              primerApellido = _primerApellido,
              segundoApellido = _segundoApellido,
              telefono = _telefono,
              fechaNacimiento = _fechanacimiento,
              contrasena = _contrasena,
              idDireccion = _idDireccion
              WHERE cedula = _cedula;

			--Actualiza un Empleado con idEmpleado especifico
			UPDATE empleado
            SET fechaingreso = _fechaingreso,
                idpuesto = _idpuesto
              WHERE idempleado = _idempleado;

	ELSIF tipoOperacion = 'Delete' THEN
		--Elimina el Empleado
		DELETE FROM empleado WHERE idempleado = _idempleado;

	ELSE
		raise notice 'Error en modificarPersonal';

	END IF;

    commit;
end;$$;
/*
--Para ejecutar modificarPersonal:

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
