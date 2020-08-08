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

/*
Obtiene el id de la provincia a la que pertenece el canton
param: _idCanton INTEGER
return: id provincia
*/

CREATE OR REPLACE FUNCTION getprovincia(_idCanton INTEGER)
RETURNS INTEGER
AS $$
DECLARE provincia INTEGER;
BEGIN
    SELECT
        (SELECT canton.idprovincia
        FROM canton
        WHERE _idCanton= canton.idcanton)
        INTO provincia;
	RETURN provincia;
END; $$
LANGUAGE 'plpgsql';

-- SELECT getprovincia(9);

/*
Obtiene el id del canton al que pertenece el distrito
param: _idDireccion INTEGER
return: id canton
*/

CREATE OR REPLACE FUNCTION getcanton(_idDireccion INTEGER)
RETURNS INTEGER
AS $$
DECLARE canton INTEGER;
BEGIN
    SELECT
        (SELECT direccion.idcanton
        FROM direccion
        WHERE _idDireccion= direccion.iddireccion)
        INTO canton;
	RETURN canton;
END; $$
LANGUAGE 'plpgsql';

-- SELECT getcanton(4);

/*
Obtiene la dirección completa concatena dando un idDireccion.
param: _idDireccion INTEGER
return: dirección completa concatenada.
*/

CREATE OR REPLACE FUNCTION getUbicacion(_idDireccion INTEGER)
RETURNS VARCHAR(255)
AS $$
DECLARE DireccionCompleta VARCHAR(50);
BEGIN
    SELECT
        CONCAT((SELECT provincia.provincia FROM provincia
		WHERE provincia.idprovincia = getprovincia(getcanton(_idDireccion))),', ',
            (SELECT canton.canton FROM canton
		WHERE canton.idcanton = getcanton(_idDireccion)),', ',
            (SELECT direccion.distrito FROM direccion
		WHERE direccion.iddireccion = _idDireccion))INTO DireccionCompleta;
	RETURN DireccionCompleta;
END; $$
LANGUAGE 'plpgsql';

-- SELECT getUbicacion(73);

/*
Obtiene el nombre completo de una persona al ingresar su cedula.
param: _cedula INTEGER
return: nombre completo concatenado
*/

CREATE OR REPLACE FUNCTION getidpaciente(_cedula INTEGER)
RETURNS INTEGER
AS $$
DECLARE idpaciente INTEGER;
BEGIN
    SELECT
        (SELECT paciente.idpaciente
        from paciente
        where paciente.cedula = _cedula) INTO idpaciente;
	RETURN idpaciente;
END; $$
LANGUAGE 'plpgsql';

-- SELECT getidpaciente(501192614);
