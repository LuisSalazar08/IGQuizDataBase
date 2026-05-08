using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace BDGameQuiz
{
    public partial class Lobby : Form
    {
        private int salaId;
        private int jugadorId;
        private bool esHost;
        private int totalJugadores = 0;
        private int jugadoresListos = 0;
        private string categoriaActual = null;
		private int _prevTotal = -1;
		private int _prevListos = -1;
		private string _prevCategoria = null;
        private string nombreJugador;
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;

        private Timer timer;

        private Rectangle rectBtnListo;
        private Rectangle rectBtnStart;
        private Rectangle rectBtnCategoria;

        private Rectangle hoverRect = Rectangle.Empty;

        private readonly Font fontBoton = new Font("Arial", 30, FontStyle.Bold);

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                var result = MessageBox.Show(
                    "¿Quieres salir del juego?",
                    "Salir",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {

                    try
                    {
                        writer?.Close();
                        reader?.Close();
                        client?.Close();
                    }
                    catch { }
                    Application.Exit();
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }

        public Lobby(int salaId,int jugadorId,bool esHost,string nombreJugador,TcpClient client,StreamReader reader,StreamWriter writer)
        {
            InitializeComponent();

            this.salaId = salaId;
            this.jugadorId = jugadorId;
            this.esHost = esHost;
            this.nombreJugador = nombreJugador;
            this.client = client;
            this.reader = reader;
            this.writer = writer;

            this.DoubleBuffered = true;
			this.SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.OptimizedDoubleBuffer,
				true
			);
			this.UpdateStyles();

			this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = global::BDGameQuiz.Properties.Resources.fondo;

            this.Resize += (s, e) => { CalcularLayout(); Invalidate(); };
            this.Load += (s, e) => { CalcularLayout(); };

            IniciarPolling();
        }

        private void IniciarPolling()
        {
            timer = new Timer();
            timer.Interval = 1500;

            timer.Tick += async (s, e) =>
            {
                await ObtenerEstadoSala();
            };

            timer.Start();
        }

        private async Task ObtenerEstadoSala()
        {
            try
            {
                await writer.WriteLineAsync($"ROOM_STATUS|{salaId}");

                string respuesta = await reader.ReadLineAsync();

                string[] partes = respuesta.Split('|');

                totalJugadores = int.Parse(partes[1]);
                jugadoresListos = int.Parse(partes[2]);

                categoriaActual = partes[3];

                string estadoSala = partes[4];

                Invalidate();

                if (estadoSala == "jugando")
                {
                    timer.Stop();

                    int idCategoria;

                    if (categoriaActual == "Historia")
                        idCategoria = 1;
                    else if (categoriaActual == "Geografía")
                        idCategoria = 2;
                    else if (categoriaActual == "Cultura")
                        idCategoria = 3;
                    else if (categoriaActual == "Gastronomía")
                        idCategoria = 4;
                    else if (categoriaActual == "Arte")
                        idCategoria = 5;
                    else if (categoriaActual == "Deportes")
                        idCategoria = 6;
                    else if (categoriaActual == "Naturaleza")
                        idCategoria = 7;
                    else
                        idCategoria = 1;
                    juego j = new juego(
                        idCategoria,
                        jugadorId,
                        nombreJugador,
                        salaId,
                        esHost
                    );

                    j.Show();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcularLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            int ancho = 260;
            int alto = 60;

            rectBtnCategoria = new Rectangle(w / 2 - 110, h - 220, ancho, alto);

            rectBtnListo = new Rectangle(w / 2 - ancho - 20, h - 120, ancho, alto);

            rectBtnStart = new Rectangle(w / 2 + 20, h - 120, ancho, alto);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var fontInfo = new Font("Arial", 70, FontStyle.Bold);

            string txtJugadores = $"Jugadores: {totalJugadores}";
            string txtListos = $"Listos: {jugadoresListos}";
            string txtSala = $"Sala #{salaId}";
            string txtCategoria = categoriaActual != null
                ? $"Categoría: {categoriaActual}"
                : "Categoría: Sin elegir";

            float centerX = ClientSize.Width / 2;

            float y1 = 40;
            float y2 = 170;
            float y3 = 280;

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };
            
            var g = e.Graphics;

            g.DrawString(txtJugadores, fontInfo, Brushes.Black, centerX, y1, sf);
            g.DrawString(txtListos, fontInfo, Brushes.Black, centerX, y2, sf);
            g.DrawString(txtCategoria, fontInfo, Brushes.Black, centerX, y3, sf);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            var fontSala = new Font("Arial", 30, FontStyle.Bold);

            StringFormat sfDerecha = new StringFormat
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Near
            };

            g.DrawString(
                txtSala,
                fontSala,
                Brushes.Black,
                new Rectangle(0, 20, ClientSize.Width - 30, 40),
                sfDerecha
            );

            DibujarBoton(g, rectBtnListo, "LISTO", Color.DodgerBlue);

            if (esHost)
            {
                DibujarBoton(g, rectBtnStart, "INICIAR", Color.SeaGreen);
                DibujarBoton(g, rectBtnCategoria, "CATEGORÍA", Color.Orange);
            }
        }

        private void DibujarBoton(Graphics g, Rectangle rect, string texto, Color colorBase)
        {
            Color color = hoverRect == rect
                ? ControlPaint.Light(colorBase)
                : colorBase;

            using (Brush b = new SolidBrush(color))
                g.FillRectangle(b, rect);

            g.DrawRectangle(Pens.Black, rect);

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString(texto, fontBoton, Brushes.White, rect, sf);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Rectangle nuevo = Rectangle.Empty;

            if (rectBtnListo.Contains(e.Location))
                nuevo = rectBtnListo;

            if (esHost && rectBtnStart.Contains(e.Location))
                nuevo = rectBtnStart;

            if (esHost && rectBtnCategoria.Contains(e.Location))
                nuevo = rectBtnCategoria;

            if (hoverRect != nuevo)
            {
                hoverRect = nuevo;
                Invalidate();
            }

            Cursor = (hoverRect == Rectangle.Empty) ? Cursors.Default : Cursors.Hand;
        }
        protected override async void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (rectBtnListo.Contains(e.Location))
                await MarcarListo();

            if (esHost && rectBtnStart.Contains(e.Location))
                await IniciarPartida();

            if (esHost && rectBtnCategoria.Contains(e.Location))
                AbrirMenuCategorias();
        }


        private async Task MarcarListo()
        {
            await writer.WriteLineAsync(
                $"READY|{salaId}|{jugadorId}"
            );

            await reader.ReadLineAsync();
        }

        private async Task IniciarPartida()
        {
            await writer.WriteLineAsync(
                $"START_GAME|{salaId}|{jugadorId}"
            );

            string respuesta = await reader.ReadLineAsync();

            if (respuesta != "OK")
            {
                MessageBox.Show(
                    "Falta categoría o jugadores listos"
                );
            }
        }

        private void AbrirMenuCategorias()
        {
            timer.Stop();

            MenuCategorias menu = new MenuCategorias(salaId, jugadorId, client, reader, writer);
            menu.ShowDialog();

            timer.Start();
        }

        public class EstadoSala
        {
            public string estado { get; set; }
            public int? categoria_id { get; set; }
            public string categoria { get; set; }
            public int host { get; set; }
            public int total { get; set; }
            public int listos { get; set; }
            public bool todos_listos { get; set; }
        }

        //No eliminar aunque no hace nada
        public void Lobby_Load(object sender, EventArgs e)
        {

        }
    }
}