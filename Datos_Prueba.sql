-- JUGADOR

INSERT INTO Jugador (Nombre, Fecha_Registro) VALUES 
('Sofia Ruiz', '2026-03-01 09:00:00');

-- CATEGORÍAS (México)

INSERT INTO Categoria (ID_Cat, Nombre, Total_Preguntas) VALUES 
(1, 'Historia', 14),
(2, 'Geografía', 14),
(3, 'Cultura y Tradiciones', 14),
(4, 'Gastronomía', 14),
(5, 'Arte y Entretenimiento', 14),
(6, 'Deportes', 14),
(7, 'Naturaleza y Biodiversidad', 14);

-- PREGUNTAS (14 por Categoría)

-- Historia (ID_Cat 1)
INSERT INTO `Pregunta` (`ID_Cat`, `ID_Preg`, `Enunciado`) VALUES 
(1, 1, '¿En qué año inició la Independencia de México?'),
(1, 2, '¿Quién es conocido como el Padre de la Patria?'),
(1, 3, '¿Qué cultura prehispánica fundó Tenochtitlán?'),
(1, 4, '¿Cuál fue el primer presidente de México?'),
(1, 5, '¿Qué conflicto ocurrió entre 1910 y 1920?'),
(1, 6, '¿Qué tratado puso fin a la guerra entre México y EE. UU. en 1848?'),
(1, 7, '¿Qué edificio fue mandado a construir por Porfirio Díaz para celebrar el centenario de la independencia?'),
(1, 8, '¿Qué zona arqueológica fue un centro de poder Maya?'),
(1, 9, '¿En qué estado de la república se dio el Grito de Dolores?'),
(1, 10, '¿Qué símbolo patrio fue adoptado oficialmente en 1968?'),
(1, 11, '¿Qué composición fue escrita por Francisco González Bocanegra y Jaime Nunó?'),
(1, 12, '¿Qué sonido es representativo del llamado a las armas de Miguel Hidalgo?'),
(1, 13, '¿Qué estilo musical acompañó a los ejércitos durante la Revolución Mexicana?'),
(1, 14, '¿Qué obra orquestal moderna representa el nacionalismo mexicano de mediados del siglo XX?');

-- Geografía (ID_Cat 2)
INSERT INTO `Pregunta` VALUES 
(2, 1, '¿Cuál es la capital de México?'),
(2, 2, '¿Qué estado de la república tiene más municipios?'),
(2, 3, '¿En qué estado se encuentra la ciudad de Cancún?'),
(2, 4, '¿Qué océano baña las costas del occidente de México?'),
(2, 5, '¿Cuál es el volcán más alto de México?'),
(2, 6, '¿Qué país hace frontera con México al sur, junto con Belice?'),
(2, 7, '¿Qué estado es famoso por la ciudad de León y sus momias?'),
(2, 8, '¿Qué península separa el Golfo de México del Mar Caribe?'),
(2, 9, '¿Qué ruinas arqueológicas se encuentran en la península de Yucatán?'),
(2, 10, '¿Qué palacio se encuentra en el centro de la Ciudad de México?'),
(2, 11, '¿Qué instrumento es típico del estado sureño de Chiapas?'),
(2, 12, '¿Qué sonido es característico de las selvas del sureste mexicano?'),
(2, 13, '¿Qué música es representativa del estado de Jalisco?'),
(2, 14, '¿Qué canción suele cantarse en los estadios para representar a México?');

-- Cultura y Tradiciones (ID_Cat 3)
INSERT INTO `Pregunta` VALUES 
(3, 1, '¿En qué fechas se celebra principalmente el Día de Muertos?'),
(3, 2, '¿En qué estado se celebra la fiesta de la Guelaguetza?'),
(3, 3, '¿De qué estado son originarios los Voladores de Papantla?'),
(3, 4, '¿Qué leyenda mexicana habla de una mujer que llora por sus hijos?'),
(3, 5, '¿Cómo se le llama al deporte ecuestre tradicional de México?'),
(3, 6, '¿Qué figuras talladas en madera y pintadas de colores son típicas de Oaxaca?'),
(3, 7, '¿Qué zona arqueológica es ícono de la cultura Maya?'),
(3, 8, '¿Cuál de estos es un símbolo patrio que se honra en las escuelas?'),
(3, 9, '¿Qué platillo es un ícono de la cultura urbana en la Ciudad de México?'),
(3, 10, '¿Qué animal endémico es representativo de la cultura de Xochimilco?'),
(3, 11, '¿Qué género musical es Patrimonio Cultural Inmaterial de la Humanidad?'),
(3, 12, '¿Qué tradición sonora ocurre la noche del 15 de septiembre?'),
(3, 13, '¿Qué canción es un himno no oficial de los mexicanos en el extranjero?'),
(3, 14, '¿Qué sonido acompaña las fiestas tradicionales en el sur de México?');

