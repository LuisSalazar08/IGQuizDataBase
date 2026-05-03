using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDGameQuiz
{
    public partial class MenuCategorias : Form
    {
        private int salaId;
        private int jugadorId;

        private static readonly HttpClient http = new HttpClient();
        private const string API = "http://192.168.56.1:8080";

        private List<Categoria> categorias = new List<Categoria>();

        private int indiceActual = 0;

        private Rectangle rectCentro;
        private Rectangle rectIzquierda;
        private Rectangle rectDerecha;

        private Rectangle hoverRect = Rectangle.Empty;

        private readonly Font fontTitulo = new Font("Arial", 60, FontStyle.Bold);
        private readonly Font fontCategoria = new Font("Arial", 20, FontStyle.Bold);

        private Image flechaImg = Properties.Resources.flecha;

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
                    Application.Exit();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public MenuCategorias(int salaId, int jugadorId)
        {
            InitializeComponent();

            this.salaId = salaId;
            this.jugadorId = jugadorId;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackgroundImage = global::BDGameQuiz.Properties.Resources.fondo;

            this.DoubleBuffered = true;

            this.Resize += (s, e) => { CalcularLayout(); Invalidate(); };

            this.Load += async (s, e) =>
            {
                await CargarCategorias();
            };
        }

        private async Task CargarCategorias()
        {
            try
            {
                var res = await http.GetAsync($"{API}/categories");

                if (!res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al cargar categorías");
                    return;
                }

                var json = await res.Content.ReadAsStringAsync();

                categorias = JsonSerializer.Deserialize<List<Categoria>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                indiceActual = 0;

                CalcularLayout();
                Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CalcularLayout()
        {
            int w = ClientSize.Width;
            int h = ClientSize.Height;

            int anchoCentro = 500;
            int altoCentro = 120;
            int posYCentro = (int)(h * 0.55) - (altoCentro / 2);

            rectCentro = new Rectangle(
                (w - anchoCentro) / 2,
                posYCentro,
                anchoCentro,
                altoCentro
            );

            int anchoFlecha = 100;
            int altoFlecha = 120;
            int separacion = 20;

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

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (categorias.Count == 0) return;

            var sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            g.DrawString("Selecciona una categoría",
                fontTitulo,
                Brushes.White,
                new Rectangle(0, 80, ClientSize.Width, 80),
                sf);

            Brush brushCentro = (hoverRect == rectCentro) ? Brushes.LightGray : Brushes.WhiteSmoke;

            g.FillRectangle(brushCentro, rectCentro);
            g.DrawRectangle(Pens.Black, rectCentro);

            g.DrawString(categorias[indiceActual].nombre,
                fontCategoria,
                Brushes.Black,
                rectCentro,
                sf);

            DibujarFlecha(g, rectIzquierda, hoverRect == rectIzquierda, true);
            DibujarFlecha(g, rectDerecha, hoverRect == rectDerecha, false);
        }

        void DibujarFlecha(Graphics g, Rectangle rect, bool hover, bool izquierda)
        {
            if (flechaImg == null) return;

            Rectangle drawRect = hover ? Rectangle.Inflate(rect, -5, -5) : rect;

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
                Invalidate();
            }

            Cursor = (hoverRect == Rectangle.Empty) ? Cursors.Default : Cursors.Hand;
        }

        protected override async void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (categorias.Count == 0) return;

            if (rectCentro.Contains(e.Location))
            {
                await SeleccionarCategoria(categorias[indiceActual].id_cat);
            }
            else if (rectIzquierda.Contains(e.Location))
            {
                indiceActual = (indiceActual - 1 + categorias.Count) % categorias.Count;
                Invalidate();
            }
            else if (rectDerecha.Contains(e.Location))
            {
                indiceActual = (indiceActual + 1) % categorias.Count;
                Invalidate();
            }
        }

        private async Task SeleccionarCategoria(int categoriaId)
        {
            try
            {
                var data = new
                {
                    jugador_id = jugadorId,
                    categoria_id = categoriaId
                };

                string json = JsonSerializer.Serialize(data);

                var res = await http.PostAsync(
                    $"{API}/rooms/{salaId}/set-category",
                    new StringContent(json, Encoding.UTF8, "application/json")
                );

                if (!res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Error al elegir categoría");
                    return;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        class Categoria
        {
            public int id_cat { get; set; }
            public string nombre { get; set; }
        }

        public void MenuCategorias_Load(object sender, EventArgs e)
        {
            
        }
    }
}