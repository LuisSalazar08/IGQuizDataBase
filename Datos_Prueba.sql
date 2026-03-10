INSERT INTO Jugador (Nombre, Fecha_Registro) VALUES 
('Sofia Ruiz', '2026-03-01 09:00:00'),
('Luis Pérez', '2026-03-01 10:30:00');

INSERT INTO Categoria (Nombre, Total_Preguntas) VALUES 
('Ciencia', 5), ('Historia', 5), ('Deportes', 5), ('Cine', 5), ('Geografía', 5);

-- Ciencia (ID_Cat 1)
INSERT INTO Pregunta (ID_Cat, ID_Preg, Enunciado) VALUES 
(1, 1, 'Símbolo del Oxígeno'), (1, 2, 'Planeta Rojo'), (1, 3, 'Gas más abundante'), (1, 4, 'H2O es...'), (1, 5, 'Centro del átomo');

-- Historia (ID_Cat 2)
INSERT INTO Pregunta (ID_Cat, ID_Preg, Enunciado) VALUES 
(2, 1, '¿Año Revolución Francesa?'), (2, 2, 'Primer hombre en la Luna'), (2, 3, '¿Quién descubrió América?'), (2, 4, 'Caída Muro de Berlín'), (2, 5, 'Civilización de las Pirámides');

-- Deportes (ID_Cat 3)
INSERT INTO Pregunta (ID_Cat, ID_Preg, Enunciado) VALUES 
(3, 1, 'Mundial 2022 ganador'), (3, 2, 'Puntos por triple en basket'), (3, 3, 'Estilo de natación'), (3, 4, 'Grand Slam es de...'), (3, 5, 'Duración set voleibol');

-- Cine (ID_Cat 4)
INSERT INTO Pregunta (ID_Cat, ID_Preg, Enunciado) VALUES 
(4, 1, 'Director de Jaws'), (4, 2, 'Actor de Iron Man'), (4, 3, 'Género de Drácula'), (4, 4, 'Premio máximo del cine'), (4, 5, 'Película con Na''vi');

-- Geografía (ID_Cat 5)
INSERT INTO Pregunta (ID_Cat, ID_Preg, Enunciado) VALUES 
(5, 1, 'Capital de Italia'), (5, 2, 'Continente de Japón'), (5, 3, 'País más poblado'), (5, 4, 'Océano más grande'), (5, 5, 'Monte más alto');

INSERT INTO Inciso (ID_Cat, ID_Preg, ID_Inc, Contenido, Respuesta, Tipo_Inciso) VALUES 
-- Pregunta 1: Símbolo del Oxígeno
(1, 1, 1, 'O', TRUE, 'texto'), 
(1, 1, 2, 'H', FALSE, 'texto'), 
(1, 1, 3, 'Au', FALSE, 'texto'), 
(1, 1, 4, 'Ag', FALSE, 'texto'),

-- Pregunta 2: Planeta Rojo
(1, 2, 1, 'Marte', TRUE, 'texto'), 
(1, 2, 2, 'Venus', FALSE, 'texto'), 
(1, 2, 3, 'Júpiter', FALSE, 'texto'), 
(1, 2, 4, 'planeta_rojo.png', FALSE, 'imagen'),

-- Pregunta 3: Gas más abundante
(1, 3, 1, 'Nitrógeno', TRUE, 'texto'), 
(1, 3, 2, 'Oxígeno', FALSE, 'texto'), 
(1, 3, 3, 'Dióxido de Carbono', FALSE, 'texto'), 
(1, 3, 4, 'Helio', FALSE, 'texto'),

-- Pregunta 4: H2O es...
(1, 4, 1, 'Agua', TRUE, 'texto'), 
(1, 4, 2, 'Sal', FALSE, 'texto'), 
(1, 4, 3, 'sonido_burbujas.mp3', FALSE, 'audio'), 
(1, 4, 4, 'Aceite', FALSE, 'texto'),

-- Pregunta 5: Centro del átomo
(1, 5, 1, 'Núcleo', TRUE, 'texto'), 
(1, 5, 2, 'Electrón', FALSE, 'texto'), 
(1, 5, 3, 'Protón', FALSE, 'texto'), 
(1, 5, 4, 'Neutrón', FALSE, 'texto');

INSERT INTO Inciso (ID_Cat, ID_Preg, ID_Inc, Contenido, Respuesta, Tipo_Inciso) VALUES 
-- Pregunta 1: ¿Año Revolución Francesa?
(2, 1, 1, '1789', TRUE, 'texto'), 
(2, 1, 2, '1492', FALSE, 'texto'), 
(2, 1, 3, '1810', FALSE, 'texto'), 
(2, 1, 4, '1914', FALSE, 'texto'),

-- Pregunta 2: Primer hombre en la Luna
(2, 2, 1, 'Neil Armstrong', TRUE, 'texto'), 
(2, 2, 2, 'Yuri Gagarin', FALSE, 'texto'), 
(2, 2, 3, 'Buzz Aldrin', FALSE, 'texto'), 
(2, 2, 4, 'paso_lunar.mp3', FALSE, 'audio'),