-- Gastronomía (ID_Cat 4)
INSERT INTO `Pregunta` VALUES 
(4, 1, '¿De qué estado es originario el Mole Poblano?'),
(4, 2, '¿De qué planta se extrae el Tequila?'),
(4, 3, '¿En qué estado es tradicional comer Cabrito?'),
(4, 4, '¿Qué tipo de carne se usa tradicionalmente para la Cochinita Pibil?'),
(4, 5, '¿Cuál es el grano base para preparar un buen Pozole?'),
(4, 6, '¿Qué bebida prehispánica fermentada es conocida como "la bebida de los dioses"?'),
(4, 7, '¿Qué platillo se prepara en un trompo y se acompaña con piña?'),
(4, 8, '¿Qué platillo representa los colores de la bandera de México?'),
(4, 9, '¿En qué estado es originaria la Cochinita Pibil?'),
(4, 10, '¿En qué estado son famosas las Enchiladas Mineras y las Guacamayas?'),
(4, 11, '¿Qué música suele amenizar las comidas en la Plaza Garibaldi?'),
(4, 12, '¿Qué instrumento escucharías típicamente mientras comes tamales chiapanecos?'),
(4, 13, '¿Qué sonido indica el momento de comer pozole en las Fiestas Patrias?'),
(4, 14, '¿Qué canción es típica en las cantinas mexicanas tradicionales?');

-- Arte y Entretenimiento (ID_Cat 5)
INSERT INTO `Pregunta` VALUES 
(5, 1, '¿Quién fue el famoso muralista esposo de Frida Kahlo?'),
(5, 2, '¿Qué comediante del Cine de Oro era conocido como "El Mimo de México"?'),
(5, 3, '¿Con qué apodo se le conoce al cantante Luis Miguel?'),
(5, 4, '¿Qué profesión tenía Sor Juana Inés de la Cruz, la "Décima Musa"?'),
(5, 5, '¿Qué película le dio el Óscar a Mejor Director a Guillermo del Toro en 2018?'),
(5, 6, '¿Cuál era el nombre real del comediante "Chespirito"?'),
(5, 7, '¿Qué máximo recinto cultural alberga murales de Rivera y Siqueiros?'),
(5, 8, '¿Qué maravilla arquitectónica antigua es considerada una obra de arte Maya?'),
(5, 9, '¿Qué diseño tricolor es considerado uno de los más bellos del mundo?'),
(5, 10, '¿Qué animal endémico aparece ilustrado en el aclamado billete de 50 pesos?'),
(5, 11, '¿Qué obra sinfónica de José Pablo Moncayo es considerada el segundo himno nacional?'),
(5, 12, '¿Qué pieza musical solemne es la máxima representación oficial del país?'),
(5, 13, '¿Qué canción mexicana interpretada por Pedro Infante dio la vuelta al mundo?'),
(5, 14, '¿Qué estilo musical fue popularizado por Jorge Negrete y Vicente Fernández?');

-- Deportes (ID_Cat 6)
INSERT INTO `Pregunta` VALUES 
(6, 1, '¿En qué deporte destacó Julio César Chávez?'),
(6, 2, '¿En qué equipo europeo se convirtió Hugo Sánchez en una leyenda?'),
(6, 3, '¿En qué disciplina deportiva brilló la mexicana Lorena Ochoa?'),
(6, 4, '¿En qué deporte compite Sergio "Checo" Pérez?'),
(6, 5, '¿Qué deporte practica Saúl "El Canelo" Álvarez?'),
(6, 6, '¿En qué ciudad se celebraron los Juegos Olímpicos de 1968?'),
(6, 7, '¿Qué estandarte porta la delegación nacional en la inauguración de los Juegos Olímpicos?'),
(6, 8, '¿Frente a qué palacio cruzan los maratonistas en la Ciudad de México?'),
(6, 9, '¿En qué estado de la república se corre una fecha del Campeonato Mundial de Rally (WRC)?'),
(6, 10, '¿En qué estado juegan los Leones, equipo tradicional de Béisbol?'),
(6, 11, '¿Qué ambiente sonoro se vive en la sede del Club América y la Selección Nacional?'),
(6, 12, '¿Qué cántico entona la afición mexicana en los mundiales de fútbol para apoyar?'),
(6, 13, '¿Qué protocolo sonoro se realiza antes de iniciar un partido internacional de la selección?'),
(6, 14, '¿Qué agrupación suele amenizar las ceremonias de inauguración en eventos deportivos locales?');

