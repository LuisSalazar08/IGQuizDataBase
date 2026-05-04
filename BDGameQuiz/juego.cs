using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BDGameQuiz
{
    public partial class juego : Form
    {
        private List<PreguntaAPI> preguntas = new List<PreguntaAPI>();
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
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://10.103.151.54:8080";

        private int salaId;
        private bool esHost;

        public juego(int cat, int idJugador, string nombreJugador, int salaId, bool esHost)
        {
            InitializeComponent();

            this.idCategoria = cat;
            this.idJugador = idJugador;
            this.nombreJugador = nombreJugador;
            this.salaId = salaId;
            this.esHost = esHost;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.KeyPreview = true;

            this.Controls.Clear();

            fondoActual = ObtenerFondoPorCategoria();

            this.Load += Juego_Load;
            this.Resize += Juego_Resize;
            this.Disposed += Juego_Disposed;

            Task.Run(async () => await CrearPartidaAsync()).Wait();
            Task.Run(async () => await CargarPreguntasAsync()).Wait();
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

        private void CalcularLayout()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int margen = 30;
            int separacion = 25;
            int offsetY = (int)(h * 0.08);
            int altoPregunta = 140;

            rectPregunta = new Rectangle(
                margen,
                margen + offsetY,
                w - (margen * 2),
                altoPregunta
            );

            int espacioPreguntaOpciones = 200;
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

        private void MezclarOpciones(PreguntaAPI p)
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

        private async Task CargarPreguntasAsync()
        {
            preguntas.Clear();

            try
            {
                string url = $"{API_BASE_URL}/questions/?cat={idCategoria}";
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var preguntasTemp = JsonSerializer.Deserialize<List<PreguntaAPI>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (preguntasTemp != null)
                    {
                        foreach (var p in preguntasTemp)
                        {
                            p.Tipo = DetectarTipoPregunta(p);
                            MezclarOpciones(p);
                            preguntas.Add(p);
                        }
                    }
                }

                if (preguntas.Count == 0)
                {
                    MessageBox.Show($"No hay preguntas disponibles para esta categoría (ID: {idCategoria}).");
                    VolverAlLobby();
                    return;
                }

                indicePregunta = 0;
                score = 0;
                MostrarPregunta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
                VolverAlLobby();
            }
        }

        private string DetectarTipoPregunta(PreguntaAPI p)
        {
            foreach (var opcion in p.Opciones)
            {
                if (opcion.EndsWith(".mp3") || opcion.EndsWith(".wav") || opcion.EndsWith(".ogg"))
                    return "audio";

                if (opcion.EndsWith(".jpg") || opcion.EndsWith(".png") || opcion.EndsWith(".bmp") ||
                    opcion.EndsWith(".jpeg") || opcion.EndsWith(".gif"))
                    return "imagen";
            }
            return "texto";
        }

        private Image CargarImagen(string ruta)
        {
            try
            {
                if (string.IsNullOrEmpty(ruta) || !File.Exists(ruta))
                {
                    return null;
                }

                string extension = Path.GetExtension(ruta).ToLower();
                if (extension != ".jpg" && extension != ".jpeg" && extension != ".png" && extension != ".bmp" && extension != ".gif")
                {
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
            catch
            {
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
        }

        private void PrepararImagenesDePregunta(PreguntaAPI p)
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

        private void VolverAlLobby()
        {
            LiberarImagenes();

            try { player.controls.stop(); } catch { }

            Lobby lobby = new Lobby(salaId, idJugador, esHost);
            lobby.Show();

            this.Close();
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
            g.SmoothingMode = SmoothingMode.AntiAlias;

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
                p.Pregunta,
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

        private void DibujarOpcion(Graphics g, PreguntaAPI p, int i, StringFormat sfCentro)
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
                if (indiceAudioPrevisualizado.HasValue &&
                    indiceAudioPrevisualizado.Value == i &&
                    !esperandoSiguientePregunta)
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

            if (hoverRect == Rectangle.Empty)
                this.Cursor = Cursors.Default;
            else
                this.Cursor = Cursors.Hand;
        }

        protected override async void OnMouseClick(MouseEventArgs e)
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
                    await ManejarClickAsync(i);
                    break;
                }
            }
        }

        private async Task ManejarClickAsync(int opcion)
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
                            this.Invoke(new Action(() => Invalidate()));
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

            await ResponderAsync(opcion);
        }

        private async Task ResponderAsync(int opcion)
        {
            try { player.controls.stop(); } catch { }

            if (opcion < 0 || opcion >= 4 || indicePregunta >= preguntas.Count)
                return;

            var preguntaActual = preguntas[indicePregunta];

            this.Invoke(new Action(() => {
                indiceSeleccionado = opcion;
                esperandoSiguientePregunta = true;
                Invalidate();
            }));

            bool esCorrecto = opcion == preguntaActual.Correcta;

            if (esCorrecto)
            {
                score++;
            }

            await EnviarRespuestaAsync(preguntaActual.Id, opcion);

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

        private async Task EnviarRespuestaAsync(int idPregunta, int opcion)
        {
            try
            {
                var preguntaActual = preguntas[indicePregunta];

                var answerData = new
                {
                    pregunta_id = idPregunta,
                    opcion = opcion,
                    es_correcto = opcion == preguntaActual.Correcta
                };

                string json = JsonSerializer.Serialize(answerData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                Console.WriteLine($"ID PARTIDA: {idPartida}");
                Console.WriteLine($"Enviando JSON: {json}");

                var response = await httpClient.PostAsync(
                    $"{API_BASE_URL}/games/{idPartida}/answer",
                    content
                );

                Console.WriteLine("Status: " + response.StatusCode);

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response: " + responseBody);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar respuesta: " + ex.Message);
            }
        }

        private async Task CrearPartidaAsync()
        {
            try
            {
                var partidaData = new
                {
                    jugador_id = idJugador,
                    categoria_id = idCategoria,
                    sala_id = salaId,
                    puntaje = 0
                };

                string json = JsonSerializer.Serialize(partidaData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync($"{API_BASE_URL}/games/", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var partidaCreada = JsonSerializer.Deserialize<PartidaResponse>(responseJson, options);

                    if (partidaCreada != null)
                        idPartida = partidaCreada.Id;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la partida: " + ex.Message);
                idPartida = 0;
            }
        }

        private void TerminarJuego()
        {
            LiberarImagenes();

            try { player.controls.stop(); } catch { }

            EsperaFinal espera = new EsperaFinal(idPartida, nombreJugador, idJugador, salaId);
            espera.Show();
            this.Close();

        }

    }

    public class PreguntaAPI
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public List<string> Opciones { get; set; } = new List<string>();
        public int Correcta { get; set; } = -1;
        public string Tipo { get; set; } = "texto";
    }

    public class PartidaResponse
    {
        public int Id { get; set; }
        public int JugadorId { get; set; }
        public int CategoriaId { get; set; }
        public int Puntaje { get; set; }
    }
}