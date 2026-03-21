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
    public partial class resultados : Form
    {
        int score;
        int total;
        int idPartidaReciente;

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

        public resultados(int scoreFinal, int totalPreguntas, string nombreJugador, int idPartida)
        {
            InitializeComponent();

            score = scoreFinal;
            total = totalPreguntas;
            idPartidaReciente = idPartida;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            ConfigurarDataGridView();

            MostrarResultado();
            CargarHistorial();
        }

        void ConfigurarDataGridView()
        {
            ScoresView.Dock = DockStyle.Fill;
            ScoresView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ScoresView.ReadOnly = true;
            ScoresView.AllowUserToAddRows = false;
            ScoresView.AllowUserToDeleteRows = false;
            ScoresView.RowHeadersVisible = false;
            ScoresView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            ScoresView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        void CargarHistorial()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
                {
                    conn.Open();

                    string query = @"SELECT p.ID_Partida as 'ID Partida',
                             CONCAT(j.Nombre, ' (', c.Nombre, ')') AS 'Jugador (Categoría)',
                             p.Puntaje AS 'Puntuación'
                             FROM partida p 
                             JOIN jugador j ON p.ID_Jugador = j.ID_Jugador 
                             JOIN categoria c ON p.ID_Cat = c.ID_Cat 
                             ORDER BY p.Puntaje DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    ScoresView.DataSource = dt;

                    ResaltarPartida();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        void ResaltarPartida()
        {
            this.BeginInvoke(new MethodInvoker(() =>
            {
                foreach (DataGridViewRow row in ScoresView.Rows)
                {
                    if (row.Cells["ID Partida"].Value != null)
                    {
                        if (Convert.ToInt32(row.Cells["ID Partida"].Value) == idPartidaReciente)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            row.DefaultCellStyle.Font = new Font(ScoresView.Font, FontStyle.Bold);

                            ScoresView.FirstDisplayedScrollingRowIndex = row.Index;
                            break;
                        }
                    }
                }
            }));
        }

        void MostrarResultado()
        {
            lblScore.Text = "Score: " + score + " / " + total;
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            Inicio i = new Inicio();
            i.Show();
            this.Close();
        }

        private void ScoresView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}