-- Naturaleza y Biodiversidad (ID_Cat 7)
INSERT INTO `Pregunta` VALUES 
(7, 1, '¿A qué estado llega principalmente la mariposa monarca a hibernar?'),
(7, 2, '¿Qué mamífero marino está en grave peligro de extinción en el Golfo de California?'),
(7, 3, '¿En qué región de México se encuentran los cenotes?'),
(7, 4, '¿En qué estado se localiza la Reserva de la Biosfera El Pinacate y Gran Desierto de Altar?'),
(7, 5, '¿En qué estado se encuentra el Cañón del Sumidero?'),
(7, 6, '¿Cuál es el ave nacional que aparece devorando una serpiente en el escudo?'),
(7, 7, '¿Qué anfibio, capaz de regenerar sus partes, es endémico del sistema lacustre de la CDMX?'),
(7, 8, '¿Qué península es famosa por su vasta red de ríos subterráneos y selvas bajas?'),
(7, 9, '¿Qué estado de la región del bajío cuenta con la Sierra de Lobos?'),
(7, 10, '¿Qué ruinas arqueológicas se encuentran rodeadas de la espesa selva maya?'),
(7, 11, '¿Qué ambiente auditivo encontrarías en la Reserva de la Biosfera Montes Azules?'),
(7, 12, '¿Qué instrumento tradicional está hecho con madera de hormiguillo, un árbol tropical mexicano?'),
(7, 13, '¿Qué sonido rompe el silencio nocturno en los pueblos durante una lluvia de septiembre?'),
(7, 14, '¿Qué ambiente ruidoso humano contrasta radicalmente con la tranquilidad de una reserva natural?');


-- INCISOS (Respuestas a las Preguntas)

