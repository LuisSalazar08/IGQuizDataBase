using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDGameQuiz
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            button1.Enabled = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreJugador = nameTextBox.Text;
            GuardarJugador(nombreJugador);
            int idJugador = ObtenerIdJugador(nombreJugador);



            menu m = new menu(nombreJugador, idJugador);

            m.Show();
            this.Hide();
        }

        int ObtenerIdJugador(string nombre)
        {
            int id = 0;

            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
            {
                conn.Open();

                string query = "SELECT ID_Jugador FROM jugador WHERE Nombre=@nombre";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return id;
        }

        void GuardarJugador(string nombre)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM jugador WHERE Nombre = @nombre";

                MySqlCommand cmd = new MySqlCommand(check, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                int existe = Convert.ToInt32(cmd.ExecuteScalar());

                if (existe == 0)
                {
                    string insert = "INSERT INTO jugador (Nombre) VALUES (@nombre)";

                    MySqlCommand cmdInsert = new MySqlCommand(insert, conn);
                    cmdInsert.Parameters.AddWithValue("@nombre", nombre);
                    cmdInsert.ExecuteNonQuery();
                }
            }
        }


        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(nameTextBox.Text);
        }
    }
}
