CREATE TABLE `Jugador` (
  `ID_Jugador` int PRIMARY KEY AUTO_INCREMENT,
  `Nombre` varchar(255),
  `Fecha_Registro` datetime
);

CREATE TABLE `Categoria` (
  `ID_Cat` int PRIMARY KEY AUTO_INCREMENT,
  `Nombre` varchar(255),
  `Total_Preguntas` int
);

CREATE TABLE `Partida` (
  `ID_Partida` int PRIMARY KEY AUTO_INCREMENT,
  `ID_Jugador` int,
  `ID_Cat` int,
  `Fecha` date,
  `Hora` time,
  `Puntaje` int
);

CREATE TABLE `Pregunta` (
  `ID_Cat` int,
  `ID_Preg` int,
  `Enunciado` varchar(255),
  PRIMARY KEY (`ID_Cat`, `ID_Preg`)
);

CREATE TABLE `Inciso` (
  `ID_Cat` int,
  `ID_Preg` int,
  `ID_Inc` int,
  `Contenido` varchar(255),
  `Respuesta` boolean,
  `Tipo_Inciso` varchar(50) DEFAULT 'texto',
  PRIMARY KEY (`ID_Cat`, `ID_Preg`, `ID_Inc`)
);

CREATE TABLE `Detalle_Partida` (
  `ID_Partida` int,
  `ID_Detalle` int,
  `ID_Cat` int,
  `ID_Preg` int,
  `Es_Acierto` boolean,
  PRIMARY KEY (`ID_Partida`, `ID_Detalle`)
);

ALTER TABLE `Partida` ADD FOREIGN KEY (`ID_Jugador`) REFERENCES `Jugador` (`ID_Jugador`);

ALTER TABLE `Partida` ADD FOREIGN KEY (`ID_Cat`) REFERENCES `Categoria` (`ID_Cat`);

ALTER TABLE `Pregunta` ADD FOREIGN KEY (`ID_Cat`) REFERENCES `Categoria` (`ID_Cat`);

ALTER TABLE `Inciso` ADD FOREIGN KEY (`ID_Cat`, `ID_Preg`) REFERENCES `Pregunta` (`ID_Cat`, `ID_Preg`);

ALTER TABLE `Detalle_Partida` ADD FOREIGN KEY (`ID_Partida`) REFERENCES `Partida` (`ID_Partida`);

ALTER TABLE `Detalle_Partida` ADD FOREIGN KEY (`ID_Cat`, `ID_Preg`) REFERENCES `Pregunta` (`ID_Cat`, `ID_Preg`);