-- Pregunta 3: ¿Quién descubrió América?
(2, 3, 1, 'Cristóbal Colón', TRUE, 'texto'), 
(2, 3, 2, 'Hernán Cortés', FALSE, 'texto'), 
(2, 3, 3, 'Américo Vespucio', FALSE, 'texto'), 
(2, 3, 4, 'Fernando de Magallanes', FALSE, 'texto'),

-- Pregunta 4: Caída Muro de Berlín
(2, 4, 1, '1989', TRUE, 'texto'), 
(2, 4, 2, 'muro_cayendo.jpg', FALSE, 'imagen'), 
(2, 4, 3, '1991', FALSE, 'texto'), 
(2, 4, 4, '1945', FALSE, 'texto'),

-- Pregunta 5: Civilización de las Pirámides
(2, 5, 1, 'Egipcia', TRUE, 'texto'), 
(2, 5, 2, 'Maya', FALSE, 'texto'), 
(2, 5, 3, 'Azteca', FALSE, 'texto'), 
(2, 5, 4, 'Inca', FALSE, 'texto');

INSERT INTO Inciso (ID_Cat, ID_Preg, ID_Inc, Contenido, Respuesta, Tipo_Inciso) VALUES 
-- Pregunta 1: Mundial 2022 ganador
(3, 1, 1, 'Argentina', TRUE, 'texto'), 
(3, 1, 2, 'Francia', FALSE, 'texto'), 
(3, 1, 3, 'Brasil', FALSE, 'texto'), 
(3, 1, 4, 'Croacia', FALSE, 'texto'),

-- Pregunta 2: Puntos por triple en basket
(3, 2, 1, '3', TRUE, 'texto'), 
(3, 2, 2, '2', FALSE, 'texto'), 
(3, 2, 3, '1', FALSE, 'texto'), 
(3, 2, 4, '4', FALSE, 'texto'),

-- Pregunta 3: Estilo de natación
(3, 3, 1, 'Mariposa', TRUE, 'texto'), 
(3, 3, 2, 'Correr', FALSE, 'texto'), 
(3, 3, 3, 'Saltar', FALSE, 'texto'), 
(3, 3, 4, 'Lanzar', FALSE, 'texto'),

-- Pregunta 4: Grand Slam es de...
(3, 4, 1, 'Tenis', TRUE, 'texto'), 
(3, 4, 2, 'Golf', FALSE, 'texto'), 
(3, 4, 3, 'raqueta.jpg', FALSE, 'imagen'), 
(3, 4, 4, 'Rugby', FALSE, 'texto'),

-- Pregunta 5: Duración set voleibol
(3, 5, 1, '25 puntos', TRUE, 'texto'), 
(3, 5, 2, '15 puntos', FALSE, 'texto'), 
(3, 5, 3, 'silbato.mp3', FALSE, 'audio'), 
(3, 5, 4, '90 minutos', FALSE, 'texto');

INSERT INTO Inciso (ID_Cat, ID_Preg, ID_Inc, Contenido, Respuesta, Tipo_Inciso) VALUES 
-- Pregunta 1: Director de Jaws
(4, 1, 1, 'Steven Spielberg', TRUE, 'texto'), 
(4, 1, 2, 'George Lucas', FALSE, 'texto'), 
(4, 1, 3, 'Quentin Tarantino', FALSE, 'texto'), 
(4, 1, 4, 'Martin Scorsese', FALSE, 'texto'),

-- Pregunta 2: Actor de Iron Man
(4, 2, 1, 'Robert Downey Jr.', TRUE, 'texto'), 
(4, 2, 2, 'Chris Evans', FALSE, 'texto'), 
(4, 2, 3, 'Chris Hemsworth', FALSE, 'texto'), 
(4, 2, 4, 'Mark Ruffalo', FALSE, 'texto'),

-- Pregunta 3: Género de Drácula
(4, 3, 1, 'Terror', TRUE, 'texto'), 
(4, 3, 2, 'Comedia', FALSE, 'texto'), 
(4, 3, 3, 'Romance', FALSE, 'texto'), 
(4, 3, 4, 'grito.wav', FALSE, 'audio'),

-- Pregunta 4: Premio máximo del cine
(4, 4, 1, 'Oscar', TRUE, 'texto'), 
(4, 4, 2, 'Grammy', FALSE, 'texto'), 
(4, 4, 3, 'Emmy', FALSE, 'texto'), 
(4, 4, 4, 'Tony', FALSE, 'texto'),

-- Pregunta 5: Película con Na'vi
(4, 5, 1, 'Avatar', TRUE, 'texto'), 
(4, 5, 2, 'poster_avatar.jpg', FALSE, 'imagen'), 
(4, 5, 3, 'Titanic', FALSE, 'texto'), 
(4, 5, 4, 'Star Wars', FALSE, 'texto');

INSERT INTO Inciso (ID_Cat, ID_Preg, ID_Inc, Contenido, Respuesta, Tipo_Inciso) VALUES 
-- Pregunta 1: Capital de Italia
(5, 1, 1, 'Roma', TRUE, 'texto'), 
(5, 1, 2, 'Milán', FALSE, 'texto'), 
(5, 1, 3, 'Florencia', FALSE, 'texto'), 
(5, 1, 4, 'coliseo.jpg', FALSE, 'imagen'),

