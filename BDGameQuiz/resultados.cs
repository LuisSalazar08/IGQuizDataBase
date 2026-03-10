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
    public partial class resultados : Form
    {
        int score;
        int total;

        public resultados(int scoreFinal, int totalPreguntas)
        {
            InitializeComponent();

            score = scoreFinal;
            total = totalPreguntas;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            MostrarResultado();
        }

        void MostrarResultado()
        {
            lblScore.Text = "Score: " + score + " / " + total;
        }

        private void btnMenu_Click_1(object sender, EventArgs e)
        {
            menu m = new menu();
            m.Show();
            this.Close();
        }
    }
}