-- Incisos Historia (ID_Cat 1)
INSERT INTO `Inciso` VALUES (1, 1, 1, '1810', TRUE, 'texto'), (1, 1, 2, '1821', FALSE, 'texto'), (1, 1, 3, '1910', FALSE, 'texto'), (1, 1, 4, '1521', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (1, 2, 1, 'Benito Juárez', FALSE, 'texto'), (1, 2, 2, 'Miguel Hidalgo', TRUE, 'texto'), (1, 2, 3, 'Pancho Villa', FALSE, 'texto'), (1, 2, 4, 'Emiliano Zapata', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (1, 3, 1, 'Maya', FALSE, 'texto'), (1, 3, 2, 'Zapoteca', FALSE, 'texto'), (1, 3, 3, 'Mexica (Azteca)', TRUE, 'texto'), (1, 3, 4, 'Olmeca', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (1, 4, 1, 'Guadalupe Victoria', TRUE, 'texto'), (1, 4, 2, 'Vicente Guerrero', FALSE, 'texto'), (1, 4, 3, 'Porfirio Díaz', FALSE, 'texto'), (1, 4, 4, 'Antonio López de Santa Anna', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (1, 5, 1, 'Guerra Cristera', FALSE, 'texto'), (1, 5, 2, 'Guerra de Reforma', FALSE, 'texto'), (1, 5, 3, 'Revolución Mexicana', TRUE, 'texto'), (1, 5, 4, 'Intervención Francesa', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (1, 6, 1, 'Tratado de Tordesillas', FALSE, 'texto'), (1, 6, 2, 'Tratado de Guadalupe Hidalgo', TRUE, 'texto'), (1, 6, 3, 'Tratados de Córdoba', FALSE, 'texto'), (1, 6, 4, 'Plan de Ayala', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (1, 7, 1, 'Multimedia/Imagenes/bellas_artes.jpg', TRUE, 'imagen'), (1, 7, 2, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (1, 7, 3, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (1, 7, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (1, 8, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (1, 8, 2, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (1, 8, 3, 'Multimedia/Imagenes/chichen_itza.jpg', TRUE, 'imagen'), (1, 8, 4, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (1, 9, 1, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (1, 9, 2, 'Multimedia/Imagenes/mapa_guanajuato.jpg', TRUE, 'imagen'), (1, 9, 3, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (1, 9, 4, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (1, 10, 1, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (1, 10, 2, 'Multimedia/Imagenes/bandera_mexico.jpg', TRUE, 'imagen'), (1, 10, 3, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (1, 10, 4, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (1, 11, 1, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (1, 11, 2, 'Multimedia/Audios/himno_nacional.mp3', TRUE, 'audio'), (1, 11, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (1, 11, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (1, 12, 1, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (1, 12, 2, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (1, 12, 3, 'Multimedia/Audios/grito_independencia.mp3', TRUE, 'audio'), (1, 12, 4, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (1, 13, 1, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (1, 13, 2, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (1, 13, 3, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (1, 13, 4, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (1, 14, 1, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (1, 14, 2, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (1, 14, 3, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (1, 14, 4, 'Multimedia/Audios/huapango_moncayo.mp3', TRUE, 'audio');

-- Incisos Geografía (ID_Cat 2)
INSERT INTO `Inciso` VALUES (2, 1, 1, 'Monterrey', FALSE, 'texto'), (2, 1, 2, 'Guadalajara', FALSE, 'texto'), (2, 1, 3, 'Ciudad de México', TRUE, 'texto'), (2, 1, 4, 'Puebla', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (2, 2, 1, 'Oaxaca', TRUE, 'texto'), (2, 2, 2, 'Veracruz', FALSE, 'texto'), (2, 2, 3, 'Jalisco', FALSE, 'texto'), (2, 2, 4, 'Estado de México', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (2, 3, 1, 'Yucatán', FALSE, 'texto'), (2, 3, 2, 'Quintana Roo', TRUE, 'texto'), (2, 3, 3, 'Campeche', FALSE, 'texto'), (2, 3, 4, 'Tabasco', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (2, 4, 1, 'Océano Atlántico', FALSE, 'texto'), (2, 4, 2, 'Mar Caribe', FALSE, 'texto'), (2, 4, 3, 'Océano Pacífico', TRUE, 'texto'), (2, 4, 4, 'Golfo de México', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (2, 5, 1, 'Popocatépetl', FALSE, 'texto'), (2, 5, 2, 'Pico de Orizaba', TRUE, 'texto'), (2, 5, 3, 'Iztaccíhuatl', FALSE, 'texto'), (2, 5, 4, 'Nevado de Toluca', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (2, 6, 1, 'Guatemala', TRUE, 'texto'), (2, 6, 2, 'Honduras', FALSE, 'texto'), (2, 6, 3, 'El Salvador', FALSE, 'texto'), (2, 6, 4, 'Nicaragua', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (2, 7, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', TRUE, 'imagen'), (2, 7, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (2, 7, 3, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (2, 7, 4, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (2, 8, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (2, 8, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', TRUE, 'imagen'), (2, 8, 3, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (2, 8, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (2, 9, 1, 'Multimedia/Imagenes/chichen_itza.jpg', TRUE, 'imagen'), (2, 9, 2, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (2, 9, 3, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen'), (2, 9, 4, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (2, 10, 1, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (2, 10, 2, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (2, 10, 3, 'Multimedia/Imagenes/bellas_artes.jpg', TRUE, 'imagen'), (2, 10, 4, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (2, 11, 1, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (2, 11, 2, 'Multimedia/Audios/marimba.mp3', TRUE, 'audio'), (2, 11, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (2, 11, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (2, 12, 1, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (2, 12, 2, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (2, 12, 3, 'Multimedia/Audios/sonido_selva.mp3', TRUE, 'audio'), (2, 12, 4, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (2, 13, 1, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (2, 13, 2, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (2, 13, 3, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (2, 13, 4, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (2, 14, 1, 'Multimedia/Audios/cielito_lindo.mp3', TRUE, 'audio'), (2, 14, 2, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (2, 14, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (2, 14, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio');

-- Incisos Cultura y Tradiciones (ID_Cat 3)
INSERT INTO `Inciso` VALUES (3, 1, 1, '1 y 2 de Noviembre', TRUE, 'texto'), (3, 1, 2, '15 y 16 de Septiembre', FALSE, 'texto'), (3, 1, 3, '5 de Mayo', FALSE, 'texto'), (3, 1, 4, '12 de Diciembre', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (3, 2, 1, 'Guerrero', FALSE, 'texto'), (3, 2, 2, 'Chiapas', FALSE, 'texto'), (3, 2, 3, 'Oaxaca', TRUE, 'texto'), (3, 2, 4, 'Veracruz', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (3, 3, 1, 'Puebla', FALSE, 'texto'), (3, 3, 2, 'Veracruz', TRUE, 'texto'), (3, 3, 3, 'Tabasco', FALSE, 'texto'), (3, 3, 4, 'Hidalgo', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (3, 4, 1, 'La Malinche', FALSE, 'texto'), (3, 4, 2, 'La Pascualita', FALSE, 'texto'), (3, 4, 3, 'La Llorona', TRUE, 'texto'), (3, 4, 4, 'La Mulata de Córdoba', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (3, 5, 1, 'Jaripeo', FALSE, 'texto'), (3, 5, 2, 'Charrería', TRUE, 'texto'), (3, 5, 3, 'Rodeo', FALSE, 'texto'), (3, 5, 4, 'Escaramuza', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (3, 6, 1, 'Alebrijes', TRUE, 'texto'), (3, 6, 2, 'Matraquitas', FALSE, 'texto'), (3, 6, 3, 'Catrinas', FALSE, 'texto'), (3, 6, 4, 'Talavera', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (3, 7, 1, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (3, 7, 2, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (3, 7, 3, 'Multimedia/Imagenes/chichen_itza.jpg', TRUE, 'imagen'), (3, 7, 4, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (3, 8, 1, 'Multimedia/Imagenes/bandera_mexico.jpg', TRUE, 'imagen'), (3, 8, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (3, 8, 3, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen'), (3, 8, 4, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (3, 9, 1, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen'), (3, 9, 2, 'Multimedia/Imagenes/tacos_pastor.jpg', TRUE, 'imagen'), (3, 9, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (3, 9, 4, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (3, 10, 1, 'Multimedia/Imagenes/ajolote.jpg', TRUE, 'imagen'), (3, 10, 2, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (3, 10, 3, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (3, 10, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (3, 11, 1, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (3, 11, 2, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (3, 11, 3, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (3, 11, 4, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (3, 12, 1, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (3, 12, 2, 'Multimedia/Audios/grito_independencia.mp3', TRUE, 'audio'), (3, 12, 3, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (3, 12, 4, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (3, 13, 1, 'Multimedia/Audios/cielito_lindo.mp3', TRUE, 'audio'), (3, 13, 2, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (3, 13, 3, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (3, 13, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (3, 14, 1, 'Multimedia/Audios/marimba.mp3', TRUE, 'audio'), (3, 14, 2, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (3, 14, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (3, 14, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio');

-- Incisos Gastronomía (ID_Cat 4)
INSERT INTO `Inciso` VALUES (4, 1, 1, 'Oaxaca', FALSE, 'texto'), (4, 1, 2, 'Puebla', TRUE, 'texto'), (4, 1, 3, 'Tlaxcala', FALSE, 'texto'), (4, 1, 4, 'Michoacán', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (4, 2, 1, 'Maguey espadín', FALSE, 'texto'), (4, 2, 2, 'Agave azul', TRUE, 'texto'), (4, 2, 3, 'Nopal', FALSE, 'texto'), (4, 2, 4, 'Henequén', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (4, 3, 1, 'Nuevo León', TRUE, 'texto'), (4, 3, 2, 'Sonora', FALSE, 'texto'), (4, 3, 3, 'Sinaloa', FALSE, 'texto'), (4, 3, 4, 'Chihuahua', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (4, 4, 1, 'Res', FALSE, 'texto'), (4, 4, 2, 'Pollo', FALSE, 'texto'), (4, 4, 3, 'Cerdo', TRUE, 'texto'), (4, 4, 4, 'Pescado', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (4, 5, 1, 'Arroz', FALSE, 'texto'), (4, 5, 2, 'Trigo', FALSE, 'texto'), (4, 5, 3, 'Maíz cacahuazintle', TRUE, 'texto'), (4, 5, 4, 'Frijol', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (4, 6, 1, 'Tepache', FALSE, 'texto'), (4, 6, 2, 'Tejuino', FALSE, 'texto'), (4, 6, 3, 'Pulque', TRUE, 'texto'), (4, 6, 4, 'Mezcal', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (4, 7, 1, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen'), (4, 7, 2, 'Multimedia/Imagenes/tacos_pastor.jpg', TRUE, 'imagen'), (4, 7, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (4, 7, 4, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (4, 8, 1, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen'), (4, 8, 2, 'Multimedia/Imagenes/chiles_nogada.jpg', TRUE, 'imagen'), (4, 8, 3, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (4, 8, 4, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (4, 9, 1, 'Multimedia/Imagenes/mapa_yucatan.jpg', TRUE, 'imagen'), (4, 9, 2, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (4, 9, 3, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (4, 9, 4, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (4, 10, 1, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (4, 10, 2, 'Multimedia/Imagenes/mapa_guanajuato.jpg', TRUE, 'imagen'), (4, 10, 3, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (4, 10, 4, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (4, 11, 1, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (4, 11, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (4, 11, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (4, 11, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (4, 12, 1, 'Multimedia/Audios/marimba.mp3', TRUE, 'audio'), (4, 12, 2, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (4, 12, 3, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio'), (4, 12, 4, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (4, 13, 1, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (4, 13, 2, 'Multimedia/Audios/grito_independencia.mp3', TRUE, 'audio'), (4, 13, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (4, 13, 4, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (4, 14, 1, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (4, 14, 2, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (4, 14, 3, 'Multimedia/Audios/cielito_lindo.mp3', TRUE, 'audio'), (4, 14, 4, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio');

-- Incisos Arte y Entretenimiento (ID_Cat 5)
INSERT INTO `Inciso` VALUES (5, 1, 1, 'David Alfaro Siqueiros', FALSE, 'texto'), (5, 1, 2, 'José Clemente Orozco', FALSE, 'texto'), (5, 1, 3, 'Diego Rivera', TRUE, 'texto'), (5, 1, 4, 'Rufino Tamayo', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (5, 2, 1, 'Tin Tan', FALSE, 'texto'), (5, 2, 2, 'Cantinflas', TRUE, 'texto'), (5, 2, 3, 'Clavillazo', FALSE, 'texto'), (5, 2, 4, 'Capulina', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (5, 3, 1, 'El Charro de Huentitán', FALSE, 'texto'), (5, 3, 2, 'El Divo de Juárez', FALSE, 'texto'), (5, 3, 3, 'El Sol de México', TRUE, 'texto'), (5, 3, 4, 'El Potrillo', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (5, 4, 1, 'Monja y escritora', TRUE, 'texto'), (5, 4, 2, 'Actriz', FALSE, 'texto'), (5, 4, 3, 'Pintora', FALSE, 'texto'), (5, 4, 4, 'Cantante de ópera', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (5, 5, 1, 'El Laberinto del Fauno', FALSE, 'texto'), (5, 5, 2, 'La Forma del Agua', TRUE, 'texto'), (5, 5, 3, 'Pinocho', FALSE, 'texto'), (5, 5, 4, 'Hellboy', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (5, 6, 1, 'Xavier López', FALSE, 'texto'), (5, 6, 2, 'Roberto Gómez Bolaños', TRUE, 'texto'), (5, 6, 3, 'Mario Moreno', FALSE, 'texto'), (5, 6, 4, 'Eugenio Derbez', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (5, 7, 1, 'Multimedia/Imagenes/bellas_artes.jpg', TRUE, 'imagen'), (5, 7, 2, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (5, 7, 3, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (5, 7, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (5, 8, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (5, 8, 2, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (5, 8, 3, 'Multimedia/Imagenes/chichen_itza.jpg', TRUE, 'imagen'), (5, 8, 4, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (5, 9, 1, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (5, 9, 2, 'Multimedia/Imagenes/bandera_mexico.jpg', TRUE, 'imagen'), (5, 9, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (5, 9, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (5, 10, 1, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (5, 10, 2, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (5, 10, 3, 'Multimedia/Imagenes/ajolote.jpg', TRUE, 'imagen'), (5, 10, 4, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (5, 11, 1, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (5, 11, 2, 'Multimedia/Audios/huapango_moncayo.mp3', TRUE, 'audio'), (5, 11, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (5, 11, 4, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (5, 12, 1, 'Multimedia/Audios/himno_nacional.mp3', TRUE, 'audio'), (5, 12, 2, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio'), (5, 12, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (5, 12, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (5, 13, 1, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (5, 13, 2, 'Multimedia/Audios/cielito_lindo.mp3', TRUE, 'audio'), (5, 13, 3, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (5, 13, 4, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (5, 14, 1, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (5, 14, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (5, 14, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (5, 14, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio');

-- Incisos Deportes (ID_Cat 6)
INSERT INTO `Inciso` VALUES (6, 1, 1, 'Fútbol', FALSE, 'texto'), (6, 1, 2, 'Boxeo', TRUE, 'texto'), (6, 1, 3, 'Béisbol', FALSE, 'texto'), (6, 1, 4, 'Lucha Libre', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (6, 2, 1, 'FC Barcelona', FALSE, 'texto'), (6, 2, 2, 'Atlético de Madrid', FALSE, 'texto'), (6, 2, 3, 'Real Madrid', TRUE, 'texto'), (6, 2, 4, 'Sevilla', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (6, 3, 1, 'Tenis', FALSE, 'texto'), (6, 3, 2, 'Clavados', FALSE, 'texto'), (6, 3, 3, 'Golf', TRUE, 'texto'), (6, 3, 4, 'Atletismo', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (6, 4, 1, 'Motociclismo', FALSE, 'texto'), (6, 4, 2, 'Rally', FALSE, 'texto'), (6, 4, 3, 'Fórmula 1', TRUE, 'texto'), (6, 4, 4, 'Nascar', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (6, 5, 1, 'Artes Marciales Mixtas', FALSE, 'texto'), (6, 5, 2, 'Boxeo', TRUE, 'texto'), (6, 5, 3, 'Lucha Olímpica', FALSE, 'texto'), (6, 5, 4, 'Taekwondo', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (6, 6, 1, 'Guadalajara', FALSE, 'texto'), (6, 6, 2, 'Monterrey', FALSE, 'texto'), (6, 6, 3, 'Ciudad de México', TRUE, 'texto'), (6, 6, 4, 'Acapulco', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (6, 7, 1, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (6, 7, 2, 'Multimedia/Imagenes/bandera_mexico.jpg', TRUE, 'imagen'), (6, 7, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (6, 7, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (6, 8, 1, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (6, 8, 2, 'Multimedia/Imagenes/bellas_artes.jpg', TRUE, 'imagen'), (6, 8, 3, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (6, 8, 4, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (6, 9, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', TRUE, 'imagen'), (6, 9, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (6, 9, 3, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (6, 9, 4, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (6, 10, 1, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (6, 10, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', TRUE, 'imagen'), (6, 10, 3, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (6, 10, 4, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (6, 11, 1, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (6, 11, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (6, 11, 3, 'Multimedia/Audios/sonido_estadio_azteca.mp3', TRUE, 'audio'), (6, 11, 4, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (6, 12, 1, 'Multimedia/Audios/cielito_lindo.mp3', TRUE, 'audio'), (6, 12, 2, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (6, 12, 3, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio'), (6, 12, 4, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (6, 13, 1, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (6, 13, 2, 'Multimedia/Audios/himno_nacional.mp3', TRUE, 'audio'), (6, 13, 3, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (6, 13, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (6, 14, 1, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (6, 14, 2, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (6, 14, 3, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio'), (6, 14, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio');

-- Incisos Naturaleza y Biodiversidad (ID_Cat 7)
INSERT INTO `Inciso` VALUES (7, 1, 1, 'Chihuahua', FALSE, 'texto'), (7, 1, 2, 'Michoacán', TRUE, 'texto'), (7, 1, 3, 'Oaxaca', FALSE, 'texto'), (7, 1, 4, 'Nayarit', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (7, 2, 1, 'Ballena Gris', FALSE, 'texto'), (7, 2, 2, 'Manatí', FALSE, 'texto'), (7, 2, 3, 'Vaquita Marina', TRUE, 'texto'), (7, 2, 4, 'Lobo Marino', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (7, 3, 1, 'Península de Baja California', FALSE, 'texto'), (7, 3, 2, 'Península de Yucatán', TRUE, 'texto'), (7, 3, 3, 'Huasteca Potosina', FALSE, 'texto'), (7, 3, 4, 'Sierra Madre Occidental', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (7, 4, 1, 'Sonora', TRUE, 'texto'), (7, 4, 2, 'Coahuila', FALSE, 'texto'), (7, 4, 3, 'Nuevo León', FALSE, 'texto'), (7, 4, 4, 'Baja California Sur', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (7, 5, 1, 'Chihuahua', FALSE, 'texto'), (7, 5, 2, 'Veracruz', FALSE, 'texto'), (7, 5, 3, 'Chiapas', TRUE, 'texto'), (7, 5, 4, 'Puebla', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (7, 6, 1, 'Halcón Peregrino', FALSE, 'texto'), (7, 6, 2, 'Quetzal', FALSE, 'texto'), (7, 6, 3, 'Águila Real', TRUE, 'texto'), (7, 6, 4, 'Cóndor de los Andes', FALSE, 'texto');
INSERT INTO `Inciso` VALUES (7, 7, 1, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (7, 7, 2, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen'), (7, 7, 3, 'Multimedia/Imagenes/ajolote.jpg', TRUE, 'imagen'), (7, 7, 4, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (7, 8, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (7, 8, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', TRUE, 'imagen'), (7, 8, 3, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (7, 8, 4, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (7, 9, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', TRUE, 'imagen'), (7, 9, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (7, 9, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (7, 9, 4, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (7, 10, 1, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (7, 10, 2, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (7, 10, 3, 'Multimedia/Imagenes/chichen_itza.jpg', TRUE, 'imagen'), (7, 10, 4, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen');
INSERT INTO `Inciso` VALUES (7, 11, 1, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (7, 11, 2, 'Multimedia/Audios/sonido_selva.mp3', TRUE, 'audio'), (7, 11, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (7, 11, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (7, 12, 1, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (7, 12, 2, 'Multimedia/Audios/marimba.mp3', TRUE, 'audio'), (7, 12, 3, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'), (7, 12, 4, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (7, 13, 1, 'Multimedia/Audios/grito_independencia.mp3', TRUE, 'audio'), (7, 13, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (7, 13, 3, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (7, 13, 4, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio');
INSERT INTO `Inciso` VALUES (7, 14, 1, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (7, 14, 2, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (7, 14, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (7, 14, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', TRUE, 'audio');

-- PARTIDAS DE EJEMPLO

INSERT INTO Partida (ID_Jugador, ID_Cat, Fecha, Hora, Puntaje) VALUES 
(1, 1, '2026-03-09', '14:00:00', 100), -- Sofia en Historia (Cat 1)
(1, 2, '2026-03-09', '14:30:00', 80),  -- Sofia en Geografía (Cat 2)
(1, 3, '2026-03-09', '15:00:00', 90),  -- Sofia en Cultura y Tradiciones (Cat 3)
(1, 4, '2026-03-09', '15:30:00', 70),  -- Sofia en Gastronomía (Cat 4)
(1, 5, '2026-03-09', '16:00:00', 95);  -- Sofia en Arte y Entretenimiento (Cat 5)

-- DETALLES DE PARTIDA DE EJEMPLO

-- Partida 1: Sofía en Historia (ID_Cat = 1) | Puntaje: 100
INSERT INTO Detalle_Partida (ID_Partida, ID_Detalle, ID_Cat, ID_Preg, Es_Acierto) VALUES 
(1, 1, 1, 1, TRUE),
(1, 2, 1, 2, TRUE),
(1, 3, 1, 3, TRUE),
(1, 4, 1, 4, TRUE),
(1, 5, 1, 5, TRUE);

-- Partida 2: Sofía en Geografía (ID_Cat = 2) | Puntaje: 80
INSERT INTO Detalle_Partida (ID_Partida, ID_Detalle, ID_Cat, ID_Preg, Es_Acierto) VALUES 
(2, 1, 2, 1, TRUE),
(2, 2, 2, 2, TRUE),
(2, 3, 2, 3, FALSE),
(2, 4, 2, 4, TRUE),
(2, 5, 2, 5, TRUE);

-- Partida 3: Sofía en Cultura y Tradiciones (ID_Cat = 3) | Puntaje: 90
INSERT INTO Detalle_Partida (ID_Partida, ID_Detalle, ID_Cat, ID_Preg, Es_Acierto) VALUES 
(3, 1, 3, 1, TRUE),
(3, 2, 3, 2, TRUE),
(3, 3, 3, 3, TRUE),
(3, 4, 3, 4, TRUE),
(3, 5, 3, 5, FALSE);

-- Partida 4: Sofía en Gastronomía (ID_Cat = 4) | Puntaje: 70
INSERT INTO Detalle_Partida (ID_Partida, ID_Detalle, ID_Cat, ID_Preg, Es_Acierto) VALUES 
(4, 1, 4, 1, TRUE),
(4, 2, 4, 2, FALSE),
(4, 3, 4, 3, TRUE),
(4, 4, 4, 4, FALSE),
(4, 5, 4, 5, TRUE);

-- Partida 5: Sofía en Arte y Entretenimiento (ID_Cat = 5) | Puntaje: 95
INSERT INTO Detalle_Partida (ID_Partida, ID_Detalle, ID_Cat, ID_Preg, Es_Acierto) VALUES 
(5, 1, 5, 1, TRUE),
(5, 2, 5, 2, TRUE),
(5, 3, 5, 3, FALSE),
(5, 4, 5, 4, TRUE),
(5, 5, 5, 5, TRUE);