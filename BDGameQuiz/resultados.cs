using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDGameQuiz
{
    public partial class resultados : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://192.168.56.1:8080";

        int score;
        int total;
        int idPartidaReciente;
        string nombreJugador;

        int salaId;
        int jugadorId;

        bool todosListos = false;
        Timer timerEstado;

		public resultados(int scoreFinal, int totalPreguntas, string nombreJugador, int idPartida, int salaId, int jugadorId)
		{
			InitializeComponent();

			this.score = scoreFinal;
			this.total = totalPreguntas;
			this.nombreJugador = nombreJugador;

			this.WindowState = FormWindowState.Maximized;
			this.DoubleBuffered = true;


			int porcentaje = total > 0 ? (score * 100 / total) : 0;

			lblScore.Text = $"{nombreJugador}\n{score}/{total} puntos\n{porcentaje}% de aciertos";
			lblScore.TextAlign = ContentAlignment.MiddleCenter;
			lblScore.Height = 200;

			this.Load += (s, e) =>
			{
				lblScore.Left = (this.ClientSize.Width - lblScore.Width) / 2;
				lblScore.Top = (this.ClientSize.Height - lblScore.Height) / 2 - 100;

				btnMenu.Left = (this.ClientSize.Width - btnMenu.Width) / 2;
				btnMenu.Top = lblScore.Bottom + 40;
			};
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

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
			Inicio inicio = new Inicio();
			inicio.Show();
			this.Close();
		}
    }
}