-- Pregunta 2: Continente de Japón
(5, 2, 1, 'Asia', TRUE, 'texto'), 
(5, 2, 2, 'Europa', FALSE, 'texto'), 
(5, 2, 3, 'América', FALSE, 'texto'), 
(5, 2, 4, 'Oceanía', FALSE, 'texto'),

-- Pregunta 3: País más poblado (Actualidad)
(5, 3, 1, 'India', TRUE, 'texto'), 
(5, 3, 2, 'China', FALSE, 'texto'), 
(5, 3, 3, 'Estados Unidos', FALSE, 'texto'), 
(5, 3, 4, 'Rusia', FALSE, 'texto'),

-- Pregunta 4: Océano más grande
(5, 4, 1, 'Pacífico', TRUE, 'texto'), 
(5, 4, 2, 'Atlántico', FALSE, 'texto'), 
(5, 4, 3, 'Índico', FALSE, 'texto'), 
(5, 4, 4, 'Ártico', FALSE, 'texto'),

-- Pregunta 5: Monte más alto
(5, 5, 1, 'Everest', TRUE, 'texto'), 
(5, 5, 2, 'K2', FALSE, 'texto'), 
(5, 5, 3, 'Kilimanjaro', FALSE, 'texto'), 
(5, 5, 4, 'Aconcagua', FALSE, 'texto');

INSERT INTO Partida (ID_Jugador, ID_Cat, Fecha, Hora, Puntaje) VALUES 
(1, 1, '2026-03-09', '14:00:00', 100),
(1, 2, '2026-03-09', '14:30:00', 80),
(1, 3, '2026-03-09', '15:00:00', 90),
(1, 4, '2026-03-09', '15:30:00', 70),
(1, 5, '2026-03-09', '16:00:00', 95);

INSERT INTO Detalle_Partida (ID_Partida, ID_Detalle, ID_Cat, ID_Preg, Es_Acierto) VALUES 

-- Partida 1: Sofía en Ciencia (ID_Cat = 1) | Puntaje: 100
-- ¡Respondió todo correctamente!

(1, 1, 1, 1, TRUE),  -- Pregunta 1: Símbolo del Oxígeno
(1, 2, 1, 2, TRUE),  -- Pregunta 2: Planeta Rojo
(1, 3, 1, 3, TRUE),  -- Pregunta 3: Gas más abundante
(1, 4, 1, 4, TRUE),  -- Pregunta 4: H2O es...
(1, 5, 1, 5, TRUE),  -- Pregunta 5: Centro del átomo

-- Partida 2: Sofía en Historia (ID_Cat = 2) | Puntaje: 80
-- Se equivocó en 1 pregunta

(2, 1, 2, 1, TRUE),  -- Pregunta 1: Revolución Francesa
(2, 2, 2, 2, TRUE),  -- Pregunta 2: Hombre en la Luna
(2, 3, 2, 3, FALSE), -- Pregunta 3: Descubrimiento de América (¡Error!)
(2, 4, 2, 4, TRUE),  -- Pregunta 4: Caída Muro de Berlín
(2, 5, 2, 5, TRUE),  -- Pregunta 5: Civilización Pirámides

-- Partida 3: Sofía en Deportes (ID_Cat = 3) | Puntaje: 90
-- Se equivocó en 1 pregunta

(3, 1, 3, 1, TRUE),  -- Pregunta 1: Mundial 2022
(3, 2, 3, 2, TRUE),  -- Pregunta 2: Triple en basket
(3, 3, 3, 3, TRUE),  -- Pregunta 3: Estilo de natación
(3, 4, 3, 4, TRUE),  -- Pregunta 4: Grand Slam
(3, 5, 3, 5, FALSE), -- Pregunta 5: Duración set voleibol (¡Error!)


-- Partida 4: Sofía en Cine (ID_Cat = 4) | Puntaje: 70
-- Se equivocó en 2 preguntas

(4, 1, 4, 1, TRUE),  -- Pregunta 1: Director de Jaws
(4, 2, 4, 2, FALSE), -- Pregunta 2: Actor de Iron Man (¡Error!)
(4, 3, 4, 3, TRUE),  -- Pregunta 3: Género de Drácula
(4, 4, 4, 4, FALSE), -- Pregunta 4: Premio máximo (¡Error!)
(4, 5, 4, 5, TRUE),  -- Pregunta 5: Película Na'vi


-- Partida 5: Sofía en Geografía (ID_Cat = 5) | Puntaje: 95
-- Respondió casi perfecto

(5, 1, 5, 1, TRUE),  -- Pregunta 1: Capital de Italia
(5, 2, 5, 2, TRUE),  -- Pregunta 2: Continente de Japón
(5, 3, 5, 3, FALSE), -- Pregunta 3: País más poblado (¡Error!)
(5, 4, 5, 4, TRUE),  -- Pregunta 4: Océano más grande
(5, 5, 5, 5, TRUE);  -- Pregunta 5: Monte más alto