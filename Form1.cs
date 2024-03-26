namespace pryLopezS
{
    public partial class Form1 : Form
    {
        private Point startPoint;
        private Point endPoint;
        private List<Point> points = new List<Point>();
        private bool drawing = false;
        private List<List<Point>> drawings = new List<List<Point>>();
        private List<Point> currentDrawing = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.Paint += PictureBox1_Paint;
            buttonSave.Click += ButtonSave_Click;
            buttonClear.Click += ButtonClear_Click;
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Iniciar el dibujo y registrar el primer punto
            drawing = true;
            points.Add(e.Location);
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Si se está dibujando, registrar el punto actual
            if (drawing)
            {
                points.Add(e.Location);
                pictureBox1.Invalidate(); // Invalidar el PictureBox para forzar un repintado
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Finalizar el dibujo
            drawing = false;
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
            // Guardar el dibujo actual en un vector o hacer lo que desees con él
            // En este ejemplo, simplemente lo agregamos al vector de dibujos
            drawings.Add(new List<Point>(currentDrawing));
            currentDrawing.Clear();
            pictureBox1.Invalidate(); // Invalidar el PictureBox para forzar un repintado y borrar el dibujo actual
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            // Borrar todos los dibujos y limpiar el PictureBox
            drawings.Clear();
            currentDrawing.Clear();
            pictureBox1.Invalidate(); // Invalidar el PictureBox para forzar un repintado y borrar el dibujo actual
        }
    }
}