using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace BDGameQuiz
{
    public partial class juego : Form
    {
        List<Pregunta> preguntas = new List<Pregunta>();

        int indicePregunta = 0;
        int score = 0;

        int idCategoria;
        string nombreJugador;
        int idJugador;
        int idPartida;

        public juego(int cat, int idJugador, string nombreJugador)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.idCategoria = cat;
            this.idJugador = idJugador;
            this.nombreJugador = nombreJugador;

            CargarPreguntas();
        }

        void MezclarOpciones(Pregunta p)
        {
            Random rnd = new Random();

            var opciones = p.Opciones
                .Select((texto, index) => new { Texto = texto, EsCorrecta = index == p.Correcta })
                .OrderBy(x => rnd.Next())
                .ToList();

            for (int i = 0; i < 4; i++)
            {
                p.Opciones[i] = opciones[i].Texto;

                if (opciones[i].EsCorrecta)
                    p.Correcta = i;
            }
        }

        void CargarPreguntas()
        {
            preguntas.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
                {
                    conn.Open();

                    // Verificar cuántas preguntas hay en esta categoría
                    string countQuery = "SELECT COUNT(*) FROM pregunta WHERE ID_Cat = @cat";
                    MySqlCommand countCmd = new MySqlCommand(countQuery, conn);
                    countCmd.Parameters.AddWithValue("@cat", idCategoria);
                    int totalPreguntas = Convert.ToInt32(countCmd.ExecuteScalar());

                    Console.WriteLine($"Total de preguntas en categoría {idCategoria}: {totalPreguntas}");

                    // Obtener preguntas SOLO de la categoría seleccionada
                    string query = "SELECT * FROM pregunta WHERE ID_Cat = @cat ORDER BY RAND() LIMIT 12";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cat", idCategoria);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Pregunta p = new Pregunta();

                        p.IdPregunta = Convert.ToInt32(dr["ID_Preg"]);
                        p.Enunciado = dr["Enunciado"].ToString();
                        p.Opciones = new string[4];
                        p.Correcta = -1;

                        preguntas.Add(p);

                        Console.WriteLine($"Pregunta cargada: ID={p.IdPregunta}");
                    }

                    dr.Close();

                    // Cargar los incisos para cada pregunta
                    foreach (Pregunta p in preguntas)
                    {
                        // IMPORTANTE: Filtrar incisos por ID_Preg SOLAMENTE
                        // Los incisos ya pertenecen a esta pregunta específica
                        string queryIncisos = @"SELECT * FROM inciso WHERE ID_Preg = @preg ORDER BY ID_Inc";

                        MySqlCommand cmdInc = new MySqlCommand(queryIncisos, conn);
                        cmdInc.Parameters.AddWithValue("@preg", p.IdPregunta);

                        MySqlDataReader drInc = cmdInc.ExecuteReader();

                        int indiceOpcion = 0;
                        string tipoDetectado = "texto"; // Valor por defecto

                        while (drInc.Read() && indiceOpcion < 4)
                        {
                            // Asignar contenido
                            p.Opciones[indiceOpcion] = drInc["Contenido"].ToString();

                            // Verificar si es respuesta correcta
                            if (Convert.ToBoolean(drInc["Respuesta"]))
                                p.Correcta = indiceOpcion;

                            // Detectar el tipo del primer inciso
                            if (indiceOpcion == 0)
                            {
                                tipoDetectado = drInc["Tipo_Inciso"].ToString();
                            }

                            indiceOpcion++;
                        }

                        drInc.Close();

                        // Asignar el tipo detectado a la pregunta
                        p.Tipo = tipoDetectado;

                        // Verificar que tenemos las 4 opciones
                        for (int i = 0; i < 4; i++)
                        {
                            if (string.IsNullOrEmpty(p.Opciones[i]))
                                p.Opciones[i] = "Opción no disponible";
                        }

                        // Verificar que se encontró una respuesta correcta
                        if (p.Correcta == -1)
                        {
                            p.Correcta = 0; // Asignar primera opción por defecto
                            Console.WriteLine($"ADVERTENCIA: Pregunta {p.IdPregunta} sin respuesta correcta");
                        }

                        // Mezclar opciones SOLO si es tipo texto
                        // Para imágenes y audios no mezclamos porque podrían tener referencias específicas
                        if (p.Tipo == "texto")
                        {
                            MezclarOpciones(p);
                        }

                        Console.WriteLine($"Pregunta {p.IdPregunta} cargada con tipo: {p.Tipo}");
                    }
                }

                // Verificar que hay preguntas cargadas
                if (preguntas.Count == 0)
                {
                    MessageBox.Show($"No hay preguntas disponibles para esta categoría (ID: {idCategoria}).");
                    btnMenu_Click_1(null, null);
                    return;
                }

                Console.WriteLine($"Total de preguntas cargadas: {preguntas.Count}");

                indicePregunta = 0;
                score = 0;
                MostrarPregunta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
            }
        }

        void MostrarPregunta()
        {
            if (indicePregunta >= preguntas.Count)
            {
                TerminarJuego();
                return;
            }

            var p = preguntas[indicePregunta];

            lblPregunta.Text = p.Enunciado;

            // Limpiar botones
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";

            btn1.Image = null;
            btn2.Image = null;
            btn3.Image = null;
            btn4.Image = null;

            // Habilitar todos los botones por defecto
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;

            // Mostrar opciones según el tipo
            if (p.Tipo == "texto")
            {
                // Para texto, mostramos el texto normalmente
                btn1.Text = p.Opciones[0];
                btn2.Text = p.Opciones[1];
                btn3.Text = p.Opciones[2];
                btn4.Text = p.Opciones[3];
            }
            else if (p.Tipo == "imagen")
            {
                // Para imágenes, mostramos un placeholder
                btn1.Text = "🖼️ " + p.Opciones[0];
                btn2.Text = "🖼️ " + p.Opciones[1];
                btn3.Text = "🖼️ " + p.Opciones[2];
                btn4.Text = "🖼️ " + p.Opciones[3];

                // Aquí eventualmente cargarías las imágenes
                // Por ahora mostramos solo el texto
            }
            else if (p.Tipo == "audio")
            {
                // Para audio, mostramos un placeholder
                btn1.Text = "🔊 " + p.Opciones[0];
                btn2.Text = "🔊 " + p.Opciones[1];
                btn3.Text = "🔊 " + p.Opciones[2];
                btn4.Text = "🔊 " + p.Opciones[3];
            }
            else
            {
                // Tipo desconocido, mostrar como texto
                btn1.Text = p.Opciones[0];
                btn2.Text = p.Opciones[1];
                btn3.Text = p.Opciones[2];
                btn4.Text = p.Opciones[3];
            }

            // Mostrar el tipo de pregunta en algún lado (opcional, para depuración)
            this.Text = $"Juego - Categoría: {idCategoria} - Pregunta {indicePregunta + 1}/{preguntas.Count} - Tipo: {p.Tipo}";
        }

        void Responder(int opcion)
        {
            if (opcion >= 0 && opcion < 4 && indicePregunta < preguntas.Count)
            {
                var preguntaActual = preguntas[indicePregunta];

                // Verificar si la opción seleccionada es la correcta
                if (opcion == preguntaActual.Correcta)
                {
                    score++;
                    Console.WriteLine($"¡Correcto! Score: {score}");
                }
                else
                {
                    Console.WriteLine($"Incorrecto. La correcta era: {preguntaActual.Correcta + 1}");
                }

                indicePregunta++;

                if (indicePregunta < preguntas.Count)
                    MostrarPregunta();
                else
                    TerminarJuego();
            }
        }

        void GuardarPartida()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
                {
                    conn.Open();

                    string query = @"INSERT INTO partida (ID_Jugador, ID_Cat, Puntaje, Fecha, Hora) VALUES (@jugador,@cat,@score,CURDATE(),CURTIME())";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@jugador", idJugador);
                    cmd.Parameters.AddWithValue("@cat", idCategoria);
                    cmd.Parameters.AddWithValue("@score", score);

                    cmd.ExecuteNonQuery();

                    idPartida = (int)cmd.LastInsertedId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la partida: " + ex.Message);
                idPartida = 0;
            }
        }

        void TerminarJuego()
        {
            GuardarPartida();

            resultados r = new resultados(score, preguntas.Count, nombreJugador, idPartida);
            r.Show();

            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Responder(0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Responder(1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Responder(2);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Responder(3);
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Close();
        }
    }

    public class Pregunta
    {
        public int IdPregunta { get; set; }
        public string Enunciado { get; set; }
        public string[] Opciones { get; set; } = new string[4];
        public int Correcta { get; set; } = -1;
        public string Tipo { get; set; } = "texto";
    }
}