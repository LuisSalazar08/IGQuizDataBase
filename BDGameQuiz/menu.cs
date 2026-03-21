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
        string nombreJugador;
        int idJugador;

        class Categoria
        {
            public int Id;
            public string Nombre;
        }

        List<Categoria> categorias = new List<Categoria>();

        Button[] botonesCategorias;


        public menu(string nombre, int id)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            nombreJugador = nombre;
            idJugador = id;

            botonesCategorias = new Button[]
            {
                button1,button2,button3,button4,button5,button6,button7
            };

            CargarCategorias();
        }

        void CargarCategorias()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
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

        void Categoria_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            int idCategoria = (int)b.Tag;

            juego j = new juego(idCategoria, idJugador, nombreJugador);

            j.Show();

            this.Hide();
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

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
