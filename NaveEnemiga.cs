using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using pryLopezS;

namespace pryProyectoNave
{
    public class NaveEnemiga
    {
        public PictureBox PictureBox { get; set; }
        public Rectangle Hitbox => PictureBox.Bounds;

        private int velocidadX;

        public NaveEnemiga(int x, int y, int width, int height, Image imagen)
        {
            PictureBox = new PictureBox();
            PictureBox.Image = imagen;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            PictureBox.Bounds = new Rectangle(x, y, width, height);


            velocidadX = 1;

            PictureBox.BackColor = Color.Transparent;
            PictureBox.Parent = Galaga.Instance;
        }

        public void Mover()
        {

            PictureBox.Left += velocidadX;

            VerificarLimitesPantalla();
        }

        public void VerificarLimitesPantalla()
        {

            int formWidth = Galaga.Instance.ClientSize.Width;

            if (PictureBox.Right < 0)
            {
                PictureBox.Left = formWidth;
            }
            else if (PictureBox.Left > formWidth)
            {
                PictureBox.Left = -PictureBox.Width;
            }
        }
    }
}