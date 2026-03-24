using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

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

        Image flechaImg;
        Image fondoCache;

        Font fontTitulo = new Font("Times New Roman", 48, FontStyle.Bold);
        Font fontCategoria = new Font("Times New Roman", 36, FontStyle.Bold);

        StringFormat sfCentro = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        public menu(string nombre, int id)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            this.DoubleBuffered = true;
            this.KeyPreview = true;

            nombreJugador = nombre;
            idJugador = id;

            this.Controls.Clear();

            flechaImg = Properties.Resources.flecha;
            fondoCache = CrearFondoConOpacidad(Properties.Resources.fondo, 0.9f);

            this.Load += (s, e) =>
            {
                CalcularRectangulos();
                this.Invalidate();
            };

            this.Resize += (s, e) =>
            {
                CalcularRectangulos();
                this.Invalidate();
            };

            CargarCategorias();
        }

        Image CrearFondoConOpacidad(Image original, float opacidad)
        {
            Bitmap bmp = new Bitmap(original.Width, original.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacidad;

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix);

                g.DrawImage(original,
                    new Rectangle(0, 0, bmp.Width, bmp.Height),
                    0, 0, original.Width, original.Height,
                    GraphicsUnit.Pixel,
                    attributes);
            }

            return bmp;
        }

        void CargarCategorias()
        {
            categorias.Clear();

            using (MySqlConnection conn = new MySqlConnection("Server=127.0.0.1;Database=pruebaproyecto;User ID=root;Password=Furay1214@;"))
            {
                conn.Open();

                string query = "SELECT * FROM categoria LIMIT 7";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        categorias.Add(new Categoria
                        {
                            Id = Convert.ToInt32(dr["ID_Cat"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
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

            int anchoCentro = 560;
            int altoCentro = 200;
            int posYCentro = (int)(h * 0.55) - (altoCentro / 2);

            rectCentro = new Rectangle(
                (w - anchoCentro) / 2,
                posYCentro,
                anchoCentro,
                altoCentro
            );

            int anchoFlecha = 110;
            int altoFlecha = 200;
            int separacion = 18;

            rectIzquierda = new Rectangle(
                rectCentro.Left - separacion - anchoFlecha,
                rectCentro.Top,
                anchoFlecha,
                altoFlecha
            );

            rectDerecha = new Rectangle(
                rectCentro.Right + separacion,
                rectCentro.Top,
                anchoFlecha,
                altoFlecha
            );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.DrawImage(fondoCache,
                new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            if (categorias.Count == 0) return;

            int w = this.ClientSize.Width;

            g.DrawString("Seleccione Categoria:",
                fontTitulo,
                Brushes.Black,
                new Rectangle(0, 90, w, 120),
                sfCentro);

            using (Brush sombra = new SolidBrush(Color.FromArgb(35, Color.Black)))
            {
                g.FillRectangle(sombra,
                    new Rectangle(rectCentro.X + 6, rectCentro.Y + 6, rectCentro.Width, rectCentro.Height));
            }

            Brush brushCentro = (hoverRect == rectCentro) ? Brushes.LightGray : Brushes.WhiteSmoke;

            g.FillRectangle(brushCentro, rectCentro);
            g.DrawRectangle(Pens.Black, rectCentro);

            g.DrawString(categorias[indiceActual].Nombre,
                fontCategoria,
                Brushes.Black,
                rectCentro,
                sfCentro);

            DibujarFlecha(g, rectIzquierda, hoverRect == rectIzquierda, true);
            DibujarFlecha(g, rectDerecha, hoverRect == rectDerecha, false);
        }

        void DibujarFlecha(Graphics g, Rectangle rect, bool hover, bool izquierda)
        {
            if (flechaImg == null) return;

            if (hover)
            {
                using (Brush glow = new SolidBrush(Color.FromArgb(35, Color.White)))
                {
                    g.FillEllipse(glow, rect.X - 8, rect.Y - 8, rect.Width + 16, rect.Height + 16);
                }

                this.Cursor = Cursors.Hand;
            }

            Rectangle drawRect = hover ? Rectangle.Inflate(rect, -8, -8) : rect;

            if (izquierda)
            {
                var state = g.Save();
                g.TranslateTransform(drawRect.Right, drawRect.Top);
                g.ScaleTransform(-1, 1);
                g.DrawImage(flechaImg, 0, 0, drawRect.Width, drawRect.Height);
                g.Restore(state);
            }
            else
            {
                g.DrawImage(flechaImg, drawRect);
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            Rectangle nuevoHover = Rectangle.Empty;

            if (rectCentro.Contains(e.Location)) nuevoHover = rectCentro;
            else if (rectIzquierda.Contains(e.Location)) nuevoHover = rectIzquierda;
            else if (rectDerecha.Contains(e.Location)) nuevoHover = rectDerecha;

            if (hoverRect != nuevoHover)
            {
                hoverRect = nuevoHover;
                this.Invalidate();
            }

            if (hoverRect == Rectangle.Empty)
                this.Cursor = Cursors.Default;
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (categorias.Count == 0) return;

            if (rectCentro.Contains(e.Location))
                SeleccionarCategoria();
            else if (rectIzquierda.Contains(e.Location))
            {
                indiceActual = (indiceActual - 1 + categorias.Count) % categorias.Count;
                this.Invalidate();
            }
            else if (rectDerecha.Contains(e.Location))
            {
                indiceActual = (indiceActual + 1) % categorias.Count; // 🔥 FIX AQUÍ
                this.Invalidate();
            }
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
                if (MessageBox.Show("Quieres Salir del Juego?", "Exit",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}