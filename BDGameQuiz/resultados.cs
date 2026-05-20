using System;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace BDGameQuiz
{
    public partial class resultados : Form
    {
        int score;
        int total;
        int salaId;
        int jugadorId;
        string nombreJugador;
        bool todosListos = false;
        string ganador;
        int puntajeGanador;

        public resultados(int scoreFinal, int totalPreguntas, string nombreJugador,int idPartida, int salaId, int jugadorId,string ganador, int puntajeGanador)
		{
			InitializeComponent();

			this.score = scoreFinal;
			this.total = totalPreguntas;
			this.nombreJugador = nombreJugador;
            this.ganador = ganador;
            this.puntajeGanador = puntajeGanador; 

            this.WindowState = FormWindowState.Maximized;
			this.DoubleBuffered = true;


			int porcentaje = total > 0 ? (score * 100 / total) : 0;

            lblScore.Text = $"{nombreJugador}\n{score}/{total} puntos\n{porcentaje}% de aciertos\n\nGanador: {ganador} ({puntajeGanador} pts)";
            lblScore.TextAlign = ContentAlignment.MiddleCenter;
			lblScore.Height = 200;

			this.Load += (s, e) =>
			{
				lblScore.Left = (this.ClientSize.Width - lblScore.Width) / 2;
				lblScore.Top = (this.ClientSize.Height - lblScore.Height) / 2 - 100;

				btnMenu.Left = (this.ClientSize.Width - btnMenu.Width) / 2;
				btnMenu.Top = lblScore.Bottom + 80;
			};
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

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            

            Inicio inicio = new Inicio();

            inicio.Show();

            this.Close();
        }
    }
}