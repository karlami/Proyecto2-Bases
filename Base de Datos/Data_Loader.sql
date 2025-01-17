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
-- Hospital_TECNológico - Data Loader
--------------------------------------------------------------------

-- Datos de las 7 provincias de Costa Rica
INSERT INTO provincia VALUES
    (1,'San Jose'),
    (2,'Cartago'),
    (3,'Heredia'),
    (4,'Limon'),
    (5,'Guanacaste'),
    (6,'Alajuela'),
    (7,'Puntarenas');

-- Datos de 4 cantones por cada provincia de Costa Rica
INSERT INTO canton VALUES
    (1,'San Jose',1),
    (2,'Escazu',1),
    (3,'Desamparados',1),
    (4,'Puriscal',1),
    (5,'Cartago',2),
    (6,'Paraiso',2),
    (7,'La Union',2),
    (8,'Jimenez',2),
    (9,'Heredia',3),
    (10,'Barva',3),
    (11,'Santo Domingo',3),
    (12,'Santa Barbara',3),
    (13,'Limon',4),
    (14,'Pococi',4),
    (15,'Siquirres',4),
    (16,'Talamanca',4),
    (17,'Liberia',5),
    (18,'Nicoya',5),
    (19,'Santa Cruz',5),
    (20,'Bagaces',5),
    (21,'Alajuela',6),
    (22,'San Ramon',6),
    (23,'Grecia',6),
    (24,'San Mateo',6),
    (25,'Puntarenas',7),
    (26,'Osa',7),
    (27,'Buenos Aires',7),
    (28,'Montes de Oro',7);

-- Datos de 3 distritos para los cantones ingresados de Costa Rica
INSERT INTO direccion VALUES
    (1,'Carmen',1),
    (2,'Merced',1),
    (3,'Hospital',1),
    (4,'Escazu',2),
    (5,'San Antonio',2),
    (6,'San Rafael',2),
    (7,'Desamparados',3),
    (8,'San Miguel',3),
    (9,'San Juan de Dios',3),
    (10,'Santiago',4),
    (11,'Mercedes Sur',4),
    (12,'Barbacoas',4),
    (13,'Oriental',5),
    (14,'Occidental',5),
    (15,'Carmen',5),
    (16,'Paraiso',6),
    (17,'Santiago',6),
    (18,'Cachi',6),
    (19,'Tres Rios',7),
    (20,'San Diego',7),
    (21,'San Juan',7),
    (22,'Tucurrique',8),
    (23,'Pejibaye',8),
    (24,'Juan Vinas',8),
    (25,'Heredia',9),
    (26,'Mercedes',9),
    (27,'San Francisco',9),
    (28,'Barva',10),
    (29,'San Pedro',10),
    (30,'San Pablo',10),
    (31,'San Vicente',11),
    (32,'San Miguel',11),
    (33,'Santo Tomas',11),
    (34,'Santa Barbara',12),
    (35,'San Juan',12),
    (36,'Jesus',12),
    (37,'Limon',13),
    (38,'Valle la Estrella',13),
    (39,'Matama',13),
    (40,'Guapiles',14),
    (41,'Jimenez',14),
    (42,'Rita',14),
    (43,'Siquirres',15),
    (44,'Pacuarito',15),
    (45,'Florida',15),
    (46,'Bratsi',16),
    (47,'Sixaola',16),
    (48,'Cahuita',16),
    (49,'Liberia',17),
    (50,'Nacascolo',17),
    (51,'Mayorga',17),
    (52,'Nicoya',18),
    (53,'Mansion',18),
    (54,'San Antonio',18),
    (55,'Santa Cruz',19),
    (56,'Bolson',19),
    (57,'Tempate',19),
    (58,'Bagaces',20),
    (59,'La Fortuna',20),
    (60,'Mogote',20),
    (61,'San Isidro',21),
    (62,'Sabanilla',21),
    (63,'Desamparados',21),
    (64,'Santiago',22),
    (65,'San Juan',22),
    (66,'Piedades Norte',22),
    (67,'Grecia',23),
    (68,'San Isidro',23),
    (69,'Tacares',23),
    (70,'San Mateo',24),
    (71,'Desmonte',24),
    (72,'Jesus Maria',24),
    (73,'Lepanto',25),
    (74,'Paquera',25),
    (75,'Manzanillo',25),
    (76,'Puerto Cortes',26),
    (77,'Palmar',26),
    (78,'Sierpe',26),
    (79,'Pilas',27),
    (80,'Colinas',27),
    (81,'Boruca',27),
    (82,'Miramar',28),
    (83,'La Union',28),
    (84,'San Isidro',28);

