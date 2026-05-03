using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        int salaId;
        int jugadorId;

        bool todosListos = false;
        Timer timerEstado;

        public resultados(int scoreFinal, int totalPreguntas, string nombreJugador, int idPartida, int salaId, int jugadorId)
        {
            InitializeComponent();

            this.score = scoreFinal;
            this.total = totalPreguntas;
            this.nombreJugador = nombreJugador;
            this.idPartidaReciente = idPartida;

            this.salaId = salaId;
            this.jugadorId = jugadorId;

            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;

            int porcentaje = (score * 100 / total);
            lblScore.Text = $"{nombreJugador}\n{score}/{total} puntos\n{porcentaje}% de aciertos";

            this.Load += (s, e) =>
            {
                CargarResultadosSala();
            };

            IniciarPollingEstado();
        }

        // ESPERAR A TODOS
        private void IniciarPollingEstado()
        {
            timerEstado = new Timer();
            timerEstado.Interval = 1500;

            timerEstado.Tick += async (s, e) =>
            {
                await VerificarEstadoSala();
            };

            timerEstado.Start();
        }

        private async Task VerificarEstadoSala()
        {
            try
            {
                var res = await httpClient.GetAsync($"{API_BASE_URL}/rooms/{salaId}/status");

                if (!res.IsSuccessStatusCode) return;

                var json = await res.Content.ReadAsStringAsync();

                var estado = JsonSerializer.Deserialize<EstadoSala>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (estado == null) return;

                if (estado.estado == "finalizado")
                {
                    todosListos = true;
                }
            }
            catch { }
        }

        // RESULTADOS DE LA SALA
        async void CargarResultadosSala()
        {
            try
            {
                string url = $"{API_BASE_URL}/rooms/{salaId}/results";

                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al obtener resultados");
                    return;
                }

                string json = await response.Content.ReadAsStringAsync();

                var lista = JsonSerializer.Deserialize<List<ResultadoSalaAPI>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                ScoresView.Columns.Clear();
                ScoresView.Rows.Clear();

                ScoresView.Columns.Add("ID", "ID");
                ScoresView.Columns.Add("Jugador", "Jugador");
                ScoresView.Columns.Add("Puntaje", "Puntaje");
                ScoresView.Columns.Add("Total", "Total");

                int posicion = 1;

                foreach (var item in lista)
                {
                    int rowIndex = ScoresView.Rows.Add(
                        item.id_partida,
                        $"{posicion}. {item.nombre}",
                        item.puntaje,
                        item.total
                    );

                    var fila = ScoresView.Rows[rowIndex];

                    if (posicion == 1)
                        fila.DefaultCellStyle.BackColor = Color.Gold;
                    else if (posicion == 2)
                        fila.DefaultCellStyle.BackColor = Color.Silver;
                    else if (posicion == 3)
                        fila.DefaultCellStyle.BackColor = Color.Peru;

                    posicion++;
                }

                ScoresView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ScoresView.ReadOnly = true;
                ScoresView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ScoresView.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // DETALLE (DOBLE CLICK)
        private void ScoresView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ScoresView.Rows[e.RowIndex].Cells[0].Value != null)
            {
                int idPartida = Convert.ToInt32(ScoresView.Rows[e.RowIndex].Cells[0].Value);

                historial detalle = new historial(idPartida);
                detalle.ShowDialog();
            }
        }

        // VOLVER AL LOBBY
        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            if (!todosListos)
            {
                MessageBox.Show("Espera a que todos los jugadores terminen");
                return;
            }

            Lobby lobby = new Lobby(salaId, jugadorId, false);
            lobby.Show();
            this.Close();
        }

        // ESC
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

        // MODELOS
        class ResultadoSalaAPI
        {
            public int id_partida { get; set; }
            public string nombre { get; set; }
            public int puntaje { get; set; }
            public int total { get; set; }
        }

        public class EstadoSala
        {
            public string estado { get; set; }
        }
    }
}