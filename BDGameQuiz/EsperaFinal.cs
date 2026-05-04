using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BDGameQuiz
{
    public partial class EsperaFinal : Form
    {
        private readonly int idPartida;
        private readonly string nombreJugador;

        private static readonly HttpClient http = new HttpClient();
        private const string API = "http://10.103.151.54:8080";

        private Timer timer;

        private readonly Font fontTitulo = new Font("Arial", 32, FontStyle.Bold);
        private readonly Font fontSub = new Font("Arial", 18, FontStyle.Regular);
        private int jugadorId;
        private int salaId;

        private bool todosListos = false;

        public EsperaFinal(int idPartida, string nombreJugador, int jugadorId, int salaId)
        {
            InitializeComponent();

            this.idPartida = idPartida;
            this.nombreJugador = nombreJugador;
            this.jugadorId = jugadorId;
            this.salaId = salaId;

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
                var res = await http.GetAsync($"{API}/games/{idPartida}/status");

                if (!res.IsSuccessStatusCode) return;

                var json = await res.Content.ReadAsStringAsync();

                var estado = JsonSerializer.Deserialize<GameStatus>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (estado == null) return;

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
                        jugadorId
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
        }

        public void EsperaFinal_Load(object sender, EventArgs e)
        {

        }
    }
}