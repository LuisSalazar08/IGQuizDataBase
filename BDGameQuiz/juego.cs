using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WMPLib;

namespace BDGameQuiz
{
    public partial class juego : Form
    {
        List<Pregunta> preguntas = new List<Pregunta>();
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        int indicePregunta = 0;
        int score = 0;

        int idCategoria;
        string nombreJugador;
        int idJugador;
        int idPartida;

        bool audioYaReproducido = false;

        private List<Image> imagenesCargadas = new List<Image>();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape) 
            {
                DialogResult result = MessageBox.Show(
                    "Quieres Salir del Juego?",
                    "Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public juego(int cat, int idJugador, string nombreJugador)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.idCategoria = cat;
            this.idJugador = idJugador;
            this.nombreJugador = nombreJugador;

            this.Disposed += Juego_Disposed;

            CargarPreguntas();
        }

        private void Juego_Disposed(object sender, EventArgs e)
        {
            LiberarImagenes();
        }

        private void LiberarImagenes()
        {
            foreach (var img in imagenesCargadas)
            {
                if (img != null)
                {
                    img.Dispose();
                }
            }
            imagenesCargadas.Clear();
        }

        private void LiberarImagenesBotones()
        {
            Button[] botones = { btn1, btn2, btn3, btn4 };

            foreach (var btn in botones)
            {
                if (btn.BackgroundImage != null)
                {
                    Image img = btn.BackgroundImage;
                    btn.BackgroundImage = null;
                    img.Dispose();
                }

                if (btn.Image != null)
                {
                    Image img = btn.Image;
                    btn.Image = null;
                    img.Dispose();
                }
            }
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
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
                {
                    conn.Open();

                    string query = "SELECT * FROM pregunta WHERE ID_Cat = @cat ORDER BY RAND() LIMIT 14";
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
                    }

                    dr.Close();

                    // Cargar los incisos
                    foreach (Pregunta p in preguntas)
                    {
                        string queryIncisos = @"SELECT * FROM inciso WHERE ID_Cat = @cat AND ID_Preg = @preg ORDER BY ID_Inc";

                        MySqlCommand cmdInc = new MySqlCommand(queryIncisos, conn);
                        cmdInc.Parameters.AddWithValue("@preg", p.IdPregunta);
                        cmdInc.Parameters.AddWithValue("@cat", idCategoria);

                        MySqlDataReader drInc = cmdInc.ExecuteReader();

                        int indiceOpcion = 0;
                        string tipoDetectado = "texto";

                        while (drInc.Read() && indiceOpcion < 4)
                        {
                            p.Opciones[indiceOpcion] = drInc["Contenido"].ToString();

                            if (Convert.ToBoolean(drInc["Respuesta"]))
                                p.Correcta = indiceOpcion;

                            if (indiceOpcion == 0)
                                tipoDetectado = drInc["Tipo_Inciso"].ToString();

                            indiceOpcion++;
                        }

                        drInc.Close();
                        p.Tipo = tipoDetectado;

                        // Validar opciones nulas
                        for (int i = 0; i < 4; i++)
                        {
                            if (string.IsNullOrEmpty(p.Opciones[i]))
                                p.Opciones[i] = "Opción no disponible";
                        }

                        // Validar respuesta correcta
                        if (p.Correcta == -1)
                        {
                            p.Correcta = 0;
                            Console.WriteLine($"ADVERTENCIA: Pregunta {p.IdPregunta} sin respuesta correcta");
                        }
                        
                        MezclarOpciones(p);
                        
                    }
                }

                // Verificar preguntas cargadas
                if (preguntas.Count == 0)
                {
                    MessageBox.Show($"No hay preguntas disponibles para esta categoría (ID: {idCategoria}).");
                    btnMenu_Click_1(null, null);
                    return;
                }

                indicePregunta = 0;
                score = 0;
                MostrarPregunta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
            }
        }

        Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrEmpty(ruta) || !File.Exists(ruta))
                {
                    Console.WriteLine($"Archivo no encontrado: {ruta}");
                    return null;
                }

                // Verificar extensión
                string extension = Path.GetExtension(ruta).ToLower();
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png" && extension != ".bmp" && extension != ".gif")
                {
                    Console.WriteLine($"Formato no soportado: {extension}");
                    return null;
                }

                using (var fs = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                {
                    Image img = Image.FromStream(fs);

                    Bitmap copia = new Bitmap(img);


                    imagenesCargadas.Add(copia);

                    return copia;
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine($"Error de memoria al cargar imagen {ruta}: {ex.Message}");

                try
                {
                    Image img = Image.FromFile(ruta);
                    imagenesCargadas.Add(img);
                    return img;
                }
                catch
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar imagen {ruta}: {ex.Message}");
                return null;
            }
        }

        void MostrarPregunta()
        {
            if (indicePregunta >= preguntas.Count)
            {
                TerminarJuego();
                return;
            }

            audioYaReproducido = false;
            LiberarImagenesBotones();

            var p = preguntas[indicePregunta];
            lblPregunta.Text = p.Enunciado;

            btn1.AccessibleDescription = null;
            btn2.AccessibleDescription = null;
            btn3.AccessibleDescription = null;
            btn4.AccessibleDescription = null;

            btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = false;

            Timer timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();

                try
                {
                    ConfigurarBoton(btn1, p.Opciones[0], p.Tipo);
                    ConfigurarBoton(btn2, p.Opciones[1], p.Tipo);
                    ConfigurarBoton(btn3, p.Opciones[2], p.Tipo);
                    ConfigurarBoton(btn4, p.Opciones[3], p.Tipo);

                    btn1.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al configurar botones: " + ex.Message);
                }
            };
            timer.Start();

            this.Text = $"Juego - Categoría: {idCategoria} - Pregunta {indicePregunta + 1}/{preguntas.Count} - Tipo: {p.Tipo}";
        }

        void ConfigurarBoton(Button btn, string opcion, string tipo)
        {
            btn.Text = "";
            btn.Image = null;
            btn.BackgroundImage = null;
            btn.Tag = opcion;

            if (tipo == "texto")
            {
                btn.Text = opcion;
            }
            else if (tipo == "imagen")
            {
                Image img = CargarImagen(opcion);
                if (img != null)
                {
                    btn.BackgroundImage = img;
                    btn.BackgroundImageLayout = ImageLayout.Zoom;
                }
                else
                {
                    btn.Text = "Error al cargar imagen";
                    btn.BackColor = Color.LightCoral;
                }
            }
            else if (tipo == "audio")
            {
                int numero = 0;

                if (btn == btn1) numero = 1;
                else if (btn == btn2) numero = 2;
                else if (btn == btn3) numero = 3;
                else if (btn == btn4) numero = 4;

                btn.Text = $"🔊 Audio {numero}";
            }
        }

        void ManejarClick(int opcion, Button btn)
        {
            var p = preguntas[indicePregunta];

            if (p.Tipo == "audio")
            {
                string archivo = btn.Tag.ToString();

                if (btn.AccessibleDescription != "ya")
                {
                    try
                    {
                        if (File.Exists(archivo))
                        {
                            player.controls.stop();
                            player.URL = archivo;
                            player.controls.play();
                            btn.BackColor = Color.LightBlue;

                            btn.AccessibleDescription = "ya";
                            btn.Text += " Click para Responder";

                            return;
                        }
                        else
                        {
                            MessageBox.Show("Archivo de audio no encontrado");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al reproducir audio: " + ex.Message);
                        return;
                    }
                }
            }

            Responder(opcion);
        }

        void Responder(int opcion)
        {
            player.controls.stop();

            if (opcion >= 0 && opcion < 4 && indicePregunta < preguntas.Count)
            {
                var preguntaActual = preguntas[indicePregunta];

                Button[] botones = { btn1, btn2, btn3, btn4 };

                if (opcion == preguntaActual.Correcta)
                {
                    botones[opcion].BackColor = Color.LightGreen;
                    score++;
                }
                else
                {
                    botones[opcion].BackColor = Color.LightCoral;
                    if (preguntaActual.Correcta >= 0 && preguntaActual.Correcta < 4)
                    {
                        botones[preguntaActual.Correcta].BackColor = Color.LightGreen;
                    }
                }

                foreach (var btn in botones)
                {
                    btn.Enabled = false;
                }

                Timer timer = new Timer();
                timer.Interval = 800;
                timer.Tick += (s, e) =>
                {
                    timer.Stop();
                    timer.Dispose();

                    foreach (var btn in botones)
                    {
                        btn.BackColor = SystemColors.Control;
                    }

                    indicePregunta++;

                    if (indicePregunta < preguntas.Count)
                        MostrarPregunta();
                    else
                        TerminarJuego();
                };
                timer.Start();
            }
        }

        void GuardarPartida()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
                {
                    conn.Open();

                    string query = @"INSERT INTO partida (ID_Jugador, ID_Cat, Puntaje, Fecha, Hora) 
                                    VALUES (@jugador,@cat,@score,CURDATE(),CURTIME())";

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
            LiberarImagenes();
            player.controls.stop();

            GuardarPartida();

            resultados r = new resultados(score, preguntas.Count, nombreJugador, idPartida);
            r.Show();

            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            ManejarClick(0, btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ManejarClick(1, btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ManejarClick(2, btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ManejarClick(3, btn4);
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            LiberarImagenes();
            player.controls.stop();

            menu m = new menu(nombreJugador, idJugador);
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