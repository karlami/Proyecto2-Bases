-- Tabla Provincia con IdProvincia, IdPais y NombreProvincia

CREATE TABLE IF NOT EXISTS Provincia(
    idProvincia INTEGER PRIMARY KEY,
    provincia VARCHAR(40) NOT NULL
);

-- Tabla Canton con IdCanton, IdProvincia y NombreCanton

CREATE TABLE IF NOT EXISTS Canton(
    idCanton INTEGER PRIMARY KEY,
    idProvincia INTEGER NOT NULL REFERENCES Provincia(idProvincia),
    canton VARCHAR(40) NOT NULL
);

-- Tabla Distrito con IdDistrito, IdCanton y NombreDistrito

CREATE TABLE IF NOT EXISTS Distrito(
    idDistrito INTEGER PRIMARY KEY,
    IdCanton INTEGER NOT NULL REFERENCES Canton(idCanton),
    distrito VARCHAR(40) NOT NULL
);

-- Tabla Direccion con IdDireccion, IdCanton y Direccion

CREATE TABLE IF NOT EXISTS Direccion(
    idDireccion INTEGER PRIMARY KEY,
    idCanton INTEGER NOT NULL REFERENCES Canton(idCanton),
    direccion VARCHAR(40) NOT NULL
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS Tratamiento(
    idTratamiento INTEGER PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS Patologia(
    idPatologia INTEGER PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS TratamientoPatologia(
    idTratamientoPatologia INTEGER PRIMARY KEY,
    idTratamiento INTEGER NOT NULL REFERENCES Tratamiento(idTratamiento),
    idPatologia INTEGER NOT NULL REFERENCES Patologia(idPatologia)
);

-- Tabla Persona con IdPersona, Nombre, Apellido e Identificacion

CREATE TABLE IF NOT EXISTS Persona(
      cedula INTEGER PRIMARY KEY,
      nombre VARCHAR(40) NOT NULL,
      primerApellido VARCHAR(40) NOT NULL,
      segundoApellido VARCHAR(40) NOT NULL,
      telefono VARCHAR(20) NOT NULL,
      fechaNacimiento DATE NOT NULL,
      idDireccion INTEGER NOT NULL REFERENCES Direccion(idDireccion)
);

-- Tabla MarcaArticulo con IdMarcaArticulo y Marca

CREATE TABLE IF NOT EXISTS Paciente(
    idPaciente INTEGER PRIMARY KEY,
    cedula INTEGER REFERENCES Persona(cedula),
    idTratamientoPatologia INTEGER NOT NULL REFERENCES TratamientoPatologia(idTratamientoPatologia)
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria
-- Cargar los Procedimientos: Apendicectomía, Biopsia de mama, Cirugía de cataratas,
-- Cesárea, Histerectomía, Cirugía para la lumbalgia, Mastectomía, Amigdalectomía.

CREATE TABLE IF NOT EXISTS Procedimiento(
    idProcedimiento INTEGER PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL,
    diasRecuperacion INT NOT NULL
);

-- Tabla MarcaArticulo con IdMarcaArticulo y Marca

CREATE TABLE IF NOT EXISTS Historial(
    idHistorial INTEGER PRIMARY KEY,
    cedula INTEGER REFERENCES Persona(cedula),
    idTratamientoPatologia INTEGER NOT NULL REFERENCES TratamientoPatologia(idTratamientoPatologia)
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria
-- Fecha Salida = fecha ingreso mas dias requeridos de cada procedimiento

CREATE TABLE IF NOT EXISTS Reservacion(
    idReservacion INTEGER PRIMARY KEY,
    fechaIngreso DATE NOT NULL,
    diasRecuperacion INT NOT NULL,
    fechaSalida DATE NOT NULL,
    idPaciente INTEGER NOT NULL REFERENCES Paciente(idPaciente)

);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS ProcedimientoReservacion(
    idProcedimientoReservacion INTEGER PRIMARY KEY,
    idProcedimiento INTEGER NOT NULL REFERENCES Procedimiento(idProcedimiento),
    idReservacion INTEGER NOT NULL REFERENCES Reservacion(idReservacion)
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria
-- Por default se conocen: luces quirúrgicas, ultrasonidos,
-- esterilizadores, desfibriladores, monitores,
-- respiradores artificiales y electrocardiógrafos.

CREATE TABLE IF NOT EXISTS Equipo(
    idEquipo INTEGER PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL,
    proveedor VARCHAR(40) NOT NULL,
    cantidadDisponible INT NOT NULL
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS Puesto(
    idPuesto INTEGER PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL
);

-- Tabla Empleado con IdEmpleado, IdPersona, Estado, FechaIngreso y Puesto

CREATE TABLE IF NOT EXISTS Empleado(
    IdEmpleado INTEGER PRIMARY KEY,
    fechaIngreso DATE NOT NULL,
    cedula INTEGER NOT NULL REFERENCES Persona(cedula),
    idPuesto INTEGER NOT NULL REFERENCES Puesto(idPuesto)
);

-- Tabla Empleado con IdEmpleado, IdPersona, Estado, FechaIngreso y Puesto

CREATE TABLE IF NOT EXISTS Salon(
    numeroSalon INTEGER PRIMARY KEY,
    nombre VARCHAR(40) NOT NULL,
    capacidad INT NOT NULL,
    tipoMedicina VARCHAR(40) NOT NULL,
    pisoUbica INT NOT NULL
);

-- Tabla Empleado con IdEmpleado, IdPersona, Estado, FechaIngreso y Puesto

CREATE TABLE IF NOT EXISTS Cama(
    numeroCama INTEGER PRIMARY KEY,
    uci BOOLEAN NOT NULL
);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS CamaSalon(
    idCamaSalon INTEGER PRIMARY KEY,
    numeroCama INTEGER NOT NULL REFERENCES Cama(numeroCama),
    numeroSalon INTEGER NOT NULL REFERENCES Salon(numeroSalon)

);

-- Tabla CategoriaArticulo con IdCategoriaArticulo y Categoria

CREATE TABLE IF NOT EXISTS EquipoCama(
    idEquipoCama INTEGER PRIMARY KEY,
    idEquipo INTEGER NOT NULL REFERENCES Equipo(idEquipo),
    numeroCama INTEGER NOT NULL REFERENCES Cama(numeroCama)
);
