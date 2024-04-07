using System.Windows.Forms;
using System.Drawing;
namespace pryLopezS
{
    public partial class Galaga : Form
    {
        // Velocidad de movimiento de la nave
        private int pictureBoxSpeed = 10;
        //bala
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int velocidadBala = 10;
        private PictureBox bala;

        public Galaga()
        {   
            InitializeComponent();
            // Configurar el Nave
            nave.BackColor = System.Drawing.Color.Transparent;
            nave.Size = new System.Drawing.Size(50, 50);
            nave.Location = new System.Drawing.Point(320, 420);
            this.Controls.Add(nave);


            // Suscribirse a los eventos KeyDown y KeyUp
            this.KeyDown += Movernave_KeyDown;
            this.KeyUp += Form1_KeyUp;

            // Configurar el Timer
            timer.Interval = 10; // Intervalo en milisegundos

            //bala

            KeyPreview = true;
            KeyDown += bala_KeyDown;
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
        private void bala_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                // Crea la bala
                bala = new PictureBox();
                bala.Image = Properties.Resources.bala; // Asigna la imagen de la bala
                bala.BackColor = System.Drawing.Color.Transparent;
                bala.Size = new Size(10, 20);
                bala.SizeMode = PictureBoxSizeMode.StretchImage;
                // Establecer la posición inicial de la bala en la misma posición que la nave
                bala.Location = new Point(nave.Location.X + nave.Width / 2 - bala.Width / 2, nave.Location.Y);

                // Agregar el PictureBox al formulario
                Controls.Add(bala);

                // Inicia la animación de la bala
                timer.Tick += (sender, e) =>
                {
                    bala.Top -= velocidadBala; // Mueve la bala hacia arriba

                    // Si la bala sale de la pantalla, se detiene y se elimina
                    if (bala.Top + bala.Height < 0)
                    {
                        timer.Tick -= (EventHandler)sender;
                        Controls.Remove(bala);
                        bala.Dispose();
                    }
                };
            }
        }
    }
}