-- Datos de Patologias
INSERT INTO patologia(nombre, descripcion) VALUES
    ('Alergia','Las alergias, también llamadas reacciones de hipersensibilidad.'),
    ('Bronquitis','La bronquitis es el resultado de la inflamación de los conductos que transportan el aire al interior de los pulmones.'),
    ('Leucemia','La leucemia es una enfermedad de la sangre en la que la médula ósea produce glóbulos blancos anómalos.'),
    ('Infección Renal','Cuando las bacterias entran en sus riñones, pueden causar una infección.'),
    ('Diabetes','La diabetes es una enfermedad en la que los niveles de glucosa (azúcar) de la sangre están muy altos.'),
    ('Melanoma','El melanoma es un tipo de cáncer de piel que aparece cuando las células llamadas melanocitos se convierten en malignas.'),
    ('Neumonia','La neumonía es una infección en uno o en los dos pulmones.'),
    ('Obesidad','La obesidad es una enfermedad crónica tratable que aparece cuando existe un exceso de tejido adiposo (grasa) en el cuerpo.'),
    ('Conjuntivitis','La conjuntivitis es una inflamación de la conjuntiva.'),
    ('Osteoporosis','La osteoporosis es una enfermedad sistémica esquelética.'),
    ('Pancreatitis','La pancreatitis es una inflamación del páncreas y puede ser aguda o crónica.'),
    ('Rinitis','La rinitis es un trastorno que afecta a la mucosa nasal y que produce estornudos.'),
    ('Sifilis','La sífilis es una infección de transmisión sexual (ITS) causada por la bacteria espiroqueta Treponema pallidum.'),
    ('Tos Ferina','La tos ferina es una enfermedad infecto-contagiosa aguda que afecta al aparato respiratorio.'),
    ('Vasculitis','Las vasculitis hacen referencia a un grupo de enfermedades diversas que producen la inflamación de los vasos sanguíneos.'),
    ('Botulismo','El botulismo es una enfermedad causada por la bacteria Clostridium botulinum.'),
    ('Dengue','El dengue es una enfermedad producida por un virus de la familia de los flavivirus.'),
    ('Edema Pulmonar','Un edema pulmonar es una acumulación anormal de líquido en los pulmones que provoca dificultad respiratoria.'),
    ('Faringitis','Es la inflamación de la garganta o faringe a menudo causada por una infección bacteriana o vírica.'),
    ('Linfoma','Un linfoma es una proliferación maligna de linfocitos.');

-- Datos de Personas
INSERT INTO persona VALUES
    (200765074,'Cherish','Salas','Asquez',80000000,'1991-08-13','persona',1),
    (500198769,'Juan','Ramirez','Allmann',80006730,'1982-11-28','persona',2),
    (300397538,'Ruben','Colton','Ralls',80013460,'1979-06-29','persona',3),
    (100795076,'Karla','Abden','Drogan',80020190,'1977-06-15','persona',4),
    (501192614,'Fiorella','Petracek','Breche',80026920,'2016-11-13','persona',5),
    (101590152,'Vinicio','Ray','Dumphry',80033650,'2015-11-29','persona',6),
    (501788921,'Rosa','Sanchez','Tuckie',80040380,'1946-07-13','persona',7),
    (302186459,'Carlos','Gonzalez','Garrand',80047110,'1932-05-06','persona',8),
    (102385228,'Jose','Rodriguez','Fobidge',80053840,'1998-02-18','persona',9),
    (402583997,'Marybeth','Larderot','Jardein',80060570,'1949-10-13','persona',10),
    (102981535,'Aeriel','Stainsby','Martini',80067300,'1979-07-25','persona',11),
    (103180304,'Daron','Fernandez','Hawton',80074030,'1995-05-29','persona',12),
    (303379073,'Chevy','Towson','Cerman',80080760,'2018-08-25','persona',13),
    (403577842,'Steven','Bony','Rennard',80087490,'1970-02-22','persona',14),
    (103776611,'Laura','Sprague','Wagner',80094220,'1947-10-19','persona',15),
    (703975380,'Annetta','Yarr','Kaplin',80100950,'1984-04-25','persona',16),
    (104174149,'Delbert','Roden','Huffa',80107680,'1968-01-19','persona',17),
    (304372918,'Donovan','Vedyaev','Eglin',80114410,'2010-01-23','persona',18),
    (104571687,'Beatrisa','Sumbler','Rumin',80121140,'2001-08-11','persona',19),
    (704770456,'Manuel','Rupp','Edgin',80127870,'1971-12-05','persona',20),
    (405167994,'Pail','Fernandez','Caldera',80134600,'1936-10-22','persona',21),
    (205565532,'Vincenty','Belison','Abbis',80141330,'1982-03-05','persona',22),
    (305764301,'Deb','Chestnut','Life',80148060,'1966-01-04','persona',23),
    (505963070,'Maurice','Mecozzi','Gilks',80154790,'2002-06-04','persona',24),
    (606161839,'Pablo','Pimlett','Scrancher',80161520,'1981-10-13','persona',25);

