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
        private List<Pregunta> preguntas = new List<Pregunta>();
        private WindowsMediaPlayer player = new WindowsMediaPlayer();

        private int indicePregunta = 0;
        private int score = 0;

        private int idCategoria;
        private string nombreJugador;
        private int idJugador;
        private int idPartida;

        private Image fondoActual;

        private bool audioYaReproducido = false;
        private int? indiceSeleccionado = null;
        private int? indiceAudioPrevisualizado = null;
        private bool esperandoSiguientePregunta = false;

        private readonly List<Image> imagenesCargadas = new List<Image>();
        private readonly Image[] imagenesOpcionesActuales = new Image[4];

        private Rectangle rectPregunta;
        private readonly Rectangle[] rectOpciones = new Rectangle[4];
        private Rectangle hoverRect = Rectangle.Empty;

        private readonly Font fontPregunta = new Font("Times New Roman", 40, FontStyle.Italic);
        private readonly Font fontOpcion = new Font("Times New Roman", 16, FontStyle.Italic);
        private readonly Font fontOpcionAudio = new Font("Times New Roman", 16, FontStyle.Italic);
        private readonly Font fontError = new Font("Arial", 13, FontStyle.Bold);

        private static readonly Random rnd = new Random();

        public juego(int cat, int idJugador, string nombreJugador)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            this.idCategoria = cat;
            this.idJugador = idJugador;
            this.nombreJugador = nombreJugador;

            this.Controls.Clear();

            fondoActual = ObtenerFondoPorCategoria();

            this.Load += Juego_Load;
            this.Resize += Juego_Resize;
            this.Disposed += Juego_Disposed;

            CargarPreguntas();
        }

        private Image ObtenerFondoPorCategoria()
        {
            switch (idCategoria)
            {
                case 1: return Properties.Resources.fondo_historia;
                case 2: return Properties.Resources.fondo_geografia;
                case 3: return Properties.Resources.fondo_cultura;
                case 4: return Properties.Resources.fondo_gastronomia;
                case 5: return Properties.Resources.fondo_arte;
                case 6: return Properties.Resources.fondo_deportes;
                case 7: return Properties.Resources.fondo_naturaleza;
                default: return Properties.Resources.fondo;
            }
        }

        private void Juego_Load(object sender, EventArgs e)
        {
            CalcularLayout();
            Invalidate();
        }

        private void Juego_Resize(object sender, EventArgs e)
        {
            CalcularLayout();
            Invalidate();
        }

        private void Juego_Disposed(object sender, EventArgs e)
        {
            LiberarImagenes();

            try { player.controls.stop(); } catch { }
            try { player.close(); } catch { }

            fontPregunta.Dispose();
            fontOpcion.Dispose();
            fontOpcionAudio.Dispose();
            fontError.Dispose();
        }

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

        void CalcularLayout()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int margen = 30;
            int separacion = 25;

            int offsetY = (int)(h * 0.08); // 8% hacia abajo

            int altoPregunta = 140;

            rectPregunta = new Rectangle(
                margen,
                margen + offsetY,
                w - (margen * 2),
                altoPregunta
            );

            int espacioPreguntaOpciones = 50;

            int areaOpcionesY = rectPregunta.Bottom + espacioPreguntaOpciones;
            int areaOpcionesAlto = h - areaOpcionesY - margen;

            int anchoOpcion = (w - (margen * 2) - separacion) / 2;

            int altoOpcion = Math.Min(180, (areaOpcionesAlto - separacion) / 2);

            rectOpciones[0] = new Rectangle(margen, areaOpcionesY, anchoOpcion, altoOpcion);
            rectOpciones[1] = new Rectangle(margen + anchoOpcion + separacion, areaOpcionesY, anchoOpcion, altoOpcion);
            rectOpciones[2] = new Rectangle(margen, areaOpcionesY + altoOpcion + separacion, anchoOpcion, altoOpcion);
            rectOpciones[3] = new Rectangle(margen + anchoOpcion + separacion, areaOpcionesY + altoOpcion + separacion, anchoOpcion, altoOpcion);
        }

        private void LiberarImagenes()
        {
            foreach (var img in imagenesCargadas)
            {
                if (img != null)
                    img.Dispose();
            }

            imagenesCargadas.Clear();

            for (int i = 0; i < imagenesOpcionesActuales.Length; i++)
            {
                if (imagenesOpcionesActuales[i] != null)
                {
                    imagenesOpcionesActuales[i].Dispose();
                    imagenesOpcionesActuales[i] = null;
                }
            }
        }

        private void LimpiarEstadoVisual()
        {
            indiceSeleccionado = null;
            indiceAudioPrevisualizado = null;
            esperandoSiguientePregunta = false;
            audioYaReproducido = false;
            hoverRect = Rectangle.Empty;
        }

        private void MezclarOpciones(Pregunta p)
        {
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

        private void CargarPreguntas()
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

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Pregunta p = new Pregunta();
                            p.IdPregunta = Convert.ToInt32(dr["ID_Preg"]);
                            p.Enunciado = dr["Enunciado"].ToString();
                            p.Opciones = new string[4];
                            p.Correcta = -1;
                            preguntas.Add(p);
                        }
                    }

                    foreach (Pregunta p in preguntas)
                    {
                        string queryIncisos = @"SELECT * FROM inciso WHERE ID_Cat = @cat AND ID_Preg = @preg ORDER BY ID_Inc";

                        MySqlCommand cmdInc = new MySqlCommand(queryIncisos, conn);
                        cmdInc.Parameters.AddWithValue("@preg", p.IdPregunta);
                        cmdInc.Parameters.AddWithValue("@cat", idCategoria);

                        using (MySqlDataReader drInc = cmdInc.ExecuteReader())
                        {
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

                            p.Tipo = tipoDetectado;
                        }

                        for (int i = 0; i < 4; i++)
                        {
                            if (string.IsNullOrEmpty(p.Opciones[i]))
                                p.Opciones[i] = "Opción no disponible";
                        }

                        if (p.Correcta == -1)
                        {
                            p.Correcta = 0;
                            Console.WriteLine($"ADVERTENCIA: Pregunta {p.IdPregunta} sin respuesta correcta");
                        }

                        MezclarOpciones(p);
                    }
                }

                if (preguntas.Count == 0)
                {
                    MessageBox.Show($"No hay preguntas disponibles para esta categoría (ID: {idCategoria}).");
                    VolverAlMenu();
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

        private Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrEmpty(ruta) || !File.Exists(ruta))
                {
                    Console.WriteLine($"Archivo no encontrado: {ruta}");
                    return null;
                }

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

        private void PrepararImagenesDePregunta(Pregunta p)
        {
            for (int i = 0; i < imagenesOpcionesActuales.Length; i++)
            {
                if (imagenesOpcionesActuales[i] != null)
                {
                    imagenesOpcionesActuales[i].Dispose();
                    imagenesOpcionesActuales[i] = null;
                }
            }

            if (p.Tipo != "imagen")
                return;

            for (int i = 0; i < 4; i++)
            {
                imagenesOpcionesActuales[i] = CargarImagen(p.Opciones[i]);
            }
        }

        private void MostrarPregunta()
        {
            if (indicePregunta >= preguntas.Count)
            {
                TerminarJuego();
                return;
            }

            LiberarImagenes();
            LimpiarEstadoVisual();

            var p = preguntas[indicePregunta];
            PrepararImagenesDePregunta(p);

            this.Text = $"Juego - Categoría: {idCategoria} - Pregunta {indicePregunta + 1}/{preguntas.Count} - Tipo: {p.Tipo}";
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            if (fondoActual != null)
            {
                g.DrawImage(fondoActual, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
            }
            else
            {
                g.Clear(Color.FromArgb(194, 255, 194));
            }

            using (Brush overlay = new SolidBrush(Color.FromArgb(80, 0, 0, 0)))
            {
                g.FillRectangle(overlay, this.ClientRectangle);
            }

            if (preguntas == null || preguntas.Count == 0 || indicePregunta >= preguntas.Count)
                return;

            var p = preguntas[indicePregunta];

            StringFormat sfCentro = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            using (Brush bgPregunta = new SolidBrush(Color.FromArgb(185, 255, 255, 255)))
            {
                g.FillRectangle(bgPregunta, rectPregunta);
            }

            using (Pen penPregunta = new Pen(Color.FromArgb(140, 0, 0, 0), 2))
            {
                g.DrawRectangle(penPregunta, rectPregunta);
            }

            g.DrawString(
                p.Enunciado,
                fontPregunta,
                Brushes.Black,
                rectPregunta,
                sfCentro
            );

            for (int i = 0; i < 4; i++)
            {
                DibujarOpcion(g, p, i, sfCentro);
            }
        }

        private void DibujarOpcion(Graphics g, Pregunta p, int i, StringFormat sfCentro)
        {
            Rectangle rect = rectOpciones[i];

            Color fondo = Color.FromArgb(205, Color.White);

            if (hoverRect == rect)
                fondo = Color.FromArgb(225, Color.LightGray);

            if (indiceSeleccionado.HasValue)
            {
                if (i == p.Correcta)
                    fondo = Color.LightGreen;
                else if (i == indiceSeleccionado.Value)
                    fondo = Color.LightCoral;
            }

            using (Brush brush = new SolidBrush(fondo))
            {
                g.FillRectangle(brush, rect);
            }

            g.DrawRectangle(Pens.Black, rect);

            Rectangle inner = new Rectangle(rect.X + 8, rect.Y + 8, rect.Width - 16, rect.Height - 16);

            if (p.Tipo == "texto")
            {
                g.DrawString(
                    p.Opciones[i],
                    fontOpcion,
                    Brushes.Black,
                    inner,
                    sfCentro
                );
            }
            else if (p.Tipo == "imagen")
            {
                if (imagenesOpcionesActuales[i] != null)
                {
                    Rectangle imgRect = AjustarImagenEnRectangulo(imagenesOpcionesActuales[i], inner);
                    g.DrawImage(imagenesOpcionesActuales[i], imgRect);
                }
                else
                {
                    g.DrawString(
                        "Imagen no disponible",
                        fontError,
                        Brushes.Black,
                        inner,
                        sfCentro
                    );
                }
            }
            else if (p.Tipo == "audio")
            {
                string texto = $"🔊 Audio {i + 1}";
                if (indiceAudioPrevisualizado.HasValue && indiceAudioPrevisualizado.Value == i && !esperandoSiguientePregunta)
                {
                    texto += "\n(ya reproducido)";
                }

                g.DrawString(
                    texto,
                    fontOpcionAudio,
                    Brushes.Black,
                    inner,
                    sfCentro
                );
            }
            else
            {
                g.DrawString(
                    p.Opciones[i],
                    fontOpcion,
                    Brushes.Black,
                    inner,
                    sfCentro
                );
            }
        }

        private Rectangle AjustarImagenEnRectangulo(Image img, Rectangle contenedor)
        {
            float ratioImg = (float)img.Width / img.Height;
            float ratioBox = (float)contenedor.Width / contenedor.Height;

            int drawW, drawH;
            int x, y;

            if (ratioImg > ratioBox)
            {
                drawW = contenedor.Width;
                drawH = (int)(contenedor.Width / ratioImg);
                x = contenedor.X;
                y = contenedor.Y + (contenedor.Height - drawH) / 2;
            }
            else
            {
                drawH = contenedor.Height;
                drawW = (int)(contenedor.Height * ratioImg);
                x = contenedor.X + (contenedor.Width - drawW) / 2;
                y = contenedor.Y;
            }

            return new Rectangle(x, y, drawW, drawH);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (indicePregunta >= preguntas.Count)
                return;

            Rectangle nuevoHover = Rectangle.Empty;

            for (int i = 0; i < rectOpciones.Length; i++)
            {
                if (rectOpciones[i].Contains(e.Location))
                {
                    nuevoHover = rectOpciones[i];
                    break;
                }
            }

            if (hoverRect != nuevoHover)
            {
                hoverRect = nuevoHover;
                Invalidate();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (esperandoSiguientePregunta)
                return;

            if (indicePregunta >= preguntas.Count)
                return;

            for (int i = 0; i < rectOpciones.Length; i++)
            {
                if (rectOpciones[i].Contains(e.Location))
                {
                    ManejarClick(i);
                    break;
                }
            }
        }

        private void ManejarClick(int opcion)
        {
            var p = preguntas[indicePregunta];

            if (p.Tipo == "audio")
            {
                string archivo = p.Opciones[opcion];

                if (indiceAudioPrevisualizado == null || indiceAudioPrevisualizado.Value != opcion)
                {
                    try
                    {
                        if (File.Exists(archivo))
                        {
                            try { player.controls.stop(); } catch { }
                            player.URL = archivo;
                            player.controls.play();

                            indiceAudioPrevisualizado = opcion;
                            Invalidate();
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

        private void Responder(int opcion)
        {
            try { player.controls.stop(); } catch { }

            if (opcion < 0 || opcion >= 4 || indicePregunta >= preguntas.Count)
                return;

            var preguntaActual = preguntas[indicePregunta];

            indiceSeleccionado = opcion;
            esperandoSiguientePregunta = true;

            if (opcion == preguntaActual.Correcta)
                score++;

            Invalidate();

            Timer timer = new Timer();
            timer.Interval = 800;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();

                indicePregunta++;
                indiceSeleccionado = null;
                indiceAudioPrevisualizado = null;
                esperandoSiguientePregunta = false;
                audioYaReproducido = false;

                if (indicePregunta < preguntas.Count)
                    MostrarPregunta();
                else
                    TerminarJuego();
            };
            timer.Start();
        }

        private void GuardarPartida()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
                {
                    conn.Open();

                    string query = @"INSERT INTO partida (ID_Jugador, ID_Cat, Puntaje, Fecha, Hora) 
                                     VALUES (@jugador, @cat, @score, CURDATE(), CURTIME())";

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

        private void TerminarJuego()
        {
            LiberarImagenes();

            try { player.controls.stop(); } catch { }

            GuardarPartida();

            resultados r = new resultados(score, preguntas.Count, nombreJugador, idPartida);
            r.Show();

            this.Close();
        }

        private void VolverAlMenu()
        {
            LiberarImagenes();

            try { player.controls.stop(); } catch { }

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