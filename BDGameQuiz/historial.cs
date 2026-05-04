using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BDGameQuiz.resultados;

namespace BDGameQuiz
{
    public partial class historial : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://10.103.151.54:8080";

        int idPartida;

        List<string> preguntas = new List<string>();
        List<bool> resultados = new List<bool>();

        int scrollY = 0;
        int maxScroll = 0;

        public historial(int idPartida)
        {
            InitializeComponent();
            this.idPartida = idPartida;

            this.Text = $"Detalle Partida #{idPartida}";
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            this.Load += (s, e) =>
            {
                CargarDetalle();
            };
        }

        async void CargarDetalle()
        {
            preguntas.Clear();
            resultados.Clear();

            try
            {
                string url = $"{API_BASE_URL}/games/{idPartida}/details";

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener detalle");
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();

                var detalles = JsonSerializer.Deserialize<List<DetalleAPI>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                foreach (var d in detalles)
                {
                    preguntas.Add(d.Enunciado);
                    resultados.Add(d.Es_Acierto);
                }

                scrollY = 0;
                this.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int x = 50;
            int y = 80 - scrollY;

            g.DrawString($"Detalle de la Partida #{idPartida}",
                new Font("Segoe UI", 18, FontStyle.Bold),
                Brushes.DarkBlue, 50, 20);

            int espacio = 35;

            for (int i = 0; i < preguntas.Count; i++)
            {
                bool acierto = resultados[i];

                Color color = acierto ? Color.Green : Color.Red;
                string estado = acierto ? "✔ Correcta" : "✘ Incorrecta";

                string texto = $"{i + 1}. {preguntas[i]}  ({estado})";

                g.DrawString(texto,
                    new Font("Segoe UI", 11),
                    new SolidBrush(color),
                    x, y);

                y += espacio;
            }

            if (preguntas.Count > 10)
            {
                g.DrawString("Usa la rueda del mouse para desplazarte",
                    new Font("Segoe UI", 9),
                    Brushes.Gray,
                    50, this.Height - 40);
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            int areaAltura = this.Height - 120;
            maxScroll = Math.Max(0, (preguntas.Count * 35) - areaAltura);

            scrollY -= e.Delta / 3;
            scrollY = Math.Max(0, Math.Min(scrollY, maxScroll));

            this.Invalidate();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public class DetalleAPI
        {
            public string Enunciado { get; set; }
            public bool Es_Acierto { get; set; }
        }
    }
}