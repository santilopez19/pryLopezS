
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Runtime.InteropServices;

namespace pryLopezS
{
    public partial class Form1 : Form
    {

        private Point previousPoint;
        private List<Point> points = new List<Point>();
        private bool drawing = false;
        private bool isDrawing = false;
        private List<List<Point>> drawings = new List<List<Point>>();
        private List<Point> currentDrawing = new List<Point>();
        private Bitmap drawingBitmap;

        public Form1()
        {
            InitializeComponent();
            InitializeDrawing();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.Paint += PictureBox1_Paint;
            buttonSave.Click += ButtonSave_Click;
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Iniciar el dibujo y registrar el primer punto
            drawing = true;
            points.Add(e.Location);
            isDrawing = true;
            previousPoint = e.Location;
        }
        private void InitializeDrawing()
        {
            drawingBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = drawingBitmap;
            Graphics.FromImage(drawingBitmap).Clear(Color.White);
        }
        public void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Si se está dibujando, registrar el punto actual
            if (drawing)
            {
                using (Graphics g = Graphics.FromImage(drawingBitmap))
                {
                    g.DrawLine(Pens.Black, previousPoint, e.Location);
                }
                previousPoint = e.Location;
                pictureBox1.Invalidate();
                points.Add(e.Location);
                pictureBox1.Invalidate(); // Invalidar el PictureBox para forzar un repintado
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Finalizar el dibujo
            drawing = false;
            isDrawing = false;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Dibujar líneas conectando todos los puntos registrados
            if (points.Count > 1)
            {
                e.Graphics.DrawLines(Pens.Black, points.ToArray());
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Archivo de imagen (*.png)|*.png";
            saveFileDialog1.Title = "Guardar imagen como";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                drawingBitmap.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }


        private void ButtonClear_Click(object sender, EventArgs e, PictureBox pictureBox1)
        {
            Graphics g = Graphics.FromImage(this.pictureBox1.Image);
            g.Clear(this.pictureBox1.BackColor);
        }
    }
}