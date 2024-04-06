
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace pryLopezS
{
    public partial class Form1 : Form
    {

        private Point previousPoint;
        private List<Point> points = new List<Point>();
        private bool isDrawing = false;
        private List<List<Point>> drawings = new List<List<Point>>();
        private List<Point> currentDrawing = new List<Point>();
        private Bitmap drawingBitmap;
        private Bitmap bitmap; // Bitmap utilizado para dibujar en el PictureBox
        private Graphics graphics; // Objeto Graphics para dibujar en el Bitmap

        public Form1()
        {
            InitializeComponent();
            InitializeDrawing();
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Iniciar el dibujo y registrar el primer punto
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
            if (isDrawing)
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
            // Obtener la fecha y hora actual
            DateTime now = DateTime.Now;

            // Crear el nombre de archivo usando la fecha y hora actual
            string fileName = $"{now:yyyyMMdd_HHmmss}.png"; // Puedes cambiar la extensión según el tipo de imagen

            // Directorio donde se guardarán las imágenes
            string directoryPath = @"C:\FIRMAS"; // Reemplaza con la ruta de tu carpeta

            // Comprobar si el directorio existe, si no, crearlo
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Combinar el directorio con el nombre de archivo para obtener la ruta completa
            string fullPath = Path.Combine(directoryPath, fileName);

            try
            {
                // Guardar la imagen (asumiendo que tienes un objeto de imagen llamado 'drawingBitmap' por ejemplo)
                drawingBitmap.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show("La imagen se ha guardado correctamente en la carpeta 'FIRMAS'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la imagen: {ex.Message}");
            }
        }



        private void buttonClear_Click(object sender, EventArgs e)
        {

            // Borra el dibujo actual creando un nuevo Bitmap y asignándolo al PictureBox
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height); // Crea un nuevo Bitmap vacío
            graphics = Graphics.FromImage(bitmap); // Inicializa el objeto Graphics con el nuevo Bitmap
            graphics.Clear(Color.White); // Limpia el bitmap con un color de fondo blanco
            pictureBox1.Image = bitmap; // Asigna el nuevo Bitmap al PictureBox
            InitializeDrawing();
        }
    }
}