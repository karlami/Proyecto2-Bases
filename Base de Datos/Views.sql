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
Obtiene la siguiente informaci�n del Historial Clinico de un Paciente:
idHistorial, idPaciente, Nombre completo del paciente, nombre de cada procedimiento,
nombre del tratamiento para el procedimiento en especifico, fecha del procedimiento y
dias de recuperacion de cada procedimiento.
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
/*
SELECT *
FROM viewhistorial
WHERE idpac = 2;
 */

 /*
Vista para Paciente
Obtiene la siguiente informacion del Paciente:
idPaciente, idPaciente, Nombre completo del paciente, nombre de cada procedimiento,
nombre del tratamiento para el procedimiento en especifico, fecha del procedimiento y
dias de recuperacion de cada procedimiento.
*/

CREATE VIEW viewPaciente AS
	SELECT
	    pa.idpaciente AS idpaciente,
	    pe.cedula AS cedula,
		getNombreCompleto(pa.cedula) AS nombrepaciente,
		pe.telefono AS telefono,
	    getubicacion(pe.iddireccion) as direccion,
	    pe.iddireccion as iddireccion,
	    pe.fechanacimiento AS fechanacimiento,
	    pe.contrasena AS contrasena,
	    pat.nombre AS patologia,
        pacpat.tratamiento AS tratamiento,
	    pacpat.idpaciente_patologia as idpaciente_patologia
	FROM
        persona as pe
		JOIN paciente as pa ON pe.cedula = pa.cedula
		LEFT OUTER JOIN paciente_patologia as pacpat ON pa.idpaciente = pacpat.idpaciente
		LEFT OUTER JOIN patologia as pat ON pat.idpatologia=pacpat.idpatologia;

SELECT *
FROM viewPaciente
WHERE idpaciente = 2;


 /*
Vista para Direccion
Obtiene la direccion concatenada dado el idDireccion:
*/

CREATE VIEW viewDireccion AS
	SELECT
	    direccion.iddireccion AS iddireccion,
        getubicacion(direccion.iddireccion) AS direccion
    FROM direccion;

/*
SELECT *
FROM viewDireccion;
*/

 /*
Vista para Paciente
Obtiene la siguiente informacion del Paciente:
idPaciente, idPaciente, Nombre completo del paciente, nombre de cada procedimiento,
nombre del tratamiento para el procedimiento en especifico, fecha del procedimiento y
dias de recuperacion de cada procedimiento.
*/

CREATE VIEW viewReservacion_procedimiento AS
	SELECT
        rp.idreservacion_procedimiento AS idreservacion_procedimiento,
	    rp.idreservacion AS idreservacion,
	    rp.idprocedimiento AS idprocedimiento,
	    p.nombre AS nombre,
	    p.diasrecuperacion as diasrecuperacion
	FROM
		reservacion_procedimiento as rp
		JOIN procedimiento as p ON rp.idprocedimiento = p.idprocedimiento;
/*
SELECT *
FROM viewReservacion_procedimiento
WHERE idreservacion = 2;
*/

 /*
Vista para Salones
Obtiene la siguiente informacion del Salon:
numero del salon, nombre del salon, capacidad en camas, nombre del tipo de
medicina al que pertenece el salon y numero de piso donde se ubica.
*/

CREATE VIEW viewSalon AS
	SELECT
        sal.numerosalon as numerosalon,
	    sal.nombre as nombre,
	    sal.cantidadcama as cantidadcama,
        sal.numeropiso as numeropiso,
	    tsal.tipo as tipo
	FROM
		salon as sal
		JOIN tiposalon as tsal ON sal.idtiposalon = tsal.idtiposalon;

SELECT *
FROM viewSalon
WHERE numerosalon = 1;


/*
Vista para Camas
Obtiene la siguiente informacion del Salon:
numero de cama, equipo medico que posee cada cama, salón en el que se encuentra y si es una cama UCI.
*/
CREATE VIEW viewCama AS
	SELECT
	    cae.idcama_equipo as idcama_equipo,
	    ca.numerocama as numerocama,
        e.nombre as nombreequipo,
	    sal.nombre as nombresalon,
	    ca.uci as uci
	FROM
		cama as ca
		JOIN cama_salon as casal ON casal.idcama = ca.numerocama
        JOIN salon as sal ON sal.numerosalon = casal.idsalon
        JOIN cama_equipo as cae ON cae.idcama = ca.numerocama
        JOIN equipo as e ON e.idequipo = cae.idequipo;
/*
SELECT *
FROM viewCama
WHERE numerocama = 1;
*/

/*
Vista para Personal
Obtiene la siguiente informacion de un empleado:
id, cedula, nombre, primer y segundo apellido, telefono, fecha de nacimiento
contraseña, direccion como string, id direccion, fecha de ingreso al hospital
id puesto y el nombre del puesto.
*/
CREATE VIEW viewPersonal AS
	SELECT
	    e.idempleado as idempleado,
	    e.cedula as cedula,
	    pe.nombre as nombre,
	    pe.primerapellido as primerapellido,
	    pe.segundoapellido as segundoapellido,
		pe.telefono AS telefono,
        pe.fechanacimiento AS fechanacimiento,
        pe.contrasena AS contrasena,
	    getubicacion(pe.iddireccion) as direccion,
	    pe.iddireccion as iddireccion,
        e.fechaingreso as fechaingreso,
	    e.idpuesto as idpuesto,
        pu.nombre as nombrepuesto
	FROM
		empleado as e
		JOIN persona as pe ON pe.cedula = e.cedula
        JOIN puesto as pu ON pu.idpuesto = e.idpuesto;
/*
SELECT *
FROM viewPersonal
WHERE cedula = 102981535;
*/
