using System;
using System.Collections.Generic;
using System.Drawing;
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

        int indiceActual = 0;

        Rectangle rectCentro;
        Rectangle rectIzquierda;
        Rectangle rectDerecha;

        Rectangle hoverRect = Rectangle.Empty;

        public menu(string nombre, int id)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;

            nombreJugador = nombre;
            idJugador = id;

            this.Controls.Clear();

            this.Load += (s, e) => {
                CalcularRectangulos();
                this.Invalidate();
            };

            this.Resize += (s, e) => {
                CalcularRectangulos();
                this.Invalidate();
            };

            CargarCategorias();
        }

        void CargarCategorias()
        {
            categorias.Clear();

            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=RootRoot;"))
            {
                conn.Open();

                string query = "SELECT * FROM categoria LIMIT 7";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    categorias.Add(new Categoria
                    {
                        Id = Convert.ToInt32(dr["ID_Cat"]),
                        Nombre = dr["Nombre"].ToString()
                    });
                }
            }

            if (categorias.Count == 0)
            {
                MessageBox.Show("No hay categorías disponibles");
                return;
            }

            indiceActual = 0;
        }

        void CalcularRectangulos()
        {
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            int anchoCentro = 400;
            int altoCentro = 150;

            rectCentro = new Rectangle(
                (w - anchoCentro) / 2,
                (h - altoCentro) / 2,
                anchoCentro,
                altoCentro
            );

            rectIzquierda = new Rectangle(
                rectCentro.Left - 80,
                rectCentro.Top,
                60,
                altoCentro
            );

            rectDerecha = new Rectangle(
                rectCentro.Right + 20,
                rectCentro.Top,
                60,
                altoCentro
            );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.Clear(Color.Turquoise);

            if (categorias == null || categorias.Count == 0)
                return;

            StringFormat sf = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            int w = this.ClientSize.Width;

            g.DrawString("Seleccione Categoria:",
                new Font("Times New Roman", 32, FontStyle.Italic),
                Brushes.Black,
                new Rectangle(0, 50, w, 100),
                sf);

            Brush brushCentro = (hoverRect == rectCentro) ? Brushes.LightGray : Brushes.WhiteSmoke;

            g.FillRectangle(brushCentro, rectCentro);
            g.DrawRectangle(Pens.Black, rectCentro);

            g.DrawString(categorias[indiceActual].Nombre,
                new Font("Times New Roman", 22, FontStyle.Italic),
                Brushes.Black,
                rectCentro,
                sf);

            Brush brushIzq = (hoverRect == rectIzquierda) ? Brushes.LightGray : Brushes.WhiteSmoke;

            g.FillRectangle(brushIzq, rectIzquierda);
            g.DrawRectangle(Pens.Black, rectIzquierda);

            g.DrawString("<",
                new Font("Arial", 30, FontStyle.Bold),
                Brushes.Black,
                rectIzquierda,
                sf);

            Brush brushDer = (hoverRect == rectDerecha) ? Brushes.LightGray : Brushes.WhiteSmoke;

            g.FillRectangle(brushDer, rectDerecha);
            g.DrawRectangle(Pens.Black, rectDerecha);

            g.DrawString(">",
                new Font("Arial", 30, FontStyle.Bold),
                Brushes.Black,
                rectDerecha,
                sf);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (categorias.Count == 0) return;

            if (rectCentro.Contains(e.Location))
            {
                SeleccionarCategoria();
            }
            else if (rectIzquierda.Contains(e.Location))
            {
                indiceActual--;
                if (indiceActual < 0)
                    indiceActual = categorias.Count - 1;

                this.Invalidate();
            }
            else if (rectDerecha.Contains(e.Location))
            {
                indiceActual++;
                if (indiceActual >= categorias.Count)
                    indiceActual = 0;

                this.Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (rectCentro.Contains(e.Location)) hoverRect = rectCentro;
            else if (rectIzquierda.Contains(e.Location)) hoverRect = rectIzquierda;
            else if (rectDerecha.Contains(e.Location)) hoverRect = rectDerecha;
            else hoverRect = Rectangle.Empty;

            this.Invalidate();
        }

        void SeleccionarCategoria()
        {
            int idCategoria = categorias[indiceActual].Id;

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
    }
}