-- Datos de Paciente
INSERT INTO paciente(cedula) VALUES
    (200765074),
    (500198769),
    (300397538),
    (100795076),
    (501192614),
    (101590152),
    (501788921),
    (302186459),
    (102385228),
    (402583997);

-- Datos de la relacion paciente_patologia
INSERT INTO paciente_patologia(idpaciente, idpatologia, tratamiento) VALUES
    (1,17,'Tomar paracetamol para aliviar la fiebre producida por el dengue.'),
    (2,1,'Tomar pastillas y comprar aerosoles nasales o gotas para los ojos.'),
    (4,2,'Tomar mucho líquido y ácido acetilsalicílico.'),
    (5,3,'Aplicación de quimioterapia por 2 años.'),
    (7,5,'Inyectar insulina de acción intermedia.'),
    (2,6,'Usar protector solar siempre, aunque no haga sol.'),
    (6,8,'Seguir la dieta hipocalórica. '),
    (8,9,'Limpiar los párpados con un paño húmedo.'),
    (3,10,'Tomar mucha leche y alimentos altos en calcio.');

-- Datos de procedimientos
INSERT INTO procedimiento(nombre, diasrecuperacion) VALUES
    ('Apendicectomía',8),
    ('Biopsia de mama',30),
    ('Cirugía de cataratas',7),
    ('Cesárea',40),
    ('Histerectomía',11),
    ('Cirugía para la lumbalgia',13),
    ('Mastectomía',11),
    ('Amigdalectomía',3),
    ('TAC',4),
    ('Electroencefalograma',3),
    ('Endoscopia',11),
    ('Ecocardiografía',12),
    ('Radiografía',7),
    ('Prueba de biopsia',3),
    ('Prueba de sangre',1),
    ('Prueba de heces',0),
    ('Análisis de orina',0),
    ('Palpación',2),
    ('Fluoroscopia',14),
    ('Escintigrafía',4);

-- Datos de Historial clinico
INSERT INTO historial_clinico(tratamiento, fecha, idpaciente, idprocedimiento) VALUES
    ('Coma lo suficiente para evitar desmayos.','2020-08-16',1,15),
    ('Tome mucha agua para que expluse el filtro inyectado cuando se le aplica el TAC.','2020-08-15',2,9),
    ('Use lentes oscuros por 4 meses.','2020-08-13',3,3),
    ('Repose por 40 días mínimos.','2020-08-17',4,4),
    ('Evite el estrés y duerma lo suficiente.','2020-08-16',5,10),
    ('No tiene ningún tratamiento en particular.','2020-08-10',6,17),
    ('No se exponga al sol directamente para evitar infecciones en los ojos.','2020-08-09',7,3),
    ('No use sostén con varillas.','2020-08-15',10,2),
    ('Humecte bien su cuerpo en caso de sequedad.','2020-08-13',9,13),
    ('Lave bien su cuerpo luego de la palpación.','2020-08-14',10,18),
    ('Evite rascarse la piel en caso de picazón, puede sufrir descamación.','2020-08-07',1,13),
    ('Coma bastante antes y después de la prueba de sangre.','2020-08-18',2,15),
    ('El examen no es doloroso y no tiene efectos secundarios, no hay un tratamiento.','2020-08-09',2,20),
    ('Permanecer en el hospital entre 1 y 2 horas para que el sedante se pueda disipar.','2020-08-18',3,11);

