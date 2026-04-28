-- Limpiar tablas si vas a reinsertar
DELETE FROM Detalle_Partida;
DELETE FROM Inciso;
DELETE FROM Pregunta;

-- PREGUNTAS (14 por Categoría, reescritas para coherencia multimedia)
INSERT INTO `Pregunta` (`ID_Cat`, `ID_Preg`, `Enunciado`) VALUES 
-- 1. Historia
(1, 1, '¿En qué año inició la Independencia de México?'),
(1, 2, '¿Quién es conocido como el Padre de la Patria?'),
(1, 3, '¿Qué cultura prehispánica fundó Tenochtitlán?'),
(1, 4, '¿Cuál fue el primer presidente de México?'),
(1, 5, '¿Qué conflicto ocurrió entre 1910 y 1920?'),
(1, 6, '¿Qué tratado puso fin a la guerra entre México y EE. UU. en 1848?'),
(1, 7, '¿Qué impresionante monolito mexica representa la cosmogonía de esta cultura?'),
(1, 8, '¿Qué recinto sirvió como residencia imperial de Maximiliano y Carlota?'),
(1, 9, '¿Cuál es la edificación más grande de la antigua ciudad de Teotihuacán?'),
(1, 10, '¿Qué monumento fue inaugurado por Porfirio Díaz para el centenario de la Independencia?'),
(1, 11, '¿Qué sonido convocó al pueblo en Dolores la madrugada de 1810?'),
(1, 12, '¿Qué instrumento de viento era fundamental en las ceremonias militares prehispánicas?'),
(1, 13, '¿Qué arenga tradicional se escucha cada noche del 15 de septiembre?'),
(1, 14, '¿Qué composición solemne oficializa los actos cívicos en el país?'),

-- 2. Geografía
(2, 1, '¿Cuál es la capital de México?'),
(2, 2, '¿Qué estado de la república tiene más municipios?'),
(2, 3, '¿En qué estado se encuentra la ciudad de Cancún?'),
(2, 4, '¿Qué océano baña las costas del occidente de México?'),
(2, 5, '¿Cuál es el volcán más alto de México?'),
(2, 6, '¿Qué país hace frontera con México al sur, junto con Belice?'),
(2, 7, '¿Identifica el mapa del estado donde ocurre el Festival Cervantino.'),
(2, 8, '¿Cuál es la silueta del estado famoso por ser cuna del Tequila?'),
(2, 9, '¿Identifica el mapa de la entidad federativa conocida por la Guelaguetza.'),
(2, 10, '¿Qué impresionante formación de agua subterránea abunda en Yucatán?'),
(2, 11, '¿Qué ambiente sonoro domina la ruidosa y poblada capital del país?'),
(2, 12, '¿Qué máquina emite este sonido al cruzar las Barrancas del Cobre?'),
(2, 13, '¿Qué ecosistema hostil del norte de México suena de esta forma?'),
(2, 14, '¿Qué ambiente auditivo relajante escucharías en las costas de Quintana Roo?'),

-- 3. Cultura y Tradiciones
(3, 1, '¿En qué fechas se celebra principalmente el Día de Muertos?'),
(3, 2, '¿En qué estado se celebra la fiesta de la Guelaguetza?'),
(3, 3, '¿De qué estado son originarios los Voladores de Papantla?'),
(3, 4, '¿Qué leyenda mexicana habla de una mujer que llora por sus hijos?'),
(3, 5, '¿Cómo se le llama al deporte ecuestre tradicional de México?'),
(3, 6, '¿Qué figuras talladas en madera y pintadas de colores son típicas de Oaxaca?'),
(3, 7, '¿Qué representación tradicional ilustra de manera elegante a la muerte?'),
(3, 8, '¿Qué elemento es el centro espiritual de las festividades del 2 de noviembre?'),
(3, 9, '¿Qué danza ritual mesoamericana desafía la gravedad atados a un poste?'),
(3, 10, '¿Qué símbolo patrio muestra la victoria sobre la adversidad en un nopal?'),
(3, 11, '¿Qué melodía nostálgica inunda las calles del centro histórico de la CDMX?'),
(3, 12, '¿Qué baile alegre y zapateado es considerado el baile nacional de México?'),
(3, 13, '¿Qué ritmo alegre con arpa y jarana es originario de Veracruz?'),
(3, 14, '¿Qué instrumento de madera resuena en las fiestas patronales de Chiapas?'),

-- 4. Gastronomía
(4, 1, '¿De qué estado es originario el Mole Poblano?'),
(4, 2, '¿De qué planta se extrae el Tequila?'),
(4, 3, '¿En qué estado es tradicional comer Cabrito?'),
(4, 4, '¿Qué tipo de carne se usa tradicionalmente para la Cochinita Pibil?'),
(4, 5, '¿Cuál es el grano base para preparar un buen Pozole?'),
(4, 6, '¿Qué bebida prehispánica fermentada es conocida como "la bebida de los dioses"?'),
(4, 7, '¿Qué platillo prehispánico complejo lleva decenas de ingredientes y chocolate?'),
(4, 8, '¿Qué bebida espirituosa se obtiene del agave azul?'),
(4, 9, '¿Qué preparación de maíz se envuelve y cuece al vapor?'),
(4, 10, '¿Qué caldo tradicional lleva granos de maíz cacahuazintle?'),
(4, 11, '¿Qué pregón nocturno es un clásico para cenar en la ciudad?'),
(4, 12, '¿Qué silbido agudo anuncia la llegada de un postre callejero caliente?'),
(4, 13, '¿Qué sonido anuncia a los locatarios y compradores en un tianguis tradicional?'),
(4, 14, '¿Qué instrumento musical urbano avisa que tus cuchillos necesitan filo?'),

