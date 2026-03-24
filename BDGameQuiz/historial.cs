using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDGameQuiz
{
    public partial class historial : Form
    {
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

            CargarDetalle();
        }

        void CargarDetalle()
        {
            preguntas.Clear();
            resultados.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
                {
                    conn.Open();

                    string query = @"SELECT pr.Enunciado, dp.Es_Acierto
                        FROM detalle_partida dp
                        JOIN pregunta pr 
                        ON dp.ID_Preg = pr.ID_Preg 
                        AND dp.ID_Cat = pr.ID_Cat
                        WHERE dp.ID_Partida = @id
                        ORDER BY dp.ID_Detalle ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idPartida);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        preguntas.Add(dr["Enunciado"].ToString());
                        resultados.Add(Convert.ToBoolean(dr["Es_Acierto"]));
                    }

                    dr.Close();
                }

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
    }
}