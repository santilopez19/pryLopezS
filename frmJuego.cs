using System.Windows.Forms;
using System.Drawing;
namespace pryLopezS
{
    public partial class Galaga : Form
    {
        private int pictureBoxSpeed = 10; // Velocidad de movimiento del PictureBox
        //ball
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private PictureBox ball = new PictureBox();

        private int ballSpeed = 10;

        public Galaga()
        {   
            InitializeComponent();
            // Configurar el PictureBox
            nave.BackColor = System.Drawing.Color.Transparent;
            nave.Size = new System.Drawing.Size(50, 50);
            nave.Location = new System.Drawing.Point(320, 420);
            this.Controls.Add(nave);

            // Suscribirse a los eventos KeyDown y KeyUp
            this.KeyDown += Movernave_KeyDown;
            this.KeyUp += Form1_KeyUp;

            ball.KeyDown += Tirarbola_KeyDown; // Suscribirse al evento KeyDown de pictureBox1
            // Configurar el Timer
            timer.Interval = 10; // Intervalo en milisegundos
            timer.Tick += Timer_Tick;
        }
        public void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Movernave_KeyDown(object sender, KeyEventArgs e)
        {
            // Detectar las teclas presionadas y mover el PictureBox
            if (e.KeyCode == Keys.Left && nave.Left > 0)
            {
                nave.Left -= pictureBoxSpeed; // Mover hacia la izquierda
            }
            else if (e.KeyCode == Keys.Right && nave.Right < this.ClientSize.Width)
            {
                nave.Left += pictureBoxSpeed; // Mover hacia la derecha
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Restablecer la velocidad de movimiento cuando se suelta la tecla
            nave.Left += 0;
        }
        private void Tirarbola_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // Crear una nueva bola
                PictureBox ball = new PictureBox(); // Crear un nuevo PictureBox local
                ball.BackColor = Color.White;
                ball.Size = new Size(10, 10);
                ball.Location = new Point(ball.Location.X + ball.Width / 2 - ball.Width / 2, ball.Location.Y - ball.Height);
                this.Controls.Add(ball);

                // Iniciar el Timer para mover la bola
                timer.Start();
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Obtener la bola creada en PictureBox1_KeyDown
            PictureBox ball = (PictureBox)this.Controls[this.Controls.Count - 1];
            // Mover la bola en línea recta hacia arriba
            ball.Top -= ballSpeed;

            // Si la bola sale del formulario, detener el Timer y eliminar la bola
            if (ball.Top + ball.Height < 0)
            {
                timer.Stop();
                this.Controls.Remove(ball);
            }
        }
    }
}