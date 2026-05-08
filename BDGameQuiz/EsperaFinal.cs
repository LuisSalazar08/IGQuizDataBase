using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace BDGameQuiz
{
    public partial class EsperaFinal : Form
    {
        private readonly int idPartida;
        private readonly string nombreJugador;

        private Timer timer;

        private readonly Font fontTitulo = new Font("Arial", 32, FontStyle.Bold);
        private readonly Font fontSub = new Font("Arial", 18, FontStyle.Regular);
        private int jugadorId;
        private int salaId;

        private bool todosListos = false;
        TcpClient client;
        StreamReader reader;
        StreamWriter writer;

        public EsperaFinal(int idPartida,string nombreJugador,int jugadorId,int salaId,TcpClient client,StreamReader reader,StreamWriter writer)
        {
            InitializeComponent();

            this.idPartida = idPartida;
            this.nombreJugador = nombreJugador;
            this.jugadorId = jugadorId;
            this.salaId = salaId;
            this.client = client;
            this.reader = reader;
            this.writer = writer;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            this.BackgroundImage = Properties.Resources.fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            IniciarPolling();
        }

        private void IniciarPolling()
        {
            timer = new Timer();
            timer.Interval = 1500;

            timer.Tick += async (s, e) =>
            {
                await RevisarEstado();
            };

            timer.Start();
        }

        private async Task RevisarEstado()
        {
            try
            {
                await writer.WriteLineAsync(
                    $"GAME_STATUS|{idPartida}"
                );

                string respuesta = await reader.ReadLineAsync();

                string[] partes = respuesta.Split('|');

                if (partes.Length < 2)
                    return;

                string json = partes[1];

                var estado = JsonSerializer.Deserialize<GameStatus>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );

                if (estado == null)
                    return;

                todosListos = estado.todos_terminaron;

                Invalidate();

                if (estado.todos_terminaron)
                {
                    timer.Stop();

                    resultados r = new resultados(
                        estado.mi_score,
                        estado.total_preguntas,
                        nombreJugador,
                        idPartida,
                        salaId,
                        jugadorId,
                        estado.ganador,
                        estado.puntaje_ganador,
                        client,
                        reader,
                        writer
                    );

                    r.Show();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            string titulo = "ESPERANDO A JUGADORES";
            string subtitulo = "Se está calculando el resultado final...";

            string estado = todosListos
                ? "Todos terminaron. Preparando resultados..."
                : "Esperando a que todos los jugadores terminen...";

            float cx = this.ClientSize.Width / 2;
            float cy = this.ClientSize.Height / 2;

            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center
            };

            using (Brush overlay = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
            {
                g.FillRectangle(overlay, this.ClientRectangle);
            }

            g.DrawString(titulo, fontTitulo, Brushes.White, cx, cy - 80, sf);
            g.DrawString(subtitulo, fontSub, Brushes.White, cx, cy, sf);
            g.DrawString(estado, fontSub, Brushes.LightGray, cx, cy + 60, sf);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                var r = MessageBox.Show(
                    "¿Salir del juego?",
                    "Salir",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (r == DialogResult.Yes)
                    try
                    {
                        writer?.Close();
                        reader?.Close();
                        client?.Close();
                    }
                    catch { }
                Application.Exit();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public class GameStatus
        {
            public int total_jugadores { get; set; }
            public int terminaron { get; set; }
            public bool todos_terminaron { get; set; }

            public int mi_score { get; set; }
            public int total_preguntas { get; set; }
            public string ganador { get; set; }
            public int puntaje_ganador { get; set; }
        }

        public void EsperaFinal_Load(object sender, EventArgs e)
        {

        }
    }
}