-- 5. Arte y Entretenimiento
(5, 1, '¿Quién fue el famoso muralista esposo de Frida Kahlo?'),
(5, 2, '¿Qué comediante del Cine de Oro era conocido como "El Mimo de México"?'),
(5, 3, '¿Con qué apodo se le conoce al cantante Luis Miguel?'),
(5, 4, '¿Qué profesión tenía Sor Juana Inés de la Cruz, la "Décima Musa"?'),
(5, 5, '¿Qué película le dio el Óscar a Mejor Director a Guillermo del Toro en 2018?'),
(5, 6, '¿Cuál era el nombre real del comediante "Chespirito"?'),
(5, 7, '¿Qué recinto cultural de mármol es el máximo exponente del arte en México?'),
(5, 8, '¿Qué obra pictórica representa el estilo inconfundible de Frida Kahlo?'),
(5, 9, '¿Qué estilo de pintura monumental plasmaba la historia nacional en los muros?'),
(5, 10, '¿Qué artesanía de cerámica vidriada es representativa de Puebla?'),
(5, 11, '¿Qué obra sinfónica nacionalista fue compuesta por José Pablo Moncayo?'),
(5, 12, '¿Qué canción tradicional es famosa por el verso "Ay, ay, ay, ay, canta y no llores"?'),
(5, 13, '¿Qué ensamble musical se asocia fuertemente con las serenatas y charros?'),
(5, 14, '¿Qué solemne vals es el himno no oficial del estado de Oaxaca?'),

-- 6. Deportes
(6, 1, '¿En qué deporte destacó Julio César Chávez?'),
(6, 2, '¿En qué equipo europeo se convirtió Hugo Sánchez en una leyenda?'),
(6, 3, '¿En qué disciplina deportiva brilló la mexicana Lorena Ochoa?'),
(6, 4, '¿En qué deporte compite Sergio "Checo" Pérez?'),
(6, 5, '¿Qué deporte practica Saúl "El Canelo" Álvarez?'),
(6, 6, '¿En qué ciudad se celebraron los Juegos Olímpicos de 1968?'),
(6, 7, '¿Qué icónico recinto deportivo fue sede de dos finales de la Copa del Mundo?'),
(6, 8, '¿Qué elemento oculta la identidad y eleva el misticismo del pancracio mexicano?'),
(6, 9, '¿Qué maravilla moderna sirvió como fondo escénico para clavadistas de altura?'),
(6, 10, '¿Qué representación tricolor flamea en las ceremonias de victoria internacionales?'),
(6, 11, '¿Qué sonido marca el inicio o final de un feroz intercambio de golpes?'),
(6, 12, '¿Qué grito eufórico inmortaliza la anotación de un equipo en la televisión?'),
(6, 13, '¿Qué icónica frase de presentación enciende el ambiente en las arenas de lucha?'),
(6, 14, '¿Qué ensamble de viento domina el ambiente en los estadios de béisbol del Pacífico?'),

-- 7. Naturaleza y Biodiversidad
(7, 1, '¿A qué estado llega principalmente la mariposa monarca a hibernar?'),
(7, 2, '¿Qué mamífero marino está en grave peligro de extinción en el Golfo de California?'),
(7, 3, '¿En qué región de México se encuentran los cenotes?'),
(7, 4, '¿En qué estado se localiza la Reserva de El Pinacate?'),
(7, 5, '¿En qué estado se encuentra el Cañón del Sumidero?'),
(7, 6, '¿Cuál es el ave nacional de México?'),
(7, 7, '¿Qué formación geológica surcada por un río es el principal atractivo de Chiapas?'),
(7, 8, '¿Qué especie de insecto viaja miles de kilómetros para hibernar en Michoacán?'),
(7, 9, '¿Qué anfibio de peculiar sonrisa es endémico de los canales de Xochimilco?'),
(7, 10, '¿Qué carnívoro nacional, antes extinto en vida libre, se reintroduce con éxito?'),
(7, 11, '¿Qué imponente felino emite este llamado en la selva maya?'),
(7, 12, '¿Qué ave, conocida como "la de las 400 voces", domina este paisaje sonoro?'),
(7, 13, '¿Qué mamífero gigante emite estos impresionantes cantos en las costas de Baja California?'),
(7, 14, '¿Qué ruido ambiental saturado contrasta drásticamente con la tranquilidad silvestre?');

