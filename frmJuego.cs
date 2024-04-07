using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System;
using static System.Windows.Forms.DataFormats;
using pryProyectoNave;
namespace pryLopezS
{
    public partial class Galaga : Form
    {
        // Velocidad de movimiento de la nave
        private int pictureBoxSpeed = 10;


        //Nave Enemiga
        public static Galaga Instance { get; private set; }
        private List<NaveEnemiga> navesEnemigas;

        //Bala




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



            ///Naves Enemigas
            Instance = this;
            InicializarNavesEnemigas();

        }
        public void Form1_Load(object sender, EventArgs e)
        {
        }



        //Nave
        public void Movernave_KeyDown(object sender, KeyEventArgs e)
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
        public void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // Restablecer la velocidad de movimiento cuando se suelta la tecla
            nave.Left += 0;
        }
        //Nave Enemiga

        private void InicializarNavesEnemigas()
        {
            navesEnemigas = new List<NaveEnemiga>();
            for (int i = 0; i < 8; i++)
            {
                int x = 100 + i * 100;
                int y = 50;
                int width = 50;
                int height = 50;
                Image imagen = Properties.Resources.naveEnemiga1;

                NaveEnemiga naveEnemiga = new NaveEnemiga(x, y, width, height, imagen);
                navesEnemigas.Add(naveEnemiga);
                Controls.Add(naveEnemiga.PictureBox);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            foreach (var nave in navesEnemigas)
            {
                nave.Mover();
            }
        }
    }
}