using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;

namespace BDGameQuiz
{
    public partial class Inicio : Form
    {
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

        private async void button1_Click(object sender, EventArgs e)
        {
            await ConectarSocket();

            string nombreJugador = nameTextBox.Text;

            int jugadorId = await CrearOObtenerJugador(nombreJugador);

            int salaId = await CrearSala(jugadorId);

            Lobby lobby = new Lobby(salaId,
                jugadorId,
                true,
                nombreJugador
            );

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
                {
                    Conexion.Cerrar();

                    Application.Exit();
                }

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        private async Task<int> CrearOObtenerJugador(string nombre)
        {
            await Conexion.writer.WriteLineAsync($"CREATE_PLAYER|{nombre}");

            string respuesta = await Conexion.reader.ReadLineAsync();

            string[] partes = respuesta.Split('|');

            return int.Parse(partes[1]);
        }

        private async Task<int> CrearSala(int jugadorId)
        {
            await Conexion.writer.WriteLineAsync($"CREATE_ROOM|{jugadorId}");

            string respuesta = await Conexion.reader.ReadLineAsync();

            string[] partes = respuesta.Split('|');

            return int.Parse(partes[1]);
        }

        async Task<string> UnirseASala(int salaId, int jugadorId)
        {
            await Conexion.writer.WriteLineAsync($"JOIN_ROOM|{salaId}|{jugadorId}");

            string respuesta = await Conexion.reader.ReadLineAsync();

            return respuesta;
        }

        private void ValidarInputs()
        {
            bool nombreOk = !string.IsNullOrWhiteSpace(nameTextBox.Text);
            bool salaOk = !string.IsNullOrWhiteSpace(textBox1.Text);

            button1.Enabled = nombreOk;
            btnUnirse.Enabled = nombreOk && salaOk;
        }

        private async Task ConectarSocket()
        {
            if (Conexion.client != null && Conexion.client.Connected)
                return;

            Conexion.client = new TcpClient();

            await Conexion.client.ConnectAsync("192.168.56.1", 5000);

            NetworkStream stream = Conexion.client.GetStream();

            Conexion.reader = new StreamReader(stream);

            Conexion.writer = new StreamWriter(stream);

            Conexion.writer.AutoFlush = true;
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

        private async void btnUnirse_Click_1(object sender, EventArgs e)
        {
            await ConectarSocket();

            string nombreJugador = nameTextBox.Text;

            int jugadorId = await CrearOObtenerJugador(nombreJugador);

            int salaId = int.Parse(textBox1.Text);

            string result = await UnirseASala(salaId, jugadorId);

            if (result != "OK")
            {
                MessageBox.Show(result);
                return;
            }

            Lobby lobby = new Lobby(
                salaId,
                jugadorId,
                true,
                nombreJugador
            );

            lobby.Show();

            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}