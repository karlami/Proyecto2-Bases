--------------------------------------------------------------------
-- Proyecto #2 - Hospital TECNológico
--------------------------------------------------------------------
-- Instituto Técnológico de Costa Rica
-- Área Académica de Ingeniería en Computadores
-- Bases de Datos (CE3101)
-- I Semestre 2020
-- Prof. Luis Diego Noguera Mena
-- Cristhofer Azofeifa, Fiorella Delgado, Karla Rivera & Rubén Salas
--------------------------------------------------------------------
-- Hospital_TECNológico - Table Creator
--------------------------------------------------------------------

-- Tabla Provincia
-- Atributos: IdProvincia y Nombre de Provincia

CREATE TABLE IF NOT EXISTS Provincia(
    idProvincia INTEGER PRIMARY KEY,
    provincia VARCHAR(40) NOT NULL
);

-- Tabla Canton
-- Atributos: IdCanton, nombre del canton y
-- Referencia a Provincia

CREATE TABLE IF NOT EXISTS Canton(
    idCanton INTEGER PRIMARY KEY,
    canton VARCHAR(40) NOT NULL,
    idProvincia INTEGER NOT NULL REFERENCES Provincia(idProvincia)
);

-- Tabla Direccion
-- Atributos: IdDireccion, nombre del Distrito y
-- Referencia a Canton

CREATE TABLE IF NOT EXISTS Direccion(
    idDireccion INTEGER PRIMARY KEY,
    distrito VARCHAR(40) NOT NULL,
    idCanton INTEGER NOT NULL REFERENCES Canton(idCanton)
);

-- Tabla Patologia
-- Atributos: idPatologia, nombre y descripcion

CREATE TABLE IF NOT EXISTS Patologia(
    idPatologia INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    descripcion VARCHAR(255) NOT NULL
);

-- Tabla Persona
-- Atributos: cedula, Nombre, primer Apellido, segundo
-- Apellido, telefono, fecha de nacimiento y
-- Referencia a Direccion

CREATE TABLE IF NOT EXISTS Persona(
      cedula INTEGER PRIMARY KEY,
      nombre VARCHAR(40) NOT NULL,
      primerApellido VARCHAR(40) NOT NULL,
      segundoApellido VARCHAR(40) NOT NULL,
      telefono INTEGER NOT NULL,
      fechaNacimiento DATE NOT NULL,
      contrasena VARCHAR(40) NOT NULL,
      idDireccion INTEGER NOT NULL REFERENCES Direccion(idDireccion)
);

-- Tabla Paciente
-- Atributos: IdPaciente y cedula: hace referencia a Persona

CREATE TABLE IF NOT EXISTS Paciente(
    idPaciente INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    cedula INTEGER REFERENCES Persona(cedula)
);

-- Tabla Cruz Paciente
-- Atributos: referencia a Paciente, referencia a Patolofia
-- y tratamiento para el paciente, segun la patologia

CREATE TABLE IF NOT EXISTS Paciente_Patologia(
    idPaciente INTEGER REFERENCES Paciente(idPaciente),
    idPatologia INTEGER REFERENCES Patologia(idPatologia),
    tratamiento VARCHAR(100) NOT NULL
);

-- Tabla Procedimiento
-- Atributos: idProcedimiento, nombre y dias de Recuperacion
-- Cargar los Procedimientos: Apendicectomía, Biopsia de mama, Cirugía de cataratas,
-- Cesárea, Histerectomía, Cirugía para la lumbalgia, Mastectomía, Amigdalectomía.

CREATE TABLE IF NOT EXISTS Procedimiento(
    idProcedimiento INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    diasRecuperacion INTEGER NOT NULL
);

-- Tabla Historial_Clinico
-- Atributos: idHistorialClinico, nombre del tratamiento (el tratamiento puede ser diferente para los
-- pacientes, aunque tengan el mismo procedimiento), fecha del
-- tratamiento aplicado al paciente, referencia a Paciente y
-- referencia al Procedimiento