-- Datos de cama
INSERT INTO cama(uci) VALUES
    ('true'),
    ('false'),
    ('false'),
    ('false'),
    ('false'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('false'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('false'),
    ('false'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('false'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('false'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('false'),
    ('true'),
    ('true'),
    ('false'),
    ('false'),
    ('false'),
    ('false'),
    ('false'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('true'),
    ('false'),
    ('false'),
    ('true'),
    ('true'),
    ('false'),
    ('true'),
    ('true'),
    ('false'),
    ('true');

-- Datos de Reservacion
INSERT INTO reservacion(fechaingreso, fechasalida, idpaciente, idcama) VALUES
    ('2020-08-18','2020-09-13',4,70),
    ('2020-07-25','2020-09-01',9,96),
    ('2020-07-17','2020-08-02',10,18),
    ('2020-08-06','2020-08-17',3,55),
    ('2020-08-12','2020-08-23',1,34),
    ('2020-08-09','2020-08-16',1,54),
    ('2020-08-24','2020-08-24',8,44),
    ('2020-07-16','2020-08-25',1,81),
    ('2020-08-21','2020-08-28',9,63),
    ('2020-07-14','2020-07-15',8,39);

-- Datos de relacion reservacion_procedimiento
INSERT INTO reservacion_procedimiento(idreservacion, idprocedimiento) VALUES
    (1,19),
    (2,2),
    (3,10),
    (4,5),
    (5,7),
    (6,3),
    (7,17),
    (8,4),
    (9,3),
    (10,15),
    (2,1),
    (3,6),
    (1,15),
    (1,5);

-- Datos de Equipo
INSERT INTO equipo(nombre, proveedor, cantidad) VALUES
    ('Luz quirurjica','ELEINMSA',60),
    ('Ultrasonido','Philips',40),
    ('Esterilizador','Seyla',100),
    ('Desfibrilador','INSUMED',80),
    ('Monitor','ELEINMSA',80),
    ('Respirador artificial','Avante',120),
    ('Electrocardiografo','INSUMED',40),
    ('Oximetro','Seyla',40),
    ('Maquina de anestesia','ELEINMSA',40),
    ('Electrobisturi','MESA Medical',100),
    ('Rayos X','Alfa Médica',5),
    ('Bombas de infusion','Sire Medical',120),
    ('Glucometro','Baxter',100),
    ('Esfigmomanometro de mercurio','Avante',40);

-- Datos de los 3 puestos
INSERT INTO puesto(nombre) VALUES
    ('Personal Administrativo'),
    ('Doctor/Doctora'),
    ('Enfermero/Enfermera');

-- Datos de Empleado
INSERT INTO empleado(fechaingreso, cedula, idpuesto) VALUES
    ('2014-12-08',102981535,2),
    ('2004-12-20',103180304,3),
    ('2017-10-14',303379073,3),
    ('2008-03-25',403577842,3),
    ('2008-05-30',103776611,2),
    ('2009-07-02',703975380,2),
    ('2002-07-06',104174149,1),
    ('2006-12-17',304372918,3),
    ('2001-01-08',104571687,1),
    ('2013-06-25',704770456,2),
    ('2019-05-05',405167994,1),
    ('2011-11-16',205565532,2),
    ('2000-10-24',305764301,2),
    ('2013-07-24',505963070,3),
    ('2014-10-13',606161839,2);

-- Datos de los 3 tipos de salon
INSERT INTO tiposalon(tipo) VALUES
    ('Medicina de mujer'),
    ('Medicina de hombre'),
    ('Medicina de niño');

-- Datos de Salones
INSERT INTO salon(nombre, cantidadcama, numeropiso, idtiposalon) VALUES
    ('Cirugia P1',1,1,1),
    ('Recuperacion P2',10,2,2),
    ('Cuidados intensivos P3',5,3,3),
    ('Covid-19 P3',6,3,3),
    ('Posibles infectados P2',12,2,2),
    ('Maternidad P1',10,1,1),
    ('Cirugia P2',1,2,1),
    ('Recuperacion P1',10,1,2),
    ('Cuidados intensivos P1',3,1,3),
    ('Covid-19 P2',6,2,3),
    ('Posibles infectados P3',10,3,2),
    ('Maternidad P3',5,3,1);

-- Datos de relacion cama-salon
INSERT INTO cama_salon VALUES
    (1,9),
    (2,2),
    (3,8),
    (4,6),
    (5,9),
    (6,8),
    (7,10),
    (8,8),
    (9,6),
    (10,6),
    (11,12),
    (12,3),
    (13,11),
    (14,3),
    (15,9),
    (16,3),
    (17,8),
    (18,10),
    (19,2),
    (20,11),
    (21,2),
    (22,6),
    (23,5),
    (24,6),
    (25,11),
    (26,12),
    (27,6),
    (28,5),
    (29,6),
    (30,6),
    (31,9),
    (32,12),
    (33,2),
    (34,2),
    (35,5),
    (36,2),
    (37,12),
    (38,7),
    (39,7),
    (40,4),
    (41,11),
    (42,4),
    (43,11),
    (44,11),
    (45,9),
    (46,8),
    (47,12),
    (48,3),
    (49,7),
    (50,2),
    (51,8),
    (52,6),
    (53,5),
    (54,4),
    (55,7),
    (56,2),
    (57,5),
    (58,5),
    (59,10),
    (60,2),
    (61,9),
    (62,5),
    (63,4),
    (64,10),
    (65,12),
    (66,4),
    (67,1),
    (68,1),
    (69,1),
    (70,12),
    (71,8),
    (72,11),
    (73,9),
    (74,8),
    (75,10),
    (76,5),
    (77,4),
    (78,3),
    (79,4),
    (80,12),
    (81,2),
    (82,11),
    (83,6),
    (84,6),
    (85,3),
    (86,6),
    (87,9),
    (88,5),
    (89,11),
    (90,4),
    (91,3),
    (92,1),
    (93,7),
    (94,2),
    (95,2),
    (96,11),
    (97,9),
    (98,3),
    (99,11),
    (100,12);

-- Datos de relacion cama_equipo

INSERT INTO cama_equipo(idcama, idequipo) VALUES
    (76,10),
    (46,11),
    (26,13),
    (97,2),
    (19,2),
    (81,1),
    (21,9),
    (99,3),
    (71,13),
    (61,3),
    (28,8),
    (76,8),
    (86,8),
    (98,9),
    (99,14),
    (25,6),
    (48,1),
    (50,5),
    (78,1),
    (2,10),
    (13,1),
    (85,6),
    (82,12),
    (53,9),
    (34,7),
    (97,5),
    (46,10),
    (8,1),
    (49,4),
    (58,2),
    (29,5),
    (19,6),
    (70,3),
    (19,4),
    (97,1),
    (7,14),
    (11,10),
    (86,6),
    (62,13),
    (33,6),
    (7,6),
    (23,3),
    (5,2),
    (43,13),
    (17,9),
    (38,10),
    (12,3),
    (70,9),
    (35,3),
    (27,3),
    (83,9),
    (40,4),
    (65,5),
    (3,5),
    (25,12),
    (19,8),
    (87,12),
    (53,5),
    (77,3),
    (82,1),
    (74,6),
    (45,4),
    (11,12),
    (91,2),
    (62,8),
    (74,10),
    (32,2),
    (51,6),
    (63,5),
    (19,5),
    (98,13),
    (86,1),
    (24,8),
    (68,8),
    (34,8),
    (90,9),
    (8,3),
    (100,7),
    (14,6),
    (3,10),
    (50,4),
    (94,3),
    (40,12),
    (11,5),
    (11,7),
    (25,13),
    (21,13),
    (96,5),
    (37,2),
    (24,5),
    (74,1),
    (60,3),
    (43,10),
    (56,1),
    (26,11),
    (14,12),
    (74,5),
    (53,7),
    (37,7),
    (23,8),
    (19,9),
    (12,10),
    (5,6),
    (36,2),
    (24,12),
    (70,9),
    (52,14),
    (70,14),
    (50,9),
    (34,11),
    (61,13),
    (80,1),
    (76,12),
    (19,14),
    (16,9),
    (69,14),
    (93,13),
    (43,12),
    (80,12),
    (34,4),
    (46,10),
    (21,1),
    (82,11),
    (82,11),
    (74,1),
    (44,5),
    (86,2),
    (11,13),
    (2,11),
    (74,7),
    (44,8),
    (66,4),
    (78,7),
    (62,6),
    (47,14),
    (62,9),
    (74,10),
    (93,3),
    (36,8),
    (58,1),
    (42,1),
    (95,6),
    (10,8),
    (30,13),
    (86,10),
    (33,6),
    (88,7),
    (87,6),
    (58,8),
    (43,13),
    (57,3),
    (36,7),
    (9,9),
    (10,8),
    (75,3),
    (36,9),
    (59,8),
    (1,6),
    (26,14),
    (51,4),
    (76,10),
    (31,2),
    (77,11),
    (77,7),
    (71,3),
    (28,12),
    (88,6),
    (62,13),
    (60,13),
    (60,1),
    (92,6),
    (22,14),
    (59,1),
    (51,14),
    (74,9),
    (21,5),
    (85,11),
    (44,14),
    (41,5),
    (99,1),
    (89,4),
    (99,12),
    (21,1),
    (1,10),
    (13,12),
    (29,14),
    (19,14),
    (88,11),
    (91,2),
    (80,5),
    (26,11),
    (52,11),
    (17,4),
    (46,11),
    (32,6),
    (93,13),
    (3,8),
    (41,14),
    (62,14),
    (88,3);

