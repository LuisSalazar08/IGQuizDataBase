using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BDGameQuiz
{
    public partial class resultados : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://192.168.56.1:8080";

        int score;
        int total;
        int idPartidaReciente;
        string nombreJugador;

        int scrollY = 0;
        int partidaSeleccionada = -1;
        int maxScroll = 0;

        List<string> preguntas = new List<string>();
        List<bool> resultadosLista = new List<bool>();

        public resultados(int scoreFinal, int totalPreguntas, string nombreJugador, int idPartida)
        {
            InitializeComponent();

            score = scoreFinal;
            total = totalPreguntas;
            this.nombreJugador = nombreJugador;
            idPartidaReciente = idPartida;

            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            int porcentaje = (score * 100 / total);
            lblScore.Text = $"{nombreJugador}\n{score}/{total} puntos\n{porcentaje}% de aciertos";

            ScoresView.Visible = true;


            this.Load += async (s, e) =>
            {
                CargarHistorial();

                if (idPartidaReciente > 0)
                {
                    await Task.Delay(200);

                    foreach (DataGridViewRow row in ScoresView.Rows)
                    {
                        if (row.Cells[0].Value != null &&
                            Convert.ToInt32(row.Cells[0].Value) == idPartidaReciente)
                        {
                            row.Selected = true;
                            partidaSeleccionada = idPartidaReciente;
                            CargarDetalle(idPartidaReciente);
                            break;
                        }
                    }
                }
            };

            if (ScoresView.Rows.Count > 0 && idPartidaReciente > 0)
            {
                foreach (DataGridViewRow row in ScoresView.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToInt32(row.Cells[0].Value) == idPartidaReciente)
                    {
                        row.Selected = true;
                        partidaSeleccionada = idPartidaReciente;
                        CargarDetalle(idPartidaReciente);
                        break;
                    }
                }
            }
        }

        async void CargarHistorial()
        {
            try
            {
                string url = $"{API_BASE_URL}/games/?limit=20";

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener historial");
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();

                var historial = JsonSerializer.Deserialize<List<HistorialAPI>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                ScoresView.Columns.Clear();
                ScoresView.Rows.Clear();

                ScoresView.Columns.Add("ID_Partida", "ID");
                ScoresView.Columns.Add("Jugador", "Jugador");
                ScoresView.Columns.Add("Categoria", "Categoría");
                ScoresView.Columns.Add("Puntaje", "Puntaje");

                foreach (var item in historial)
                {
                    ScoresView.Rows.Add(
                        item.ID_Partida,
                        item.Nombre,
                        item.Categoria,
                        item.Puntaje
                    );
                }

                ScoresView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ScoresView.ReadOnly = true;
                ScoresView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ScoresView.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        async void CargarDetalle(int idPartida)
        {
            preguntas.Clear();
            resultadosLista.Clear();

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
                    resultadosLista.Add(d.Es_Acierto);
                }

                scrollY = 0;
                this.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detalle: " + ex.Message);
            }
        }

        private void ScoresView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ScoresView.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int idPartida = Convert.ToInt32(ScoresView.Rows[e.RowIndex].Cells[0].Value);

                historial detalle = new historial(idPartida);
                detalle.ShowDialog();
            }
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Show();
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (partidaSeleccionada != -1 && preguntas.Count > 0)
            {
                Graphics g = e.Graphics;

                int detalleX = this.Width - 450;
                int detalleY = lblScore.Bottom + 20;
                int detalleAncho = 430;
                int detalleAlto = this.Height - detalleY - 20;

                g.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), detalleX, detalleY, detalleAncho, detalleAlto);
                g.DrawRectangle(Pens.Gray, detalleX, detalleY, detalleAncho, detalleAlto);

                g.DrawString($"Detalle Partida #{partidaSeleccionada}",
                    new Font("Segoe UI", 14, FontStyle.Bold),
                    Brushes.DarkBlue,
                    detalleX + 10, detalleY + 10);

                int aciertos = resultadosLista.FindAll(r => r).Count;
                int errores = preguntas.Count - aciertos;

                g.DrawString($"✅ {aciertos}   ❌ {errores}",
                    new Font("Segoe UI", 10, FontStyle.Bold),
                    Brushes.Black,
                    detalleX + 10, detalleY + 50);

                Rectangle clipRect = new Rectangle(detalleX + 5, detalleY + 80, detalleAncho - 10, detalleAlto - 100);
                g.SetClip(clipRect);

                int y = detalleY + 80 - scrollY;

                for (int i = 0; i < preguntas.Count; i++)
                {
                    bool acierto = resultadosLista[i];
                    Color color = acierto ? Color.Green : Color.Red;

                    string estado = acierto ? "Correcta" : "Incorrecta";
                    string texto = $"{i + 1}. {preguntas[i]} [{estado}]";

                    g.DrawString(texto, new Font("Segoe UI", 9), new SolidBrush(color), detalleX + 15, y);

                    y += 28;
                }

                g.ResetClip();

                if (preguntas.Count > 12)
                {
                    g.DrawString("Usa la rueda del mouse",
                        new Font("Segoe UI", 8),
                        Brushes.Gray,
                        detalleX + 10, detalleY + detalleAlto - 25);
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (partidaSeleccionada != -1 && preguntas.Count > 0)
            {
                int areaAltura = this.Height - (lblScore.Bottom + 120);
                maxScroll = Math.Max(0, (preguntas.Count * 28) - areaAltura);

                scrollY -= e.Delta / 3;
                scrollY = Math.Max(0, Math.Min(scrollY, maxScroll));

                this.Invalidate();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Inicio inicio = new Inicio();
                inicio.Show();
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }

        public class HistorialAPI
        {
            public int ID_Partida { get; set; }
            public string Nombre { get; set; }
            public string Categoria { get; set; }
            public int Puntaje { get; set; }
        }

        public class DetalleAPI
        {
            public string Enunciado { get; set; }
            public bool Es_Acierto { get; set; }
        }
    }
}