-- INSERT MASIVO DE INCISOS
-- Formato: (ID_Cat, ID_Preg, ID_Inc, Contenido, Respuesta, Tipo_Inciso)
INSERT INTO `Inciso` VALUES 
-- Cat 1: Historia (Preg 1-6 Texto)
(1, 1, 1, '1810', TRUE, 'texto'), (1, 1, 2, '1821', FALSE, 'texto'), (1, 1, 3, '1910', FALSE, 'texto'), (1, 1, 4, '1521', FALSE, 'texto'),
(1, 2, 1, 'Miguel Hidalgo', TRUE, 'texto'), (1, 2, 2, 'Benito Juárez', FALSE, 'texto'), (1, 2, 3, 'Pancho Villa', FALSE, 'texto'), (1, 2, 4, 'Emiliano Zapata', FALSE, 'texto'),
(1, 3, 1, 'Mexica (Azteca)', TRUE, 'texto'), (1, 3, 2, 'Maya', FALSE, 'texto'), (1, 3, 3, 'Zapoteca', FALSE, 'texto'), (1, 3, 4, 'Olmeca', FALSE, 'texto'),
(1, 4, 1, 'Guadalupe Victoria', TRUE, 'texto'), (1, 4, 2, 'Vicente Guerrero', FALSE, 'texto'), (1, 4, 3, 'Porfirio Díaz', FALSE, 'texto'), (1, 4, 4, 'Antonio López de Santa Anna', FALSE, 'texto'),
(1, 5, 1, 'Revolución Mexicana', TRUE, 'texto'), (1, 5, 2, 'Guerra Cristera', FALSE, 'texto'), (1, 5, 3, 'Guerra de Reforma', FALSE, 'texto'), (1, 5, 4, 'Intervención Francesa', FALSE, 'texto'),
(1, 6, 1, 'Tratado de Guadalupe Hidalgo', TRUE, 'texto'), (1, 6, 2, 'Tratado de Tordesillas', FALSE, 'texto'), (1, 6, 3, 'Tratados de Córdoba', FALSE, 'texto'), (1, 6, 4, 'Plan de Ayala', FALSE, 'texto'),
-- Cat 1: Historia (Preg 7-10 Imagen)
(1, 7, 1, 'Multimedia/Imagenes/calendario_azteca.jpg', TRUE, 'imagen'), (1, 7, 2, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (1, 7, 3, 'Multimedia/Imagenes/mural_diego_rivera.jpg', FALSE, 'imagen'), (1, 7, 4, 'Multimedia/Imagenes/escudo_nacional.jpg', FALSE, 'imagen'),
(1, 8, 1, 'Multimedia/Imagenes/castillo_chapultepec.jpg', TRUE, 'imagen'), (1, 8, 2, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (1, 8, 3, 'Multimedia/Imagenes/angel_independencia.jpg', FALSE, 'imagen'), (1, 8, 4, 'Multimedia/Imagenes/estadio_azteca_foto.jpg', FALSE, 'imagen'),
(1, 9, 1, 'Multimedia/Imagenes/piramide_sol.jpg', TRUE, 'imagen'), (1, 9, 2, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (1, 9, 3, 'Multimedia/Imagenes/calendario_azteca.jpg', FALSE, 'imagen'), (1, 9, 4, 'Multimedia/Imagenes/cenote.jpg', FALSE, 'imagen'),
(1, 10, 1, 'Multimedia/Imagenes/angel_independencia.jpg', TRUE, 'imagen'), (1, 10, 2, 'Multimedia/Imagenes/castillo_chapultepec.jpg', FALSE, 'imagen'), (1, 10, 3, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (1, 10, 4, 'Multimedia/Imagenes/artesania_talavera.jpg', FALSE, 'imagen'),
-- Cat 1: Historia (Preg 11-14 Audio)
(1, 11, 1, 'Multimedia/Audios/campanas_iglesia.mp3', TRUE, 'audio'), (1, 11, 2, 'Multimedia/Audios/campana_boxeo.mp3', FALSE, 'audio'), (1, 11, 3, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio'), (1, 11, 4, 'Multimedia/Audios/musica_prehispanica.mp3', FALSE, 'audio'),
(1, 12, 1, 'Multimedia/Audios/musica_prehispanica.mp3', TRUE, 'audio'), (1, 12, 2, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (1, 12, 3, 'Multimedia/Audios/organillero.mp3', FALSE, 'audio'), (1, 12, 4, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'),
(1, 13, 1, 'Multimedia/Audios/grito_independencia.mp3', TRUE, 'audio'), (1, 13, 2, 'Multimedia/Audios/grito_lucha_libre.mp3', FALSE, 'audio'), (1, 13, 3, 'Multimedia/Audios/narracion_gol.mp3', FALSE, 'audio'), (1, 13, 4, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'),
(1, 14, 1, 'Multimedia/Audios/himno_nacional.mp3', TRUE, 'audio'), (1, 14, 2, 'Multimedia/Audios/dios_nunca_muere.mp3', FALSE, 'audio'), (1, 14, 3, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (1, 14, 4, 'Multimedia/Audios/banda_sinaloense.mp3', FALSE, 'audio'),

-- Cat 2: Geografía (Preg 1-6 Texto)
(2, 1, 1, 'Ciudad de México', TRUE, 'texto'), (2, 1, 2, 'Monterrey', FALSE, 'texto'), (2, 1, 3, 'Guadalajara', FALSE, 'texto'), (2, 1, 4, 'Puebla', FALSE, 'texto'),
(2, 2, 1, 'Oaxaca', TRUE, 'texto'), (2, 2, 2, 'Veracruz', FALSE, 'texto'), (2, 2, 3, 'Jalisco', FALSE, 'texto'), (2, 2, 4, 'Estado de México', FALSE, 'texto'),
(2, 3, 1, 'Quintana Roo', TRUE, 'texto'), (2, 3, 2, 'Yucatán', FALSE, 'texto'), (2, 3, 3, 'Campeche', FALSE, 'texto'), (2, 3, 4, 'Tabasco', FALSE, 'texto'),
(2, 4, 1, 'Océano Pacífico', TRUE, 'texto'), (2, 4, 2, 'Mar Caribe', FALSE, 'texto'), (2, 4, 3, 'Océano Atlántico', FALSE, 'texto'), (2, 4, 4, 'Golfo de México', FALSE, 'texto'),
(2, 5, 1, 'Pico de Orizaba', TRUE, 'texto'), (2, 5, 2, 'Popocatépetl', FALSE, 'texto'), (2, 5, 3, 'Iztaccíhuatl', FALSE, 'texto'), (2, 5, 4, 'Nevado de Toluca', FALSE, 'texto'),
(2, 6, 1, 'Guatemala', TRUE, 'texto'), (2, 6, 2, 'Honduras', FALSE, 'texto'), (2, 6, 3, 'El Salvador', FALSE, 'texto'), (2, 6, 4, 'Nicaragua', FALSE, 'texto'),
-- Cat 2: Geografía (Preg 7-10 Imagen)
(2, 7, 1, 'Multimedia/Imagenes/mapa_guanajuato.jpg', TRUE, 'imagen'), (2, 7, 2, 'Multimedia/Imagenes/mapa_jalisco.jpg', FALSE, 'imagen'), (2, 7, 3, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (2, 7, 4, 'Multimedia/Imagenes/mapa_oaxaca.jpg', FALSE, 'imagen'),
(2, 8, 1, 'Multimedia/Imagenes/mapa_jalisco.jpg', TRUE, 'imagen'), (2, 8, 2, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'), (2, 8, 3, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (2, 8, 4, 'Multimedia/Imagenes/mapa_oaxaca.jpg', FALSE, 'imagen'),
(2, 9, 1, 'Multimedia/Imagenes/mapa_oaxaca.jpg', TRUE, 'imagen'), (2, 9, 2, 'Multimedia/Imagenes/mapa_jalisco.jpg', FALSE, 'imagen'), (2, 9, 3, 'Multimedia/Imagenes/mapa_guanajuato.jpg', FALSE, 'imagen'), (2, 9, 4, 'Multimedia/Imagenes/mapa_yucatan.jpg', FALSE, 'imagen'),
(2, 10, 1, 'Multimedia/Imagenes/cenote.jpg', TRUE, 'imagen'), (2, 10, 2, 'Multimedia/Imagenes/canon_sumidero.jpg', FALSE, 'imagen'), (2, 10, 3, 'Multimedia/Imagenes/piramide_sol.jpg', FALSE, 'imagen'), (2, 10, 4, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'),
-- Cat 2: Geografía (Preg 11-14 Audio)
(2, 11, 1, 'Multimedia/Audios/trafico_cdmx.mp3', TRUE, 'audio'), (2, 11, 2, 'Multimedia/Audios/ruido_mercado.mp3', FALSE, 'audio'), (2, 11, 3, 'Multimedia/Audios/sonido_tren_chepe.mp3', FALSE, 'audio'), (2, 11, 4, 'Multimedia/Audios/viento_desierto.mp3', FALSE, 'audio'),
(2, 12, 1, 'Multimedia/Audios/sonido_tren_chepe.mp3', TRUE, 'audio'), (2, 12, 2, 'Multimedia/Audios/camotero_silbato.mp3', FALSE, 'audio'), (2, 12, 3, 'Multimedia/Audios/afilador_flauta.mp3', FALSE, 'audio'), (2, 12, 4, 'Multimedia/Audios/campanas_iglesia.mp3', FALSE, 'audio'),
(2, 13, 1, 'Multimedia/Audios/viento_desierto.mp3', TRUE, 'audio'), (2, 13, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (2, 13, 3, 'Multimedia/Audios/sonido_olas_cancun.mp3', FALSE, 'audio'), (2, 13, 4, 'Multimedia/Audios/canto_ballena.mp3', FALSE, 'audio'),
(2, 14, 1, 'Multimedia/Audios/sonido_olas_cancun.mp3', TRUE, 'audio'), (2, 14, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (2, 14, 3, 'Multimedia/Audios/viento_desierto.mp3', FALSE, 'audio'), (2, 14, 4, 'Multimedia/Audios/canto_ballena.mp3', FALSE, 'audio'),

-- Cat 3: Cultura (Preg 1-6 Texto)
(3, 1, 1, '1 y 2 de Noviembre', TRUE, 'texto'), (3, 1, 2, '15 y 16 de Septiembre', FALSE, 'texto'), (3, 1, 3, '5 de Mayo', FALSE, 'texto'), (3, 1, 4, '12 de Diciembre', FALSE, 'texto'),
(3, 2, 1, 'Oaxaca', TRUE, 'texto'), (3, 2, 2, 'Chiapas', FALSE, 'texto'), (3, 2, 3, 'Guerrero', FALSE, 'texto'), (3, 2, 4, 'Veracruz', FALSE, 'texto'),
(3, 3, 1, 'Veracruz', TRUE, 'texto'), (3, 3, 2, 'Puebla', FALSE, 'texto'), (3, 3, 3, 'Tabasco', FALSE, 'texto'), (3, 3, 4, 'Hidalgo', FALSE, 'texto'),
(3, 4, 1, 'La Llorona', TRUE, 'texto'), (3, 4, 2, 'La Malinche', FALSE, 'texto'), (3, 4, 3, 'La Pascualita', FALSE, 'texto'), (3, 4, 4, 'La Mulata de Córdoba', FALSE, 'texto'),
(3, 5, 1, 'Charrería', TRUE, 'texto'), (3, 5, 2, 'Jaripeo', FALSE, 'texto'), (3, 5, 3, 'Rodeo', FALSE, 'texto'), (3, 5, 4, 'Escaramuza', FALSE, 'texto'),
(3, 6, 1, 'Alebrijes', TRUE, 'texto'), (3, 6, 2, 'Matraquitas', FALSE, 'texto'), (3, 6, 3, 'Catrinas', FALSE, 'texto'), (3, 6, 4, 'Talavera', FALSE, 'texto'),
-- Cat 3: Cultura (Preg 7-10 Imagen)
(3, 7, 1, 'Multimedia/Imagenes/catrina_posada.jpg', TRUE, 'imagen'), (3, 7, 2, 'Multimedia/Imagenes/dia_muertos_ofrenda.jpg', FALSE, 'imagen'), (3, 7, 3, 'Multimedia/Imagenes/lucha_libre_mascara.jpg', FALSE, 'imagen'), (3, 7, 4, 'Multimedia/Imagenes/frida_kahlo_pintura.jpg', FALSE, 'imagen'),
(3, 8, 1, 'Multimedia/Imagenes/dia_muertos_ofrenda.jpg', TRUE, 'imagen'), (3, 8, 2, 'Multimedia/Imagenes/catrina_posada.jpg', FALSE, 'imagen'), (3, 8, 3, 'Multimedia/Imagenes/tamales.jpg', FALSE, 'imagen'), (3, 8, 4, 'Multimedia/Imagenes/calendario_azteca.jpg', FALSE, 'imagen'),
(3, 9, 1, 'Multimedia/Imagenes/voladores_papantla.jpg', TRUE, 'imagen'), (3, 9, 2, 'Multimedia/Imagenes/angel_independencia.jpg', FALSE, 'imagen'), (3, 9, 3, 'Multimedia/Imagenes/estadio_azteca_foto.jpg', FALSE, 'imagen'), (3, 9, 4, 'Multimedia/Imagenes/piramide_sol.jpg', FALSE, 'imagen'),
(3, 10, 1, 'Multimedia/Imagenes/escudo_nacional.jpg', TRUE, 'imagen'), (3, 10, 2, 'Multimedia/Imagenes/bandera_mexico.jpg', FALSE, 'imagen'), (3, 10, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (3, 10, 4, 'Multimedia/Imagenes/calendario_azteca.jpg', FALSE, 'imagen'),
-- Cat 3: Cultura (Preg 11-14 Audio)
(3, 11, 1, 'Multimedia/Audios/organillero.mp3', TRUE, 'audio'), (3, 11, 2, 'Multimedia/Audios/camotero_silbato.mp3', FALSE, 'audio'), (3, 11, 3, 'Multimedia/Audios/afilador_flauta.mp3', FALSE, 'audio'), (3, 11, 4, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'),
(3, 12, 1, 'Multimedia/Audios/jarabe_tapatio.mp3', TRUE, 'audio'), (3, 12, 2, 'Multimedia/Audios/la_bamba.mp3', FALSE, 'audio'), (3, 12, 3, 'Multimedia/Audios/dios_nunca_muere.mp3', FALSE, 'audio'), (3, 12, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'),
(3, 13, 1, 'Multimedia/Audios/la_bamba.mp3', TRUE, 'audio'), (3, 13, 2, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (3, 13, 3, 'Multimedia/Audios/jarabe_tapatio.mp3', FALSE, 'audio'), (3, 13, 4, 'Multimedia/Audios/banda_sinaloense.mp3', FALSE, 'audio'),
(3, 14, 1, 'Multimedia/Audios/marimba.mp3', TRUE, 'audio'), (3, 14, 2, 'Multimedia/Audios/musica_prehispanica.mp3', FALSE, 'audio'), (3, 14, 3, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (3, 14, 4, 'Multimedia/Audios/organillero.mp3', FALSE, 'audio'),

-- Cat 4: Gastronomía (Preg 1-6 Texto)
(4, 1, 1, 'Puebla', TRUE, 'texto'), (4, 1, 2, 'Oaxaca', FALSE, 'texto'), (4, 1, 3, 'Tlaxcala', FALSE, 'texto'), (4, 1, 4, 'Michoacán', FALSE, 'texto'),
(4, 2, 1, 'Agave azul', TRUE, 'texto'), (4, 2, 2, 'Maguey espadín', FALSE, 'texto'), (4, 2, 3, 'Nopal', FALSE, 'texto'), (4, 2, 4, 'Henequén', FALSE, 'texto'),
(4, 3, 1, 'Nuevo León', TRUE, 'texto'), (4, 3, 2, 'Sonora', FALSE, 'texto'), (4, 3, 3, 'Sinaloa', FALSE, 'texto'), (4, 3, 4, 'Chihuahua', FALSE, 'texto'),
(4, 4, 1, 'Cerdo', TRUE, 'texto'), (4, 4, 2, 'Res', FALSE, 'texto'), (4, 4, 3, 'Pollo', FALSE, 'texto'), (4, 4, 4, 'Pescado', FALSE, 'texto'),
(4, 5, 1, 'Maíz cacahuazintle', TRUE, 'texto'), (4, 5, 2, 'Arroz', FALSE, 'texto'), (4, 5, 3, 'Trigo', FALSE, 'texto'), (4, 5, 4, 'Frijol', FALSE, 'texto'),
(4, 6, 1, 'Pulque', TRUE, 'texto'), (4, 6, 2, 'Tepache', FALSE, 'texto'), (4, 6, 3, 'Tejuino', FALSE, 'texto'), (4, 6, 4, 'Mezcal', FALSE, 'texto'),
-- Cat 4: Gastronomía (Preg 7-10 Imagen)
(4, 7, 1, 'Multimedia/Imagenes/mole_poblano.jpg', TRUE, 'imagen'), (4, 7, 2, 'Multimedia/Imagenes/pozole.jpg', FALSE, 'imagen'), (4, 7, 3, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen'), (4, 7, 4, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen'),
(4, 8, 1, 'Multimedia/Imagenes/tequila_agave.jpg', TRUE, 'imagen'), (4, 8, 2, 'Multimedia/Imagenes/pozole.jpg', FALSE, 'imagen'), (4, 8, 3, 'Multimedia/Imagenes/mole_poblano.jpg', FALSE, 'imagen'), (4, 8, 4, 'Multimedia/Imagenes/tamales.jpg', FALSE, 'imagen'),
(4, 9, 1, 'Multimedia/Imagenes/tamales.jpg', TRUE, 'imagen'), (4, 9, 2, 'Multimedia/Imagenes/tacos_pastor.jpg', FALSE, 'imagen'), (4, 9, 3, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen'), (4, 9, 4, 'Multimedia/Imagenes/pozole.jpg', FALSE, 'imagen'),
(4, 10, 1, 'Multimedia/Imagenes/pozole.jpg', TRUE, 'imagen'), (4, 10, 2, 'Multimedia/Imagenes/mole_poblano.jpg', FALSE, 'imagen'), (4, 10, 3, 'Multimedia/Imagenes/tamales.jpg', FALSE, 'imagen'), (4, 10, 4, 'Multimedia/Imagenes/chiles_nogada.jpg', FALSE, 'imagen'),
-- Cat 4: Gastronomía (Preg 11-14 Audio)
(4, 11, 1, 'Multimedia/Audios/pregon_tamales.mp3', TRUE, 'audio'), (4, 11, 2, 'Multimedia/Audios/camotero_silbato.mp3', FALSE, 'audio'), (4, 11, 3, 'Multimedia/Audios/afilador_flauta.mp3', FALSE, 'audio'), (4, 11, 4, 'Multimedia/Audios/organillero.mp3', FALSE, 'audio'),
(4, 12, 1, 'Multimedia/Audios/camotero_silbato.mp3', TRUE, 'audio'), (4, 12, 2, 'Multimedia/Audios/pregon_tamales.mp3', FALSE, 'audio'), (4, 12, 3, 'Multimedia/Audios/afilador_flauta.mp3', FALSE, 'audio'), (4, 12, 4, 'Multimedia/Audios/sonido_tren_chepe.mp3', FALSE, 'audio'),
(4, 13, 1, 'Multimedia/Audios/ruido_mercado.mp3', TRUE, 'audio'), (4, 13, 2, 'Multimedia/Audios/trafico_cdmx.mp3', FALSE, 'audio'), (4, 13, 3, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (4, 13, 4, 'Multimedia/Audios/grito_lucha_libre.mp3', FALSE, 'audio'),
(4, 14, 1, 'Multimedia/Audios/afilador_flauta.mp3', TRUE, 'audio'), (4, 14, 2, 'Multimedia/Audios/organillero.mp3', FALSE, 'audio'), (4, 14, 3, 'Multimedia/Audios/camotero_silbato.mp3', FALSE, 'audio'), (4, 14, 4, 'Multimedia/Audios/pregon_tamales.mp3', FALSE, 'audio'),

-- Cat 5: Arte y Entretenimiento (Preg 1-6 Texto)
(5, 1, 1, 'Diego Rivera', TRUE, 'texto'), (5, 1, 2, 'David Alfaro Siqueiros', FALSE, 'texto'), (5, 1, 3, 'José Clemente Orozco', FALSE, 'texto'), (5, 1, 4, 'Rufino Tamayo', FALSE, 'texto'),
(5, 2, 1, 'Cantinflas', TRUE, 'texto'), (5, 2, 2, 'Tin Tan', FALSE, 'texto'), (5, 2, 3, 'Clavillazo', FALSE, 'texto'), (5, 2, 4, 'Capulina', FALSE, 'texto'),
(5, 3, 1, 'El Sol de México', TRUE, 'texto'), (5, 3, 2, 'El Charro de Huentitán', FALSE, 'texto'), (5, 3, 3, 'El Divo de Juárez', FALSE, 'texto'), (5, 3, 4, 'El Potrillo', FALSE, 'texto'),
(5, 4, 1, 'Monja y escritora', TRUE, 'texto'), (5, 4, 2, 'Actriz', FALSE, 'texto'), (5, 4, 3, 'Pintora', FALSE, 'texto'), (5, 4, 4, 'Cantante de ópera', FALSE, 'texto'),
(5, 5, 1, 'La Forma del Agua', TRUE, 'texto'), (5, 5, 2, 'El Laberinto del Fauno', FALSE, 'texto'), (5, 5, 3, 'Pinocho', FALSE, 'texto'), (5, 5, 4, 'Hellboy', FALSE, 'texto'),
(5, 6, 1, 'Roberto Gómez Bolaños', TRUE, 'texto'), (5, 6, 2, 'Xavier López', FALSE, 'texto'), (5, 6, 3, 'Mario Moreno', FALSE, 'texto'), (5, 6, 4, 'Eugenio Derbez', FALSE, 'texto'),
-- Cat 5: Arte y Entretenimiento (Preg 7-10 Imagen)
(5, 7, 1, 'Multimedia/Imagenes/bellas_artes.jpg', TRUE, 'imagen'), (5, 7, 2, 'Multimedia/Imagenes/castillo_chapultepec.jpg', FALSE, 'imagen'), (5, 7, 3, 'Multimedia/Imagenes/chichen_itza.jpg', FALSE, 'imagen'), (5, 7, 4, 'Multimedia/Imagenes/mural_diego_rivera.jpg', FALSE, 'imagen'),
(5, 8, 1, 'Multimedia/Imagenes/frida_kahlo_pintura.jpg', TRUE, 'imagen'), (5, 8, 2, 'Multimedia/Imagenes/mural_diego_rivera.jpg', FALSE, 'imagen'), (5, 8, 3, 'Multimedia/Imagenes/catrina_posada.jpg', FALSE, 'imagen'), (5, 8, 4, 'Multimedia/Imagenes/artesania_talavera.jpg', FALSE, 'imagen'),
(5, 9, 1, 'Multimedia/Imagenes/mural_diego_rivera.jpg', TRUE, 'imagen'), (5, 9, 2, 'Multimedia/Imagenes/frida_kahlo_pintura.jpg', FALSE, 'imagen'), (5, 9, 3, 'Multimedia/Imagenes/calendario_azteca.jpg', FALSE, 'imagen'), (5, 9, 4, 'Multimedia/Imagenes/artesania_talavera.jpg', FALSE, 'imagen'),
(5, 10, 1, 'Multimedia/Imagenes/artesania_talavera.jpg', TRUE, 'imagen'), (5, 10, 2, 'Multimedia/Imagenes/lucha_libre_mascara.jpg', FALSE, 'imagen'), (5, 10, 3, 'Multimedia/Imagenes/catrina_posada.jpg', FALSE, 'imagen'), (5, 10, 4, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'),
-- Cat 5: Arte y Entretenimiento (Preg 11-14 Audio)
(5, 11, 1, 'Multimedia/Audios/huapango_moncayo.mp3', TRUE, 'audio'), (5, 11, 2, 'Multimedia/Audios/dios_nunca_muere.mp3', FALSE, 'audio'), (5, 11, 3, 'Multimedia/Audios/himno_nacional.mp3', FALSE, 'audio'), (5, 11, 4, 'Multimedia/Audios/jarabe_tapatio.mp3', FALSE, 'audio'),
(5, 12, 1, 'Multimedia/Audios/cielito_lindo.mp3', TRUE, 'audio'), (5, 12, 2, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (5, 12, 3, 'Multimedia/Audios/la_bamba.mp3', FALSE, 'audio'), (5, 12, 4, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'),
(5, 13, 1, 'Multimedia/Audios/mariachi.mp3', TRUE, 'audio'), (5, 13, 2, 'Multimedia/Audios/banda_sinaloense.mp3', FALSE, 'audio'), (5, 13, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (5, 13, 4, 'Multimedia/Audios/organillero.mp3', FALSE, 'audio'),
(5, 14, 1, 'Multimedia/Audios/dios_nunca_muere.mp3', TRUE, 'audio'), (5, 14, 2, 'Multimedia/Audios/huapango_moncayo.mp3', FALSE, 'audio'), (5, 14, 3, 'Multimedia/Audios/la_bamba.mp3', FALSE, 'audio'), (5, 14, 4, 'Multimedia/Audios/cielito_lindo.mp3', FALSE, 'audio'),

-- Cat 6: Deportes (Preg 1-6 Texto)
(6, 1, 1, 'Boxeo', TRUE, 'texto'), (6, 1, 2, 'Fútbol', FALSE, 'texto'), (6, 1, 3, 'Béisbol', FALSE, 'texto'), (6, 1, 4, 'Lucha Libre', FALSE, 'texto'),
(6, 2, 1, 'Real Madrid', TRUE, 'texto'), (6, 2, 2, 'FC Barcelona', FALSE, 'texto'), (6, 2, 3, 'Atlético de Madrid', FALSE, 'texto'), (6, 2, 4, 'Sevilla', FALSE, 'texto'),
(6, 3, 1, 'Golf', TRUE, 'texto'), (6, 3, 2, 'Tenis', FALSE, 'texto'), (6, 3, 3, 'Clavados', FALSE, 'texto'), (6, 3, 4, 'Atletismo', FALSE, 'texto'),
(6, 4, 1, 'Fórmula 1', TRUE, 'texto'), (6, 4, 2, 'Motociclismo', FALSE, 'texto'), (6, 4, 3, 'Rally', FALSE, 'texto'), (6, 4, 4, 'Nascar', FALSE, 'texto'),
(6, 5, 1, 'Boxeo', TRUE, 'texto'), (6, 5, 2, 'Artes Marciales Mixtas', FALSE, 'texto'), (6, 5, 3, 'Lucha Olímpica', FALSE, 'texto'), (6, 5, 4, 'Taekwondo', FALSE, 'texto'),
(6, 6, 1, 'Ciudad de México', TRUE, 'texto'), (6, 6, 2, 'Guadalajara', FALSE, 'texto'), (6, 6, 3, 'Monterrey', FALSE, 'texto'), (6, 6, 4, 'Acapulco', FALSE, 'texto'),
-- Cat 6: Deportes (Preg 7-10 Imagen)
(6, 7, 1, 'Multimedia/Imagenes/estadio_azteca_foto.jpg', TRUE, 'imagen'), (6, 7, 2, 'Multimedia/Imagenes/bellas_artes.jpg', FALSE, 'imagen'), (6, 7, 3, 'Multimedia/Imagenes/castillo_chapultepec.jpg', FALSE, 'imagen'), (6, 7, 4, 'Multimedia/Imagenes/piramide_sol.jpg', FALSE, 'imagen'),
(6, 8, 1, 'Multimedia/Imagenes/lucha_libre_mascara.jpg', TRUE, 'imagen'), (6, 8, 2, 'Multimedia/Imagenes/catrina_posada.jpg', FALSE, 'imagen'), (6, 8, 3, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (6, 8, 4, 'Multimedia/Imagenes/escudo_nacional.jpg', FALSE, 'imagen'),
(6, 9, 1, 'Multimedia/Imagenes/chichen_itza.jpg', TRUE, 'imagen'), (6, 9, 2, 'Multimedia/Imagenes/canon_sumidero.jpg', FALSE, 'imagen'), (6, 9, 3, 'Multimedia/Imagenes/cenote.jpg', FALSE, 'imagen'), (6, 9, 4, 'Multimedia/Imagenes/estadio_azteca_foto.jpg', FALSE, 'imagen'),
(6, 10, 1, 'Multimedia/Imagenes/bandera_mexico.jpg', TRUE, 'imagen'), (6, 10, 2, 'Multimedia/Imagenes/escudo_nacional.jpg', FALSE, 'imagen'), (6, 10, 3, 'Multimedia/Imagenes/calendario_azteca.jpg', FALSE, 'imagen'), (6, 10, 4, 'Multimedia/Imagenes/artesania_talavera.jpg', FALSE, 'imagen'),
-- Cat 6: Deportes (Preg 11-14 Audio)
(6, 11, 1, 'Multimedia/Audios/campana_boxeo.mp3', TRUE, 'audio'), (6, 11, 2, 'Multimedia/Audios/grito_lucha_libre.mp3', FALSE, 'audio'), (6, 11, 3, 'Multimedia/Audios/narracion_gol.mp3', FALSE, 'audio'), (6, 11, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'),
(6, 12, 1, 'Multimedia/Audios/narracion_gol.mp3', TRUE, 'audio'), (6, 12, 2, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'), (6, 12, 3, 'Multimedia/Audios/grito_lucha_libre.mp3', FALSE, 'audio'), (6, 12, 4, 'Multimedia/Audios/grito_independencia.mp3', FALSE, 'audio'),
(6, 13, 1, 'Multimedia/Audios/grito_lucha_libre.mp3', TRUE, 'audio'), (6, 13, 2, 'Multimedia/Audios/campana_boxeo.mp3', FALSE, 'audio'), (6, 13, 3, 'Multimedia/Audios/narracion_gol.mp3', FALSE, 'audio'), (6, 13, 4, 'Multimedia/Audios/sonido_estadio_azteca.mp3', FALSE, 'audio'),
(6, 14, 1, 'Multimedia/Audios/banda_sinaloense.mp3', TRUE, 'audio'), (6, 14, 2, 'Multimedia/Audios/mariachi.mp3', FALSE, 'audio'), (6, 14, 3, 'Multimedia/Audios/marimba.mp3', FALSE, 'audio'), (6, 14, 4, 'Multimedia/Audios/organillero.mp3', FALSE, 'audio'),

-- Cat 7: Naturaleza y Biodiversidad (Preg 1-6 Texto)
(7, 1, 1, 'Michoacán', TRUE, 'texto'), (7, 1, 2, 'Chihuahua', FALSE, 'texto'), (7, 1, 3, 'Oaxaca', FALSE, 'texto'), (7, 1, 4, 'Nayarit', FALSE, 'texto'),
(7, 2, 1, 'Vaquita Marina', TRUE, 'texto'), (7, 2, 2, 'Ballena Gris', FALSE, 'texto'), (7, 2, 3, 'Manatí', FALSE, 'texto'), (7, 2, 4, 'Lobo Marino', FALSE, 'texto'),
(7, 3, 1, 'Península de Yucatán', TRUE, 'texto'), (7, 3, 2, 'Península de Baja California', FALSE, 'texto'), (7, 3, 3, 'Huasteca Potosina', FALSE, 'texto'), (7, 3, 4, 'Sierra Madre Occidental', FALSE, 'texto'),
(7, 4, 1, 'Sonora', TRUE, 'texto'), (7, 4, 2, 'Coahuila', FALSE, 'texto'), (7, 4, 3, 'Nuevo León', FALSE, 'texto'), (7, 4, 4, 'Baja California Sur', FALSE, 'texto'),
(7, 5, 1, 'Chiapas', TRUE, 'texto'), (7, 5, 2, 'Chihuahua', FALSE, 'texto'), (7, 5, 3, 'Veracruz', FALSE, 'texto'), (7, 5, 4, 'Puebla', FALSE, 'texto'),
(7, 6, 1, 'Águila Real', TRUE, 'texto'), (7, 6, 2, 'Halcón Peregrino', FALSE, 'texto'), (7, 6, 3, 'Quetzal', FALSE, 'texto'), (7, 6, 4, 'Cóndor de los Andes', FALSE, 'texto'),
-- Cat 7: Naturaleza y Biodiversidad (Preg 7-10 Imagen)
(7, 7, 1, 'Multimedia/Imagenes/canon_sumidero.jpg', TRUE, 'imagen'), (7, 7, 2, 'Multimedia/Imagenes/cenote.jpg', FALSE, 'imagen'), (7, 7, 3, 'Multimedia/Imagenes/piramide_sol.jpg', FALSE, 'imagen'), (7, 7, 4, 'Multimedia/Imagenes/mapa_jalisco.jpg', FALSE, 'imagen'),
(7, 8, 1, 'Multimedia/Imagenes/mariposa_monarca.jpg', TRUE, 'imagen'), (7, 8, 2, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (7, 8, 3, 'Multimedia/Imagenes/voladores_papantla.jpg', FALSE, 'imagen'), (7, 8, 4, 'Multimedia/Imagenes/escudo_nacional.jpg', FALSE, 'imagen'),
(7, 9, 1, 'Multimedia/Imagenes/ajolote.jpg', TRUE, 'imagen'), (7, 9, 2, 'Multimedia/Imagenes/mariposa_monarca.jpg', FALSE, 'imagen'), (7, 9, 3, 'Multimedia/Imagenes/catrina_posada.jpg', FALSE, 'imagen'), (7, 9, 4, 'Multimedia/Imagenes/escudo_nacional.jpg', FALSE, 'imagen'),
(7, 10, 1, 'Multimedia/Imagenes/lobo_mexicano.jpg', TRUE, 'imagen'), (7, 10, 2, 'Multimedia/Imagenes/ajolote.jpg', FALSE, 'imagen'), (7, 10, 3, 'Multimedia/Imagenes/escudo_nacional.jpg', FALSE, 'imagen'), (7, 10, 4, 'Multimedia/Imagenes/mariposa_monarca.jpg', FALSE, 'imagen'),
-- Cat 7: Naturaleza y Biodiversidad (Preg 11-14 Audio)
(7, 11, 1, 'Multimedia/Audios/rugido_jaguar.mp3', TRUE, 'audio'), (7, 11, 2, 'Multimedia/Audios/aullido_coyote.mp3', FALSE, 'audio'), (7, 11, 3, 'Multimedia/Audios/canto_ballena.mp3', FALSE, 'audio'), (7, 11, 4, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'),
(7, 12, 1, 'Multimedia/Audios/canto_cenzontle.mp3', TRUE, 'audio'), (7, 12, 2, 'Multimedia/Audios/sonido_selva.mp3', FALSE, 'audio'), (7, 12, 3, 'Multimedia/Audios/rugido_jaguar.mp3', FALSE, 'audio'), (7, 12, 4, 'Multimedia/Audios/aullido_coyote.mp3', FALSE, 'audio'),
(7, 13, 1, 'Multimedia/Audios/canto_ballena.mp3', TRUE, 'audio'), (7, 13, 2, 'Multimedia/Audios/sonido_olas_cancun.mp3', FALSE, 'audio'), (7, 13, 3, 'Multimedia/Audios/rugido_jaguar.mp3', FALSE, 'audio'), (7, 13, 4, 'Multimedia/Audios/viento_desierto.mp3', FALSE, 'audio'),
(7, 14, 1, 'Multimedia/Audios/trafico_cdmx.mp3', TRUE, 'audio'), (7, 14, 2, 'Multimedia/Audios/ruido_mercado.mp3', FALSE, 'audio'), (7, 14, 3, 'Multimedia/Audios/sonido_tren_chepe.mp3', FALSE, 'audio'), (7, 14, 4, 'Multimedia/Audios/viento_desierto.mp3', FALSE, 'audio');