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
    public partial class juego : Form
    {
        List<Pregunta> preguntas = new List<Pregunta>();

        int indicePregunta = 0;
        int score = 0;
        int totalPreguntas = 14;

        public juego(int cat)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            CargarPreguntas();
        }

        void CargarPreguntas()
        {
            preguntas.Add(new Pregunta
            {
                Enunciado = "What is the capital of France?",
                Opciones = new string[] { "Paris", "Madrid", "Rome", "Berlin" },
                Correcta = 0
            });

            preguntas.Add(new Pregunta
            {
                Enunciado = "2 + 2 = ?",
                Opciones = new string[] { "3", "4", "5", "6" },
                Correcta = 1
            });

            MostrarPregunta();
        }

        void MostrarPregunta()
        {
            var p = preguntas[indicePregunta];

            lblPregunta.Text = p.Enunciado;

            btn1.Text = p.Opciones[0];
            btn2.Text = p.Opciones[1];
            btn3.Text = p.Opciones[2];
            btn4.Text = p.Opciones[3];
        }

        void Responder(int opcion)
        {
            if (opcion == preguntas[indicePregunta].Correcta)
            {
                score++;
            }

            indicePregunta++;

            if (indicePregunta < preguntas.Count)
            {
                MostrarPregunta();
            }
            else
            {
                TerminarJuego();
            }
        }

        void TerminarJuego()
        {
            resultados r = new resultados(score, preguntas.Count);
            r.Show();

            this.Close();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Responder(0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Responder(1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Responder(2);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Responder(3);
        }
    }
}
