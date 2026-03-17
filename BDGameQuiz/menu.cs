using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDGameQuiz
{
    public partial class menu : Form
    {
        class Categoria
        {
            public int Id;
            public string Nombre;
        }

        List<Categoria> categorias = new List<Categoria>();

        Button[] botonesCategorias;


        public menu()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            botonesCategorias = new Button[]
            {
                button1,button2,button3,button4,button5,button6,button7
            };

            CargarCategorias();
        }

        void CargarCategorias()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
            {
                conn.Open();

                string query = "SELECT * FROM categoria LIMIT 7";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader dr = cmd.ExecuteReader();

                int i = 0;

                while (dr.Read() && i < botonesCategorias.Length)
                {
                    botonesCategorias[i].Text = dr["Nombre"].ToString();
                    botonesCategorias[i].Tag = Convert.ToInt32(dr["ID_Cat"]);

                    botonesCategorias[i].Click += Categoria_Click;

                    i++;
                }
            }
        }

        int ObtenerIdJugador(string nombre)
        {
            int id = 0;

            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
            {
                conn.Open();

                string query = "SELECT ID_Jugador FROM jugador WHERE Nombre=@nombre";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return id;
        }

        void Categoria_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            int idCategoria = (int)b.Tag;
            string nombreJugador = nameTextBox.Text;
            int idJugador = ObtenerIdJugador(nombreJugador);

            if (nameTextBox.Text.Trim() == "")
            {
                MessageBox.Show("Por favor ingresa tu nombre antes de comenzar.",
                                "Nombre requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                nameTextBox.Focus();
                return;
            }

            GuardarJugador(nombreJugador);

            juego j = new juego(idCategoria, idJugador, nombreJugador);

            j.Show();

            this.Hide();
        }

        void GuardarJugador(string nombre)
        {
            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
