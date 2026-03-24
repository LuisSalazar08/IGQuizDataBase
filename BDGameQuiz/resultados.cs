using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BDGameQuiz
{
    public partial class resultados : Form
    {
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

            // Evento doble click
            ScoresView.CellDoubleClick += ScoresView_CellDoubleClick;

            CargarHistorial();

            // Seleccionar la partida reciente automáticamente
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

        void CargarHistorial()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
                {
                    conn.Open();

                    string query = @"
                    SELECT p.ID_Partida, 
                           j.Nombre AS Jugador,
                           c.Nombre AS Categoria,
                           CONCAT(p.Puntaje, '/14') AS Puntaje
                    FROM partida p
                    JOIN jugador j ON p.ID_Jugador = j.ID_Jugador
                    JOIN categoria c ON p.ID_Cat = c.ID_Cat
                    ORDER BY p.ID_Partida DESC
                    LIMIT 20";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    ScoresView.Columns.Clear();

                    // Columnas
                    ScoresView.Columns.Add("ID_Partida", "ID");
                    ScoresView.Columns.Add("Jugador", "Jugador");
                    ScoresView.Columns.Add("Categoria", "Categoría");
                    ScoresView.Columns.Add("Puntaje", "Puntaje");

                    // Llenar
                    foreach (System.Data.DataRow row in dt.Rows)
                    {
                        ScoresView.Rows.Add(
                            row["ID_Partida"],
                            row["Jugador"],
                            row["Categoria"],
                            row["Puntaje"]
                        );
                    }

                    ScoresView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    ScoresView.ReadOnly = true;
                    ScoresView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    ScoresView.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message);
            }
        }

        void CargarDetalle(int idPartida)
        {
            preguntas.Clear();
            resultadosLista.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
                {
                    conn.Open();

                    string query = @"
                        SELECT pr.Enunciado, dp.Es_Acierto
                        FROM detalle_partida dp
                        JOIN pregunta pr 
                        ON dp.ID_Preg = pr.ID_Preg AND dp.ID_Cat = pr.ID_Cat
                        WHERE dp.ID_Partida = @id
                        ORDER BY dp.ID_Detalle ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idPartida);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        preguntas.Add(dr["Enunciado"].ToString());
                        resultadosLista.Add(Convert.ToBoolean(dr["Es_Acierto"]));
                    }

                    dr.Close();
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
    }
}