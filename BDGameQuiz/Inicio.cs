using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
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
        }

        class Jugador
        {
            public int id { get; set; }
            public string nombre { get; set; }
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

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void NameLabel_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string nombreJugador = nameTextBox.Text;

            var jugador = await CrearOObtenerJugador(nombreJugador);

            menu m = new menu(jugador.nombre, jugador.id);

            m.Show();
            this.Hide();
        }

        async Task<Jugador> CrearOObtenerJugador(string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                var jugador = new { nombre = nombre };
                string json = JsonConvert.SerializeObject(jugador);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("http://10.103.151.175:8080/players", content);

                var responseJson = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Jugador>(responseJson);
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(nameTextBox.Text);
        }
    }
}