CREATE TABLE IF NOT EXISTS Historial_Clinico(
    idHistorial INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    tratamiento VARCHAR(255) NOT NULL,
    fecha DATE NOT NULL,
    idPaciente INTEGER NOT NULL REFERENCES Paciente(idPaciente),
    idProcedimiento INTEGER NOT NULL REFERENCES Procedimiento(idProcedimiento)
);

-- Tabla Cama
-- Atributos: idCama, numero de Cama y si es uci o no

CREATE TABLE IF NOT EXISTS Cama(
    numeroCama INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    uci BOOLEAN NOT NULL
);

-- Tabla Reservacion
-- Atributos: idReservacion, fecha de Ingreso, fecha de Salida
-- Referencia a Paciente y referencia a Cama
-- Fecha Salida = fecha ingreso mas dias requeridos de cada procedimiento

CREATE TABLE IF NOT EXISTS Reservacion(
    idReservacion INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    fechaIngreso DATE NOT NULL,
    fechaSalida DATE NOT NULL,
    idPaciente INTEGER NOT NULL REFERENCES Paciente(idPaciente),
    idCama INTEGER NOT NULL REFERENCES Cama(numeroCama)
);

-- Tabla cruz Reservacion_Procedimiento
-- Atributos: Referencia a Paciente y referencia a Procedimiento

CREATE TABLE IF NOT EXISTS Reservacion_Procedimiento(
    idReservacion INTEGER NOT NULL REFERENCES Reservacion(idReservacion),
    idProcedimiento INTEGER NOT NULL REFERENCES Procedimiento(idProcedimiento)
);

-- Tabla Equipo
-- Atributos: idEquipo, nombre del equipo y proveedor
-- Por default se conocen: luces quirúrgicas, ultrasonidos,
-- esterilizadores, desfibriladores, monitores,
-- respiradores artificiales y electrocardiógrafos.

CREATE TABLE IF NOT EXISTS Equipo(
    idEquipo INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL,
    proveedor VARCHAR(40) NOT NULL,
    cantidad INTEGER NOT NULL
);

-- Tabla Puesto
-- Atribtuos: nombre del puesto de cada empleado
-- Puestos existentes: personal administrativo, doctor o enfermero

CREATE TABLE IF NOT EXISTS Puesto(
    idPuesto INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL
);

-- Tabla Empleado
-- Atributos: IdEmpleado, Fecha de Ingreso, referencai a Persona
-- y referencia a Puesto

CREATE TABLE IF NOT EXISTS Empleado(
    IdEmpleado INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    fechaIngreso DATE NOT NULL,
    cedula INTEGER NOT NULL REFERENCES Persona(cedula),
    idPuesto INTEGER NOT NULL REFERENCES Puesto(idPuesto)
);

-- Tabla TipoSalon
-- Atributos: IdTipoSalon y tipo de Salon
-- Tipos existentes: medicina de mujeres, hombres o niños

CREATE TABLE IF NOT EXISTS TipoSalon(
    idTipoSalon INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    tipo VARCHAR(40) NOT NULL
);

-- Tabla Salon
-- Atributos: numero de Salon, nombre de salon, cantidad de
-- camas disponibles en salon, numero de piso
-- y referencia al tipo de Salon al que pertenece

CREATE TABLE IF NOT EXISTS Salon(
    numeroSalon INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL,
    cantidadCama INTEGER NOT NULL,
    numeroPiso INTEGER NOT NULL,
    idTipoSalon INTEGER NOT NULL REFERENCES TipoSalon(idTipoSalon)
);

-- Tabla Cruz Cama_Salon
-- Atributos: referencias a Cama y Salon

CREATE TABLE IF NOT EXISTS Cama_Salon(
    idCama INTEGER NOT NULL REFERENCES Cama(numeroCama),
    idSalon INTEGER NOT NULL REFERENCES Salon(numeroSalon)
);

-- Tabla Cruz Cama_Equipo
-- Atributos: cantidad disponible de camas por equipo y
-- referencias a Cama y Equipo

CREATE TABLE IF NOT EXISTS Cama_Equipo(
    idCama INTEGER NOT NULL REFERENCES Cama(numeroCama),
    idEquipo INTEGER NOT NULL REFERENCES Equipo(idEquipo)
);