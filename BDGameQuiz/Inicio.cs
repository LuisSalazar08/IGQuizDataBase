using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace BDGameQuiz
{
    public partial class Inicio : Form
    {
        private const string API = "http://192.168.56.1:8080";

        public Inicio()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = global::BDGameQuiz.Properties.Resources.fondo;

            button1.Enabled = false;
            btnUnirse.Enabled = false;
        }

        class Jugador
        {
            public int id { get; set; }
            public string nombre { get; set; }
        }

        class SalaResponse
        {
            public int sala_id { get; set; }
        }

        private async void btnUnirse_Click_1(object sender, EventArgs e)
        {
            string nombreJugador = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Ingresa el ID de la sala");
                return;
            }

            if (!int.TryParse(textBox1.Text, out int salaId))
            {
                MessageBox.Show("ID de sala inválido");
                return;
            }

            var jugador = await CrearOObtenerJugador(nombreJugador);

            string result = await UnirseASala(salaId, jugador.id);

            if (result != "OK")
            {
                MessageBox.Show(result);
                return;
            }

            Lobby lobby = new Lobby(salaId, jugador.id, false);
            lobby.Show();
            this.Hide();
        }

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
                    Application.Exit();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        async Task<Jugador> CrearOObtenerJugador(string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                var jugador = new { nombre = nombre };

                string json = JsonConvert.SerializeObject(jugador);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{API}/players", content);

                var responseJson = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Jugador>(responseJson);
            }
        }

        async Task<SalaResponse> CrearSala(int jugadorId)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new { jugador_id = jugadorId };

                string json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{API}/rooms", content);

                var responseJson = await response.Content.ReadAsStringAsync();
                MessageBox.Show(responseJson);
                return JsonConvert.DeserializeObject<SalaResponse>(responseJson);
            }
        }

        async Task<string> UnirseASala(int salaId, int jugadorId)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new { jugador_id = jugadorId };

                string json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{API}/rooms/{salaId}/join", content);

                string body = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                    return "OK";

                return body;
            }
        }

        private void ValidarInputs()
        {
            bool nombreOk = !string.IsNullOrWhiteSpace(nameTextBox.Text);
            bool salaOk = !string.IsNullOrWhiteSpace(textBox1.Text);

            button1.Enabled = nombreOk;
            btnUnirse.Enabled = nombreOk && salaOk;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidarInputs();
        }

        private void txtSalaId_TextChanged(object sender, EventArgs e)
        {
            ValidarInputs();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
        }

        private void NameLabel_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string nombreJugador = nameTextBox.Text;

            var jugador = await CrearOObtenerJugador(nombreJugador);

            var sala = await CrearSala(jugador.id);

            Lobby lobby = new Lobby(sala.sala_id, jugador.id, true);
            lobby.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}