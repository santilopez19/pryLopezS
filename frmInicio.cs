using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace pryLopezS
{
    public partial class frmInicio : Form
    {

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private bool labelVisible = true;

        public frmInicio()
        {
            InitializeComponent();

            // Configurar el Timer
            timer.Interval = 700; // Intervalo en milisegundos (0.7 segundos)
            timer.Tick += Timer_Tick;
            timer.Start(); // Iniciar el Timer


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Alternar la visibilidad del Label
            lblStart.Visible = labelVisible;
            labelVisible = !labelVisible;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Asigna el evento KeyDown al formulario
            this.KeyDown += Form1_KeyDown;

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Verifica si la tecla presionada es la barra espaciadora
            if (e.KeyCode == Keys.Space)
            {
                // Crea una instancia del formulario Form2 y muéstralo
                Galaga Form1 = new Galaga();
                Form1.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
