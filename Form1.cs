using System.Windows.Forms;
using System.Drawing;
namespace pryLopezS
{
    public partial class Galaga : Form
    {
        public Galaga()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        //Creo el metodo para el dibujo
        public void DrawPlayer(Graphics g)
        {

            //Dibujo la Nave (lápiz, 0(x), 0(y), 5(Tamano), 5(tamano))
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            // lapiz para los rectangulos grises
            SolidBrush lápiz = new SolidBrush(Color.LightGray);

            //lapiz para los rectangulos Rojos
            SolidBrush LapizRojo = new SolidBrush(Color.Red);

            //lapiz para los rectangulos Azules
            SolidBrush LapizAzul = new SolidBrush(Color.DodgerBlue);

            //1 columna OK
            papel.FillRectangle(LapizRojo, 0, 40, 5, 10);
            papel.FillRectangle(lápiz, 0, 50, 5, 30);
            //2 columna OK
            papel.FillRectangle(lápiz, 5, 60, 5, 15);
            //3 columna OK
            papel.FillRectangle(lápiz, 10, 55, 5, 15);
            //4 columna OK
            papel.FillRectangle(LapizRojo, 15, 25, 5, 10);
            papel.FillRectangle(lápiz, 15, 35, 5, 10);
            papel.FillRectangle(LapizAzul, 15, 45, 5, 5);
            papel.FillRectangle(lápiz, 15, 50, 5, 15);
            //5 columna OK
            papel.FillRectangle(LapizAzul, 20, 40, 5, 5);
            papel.FillRectangle(lápiz, 20, 45, 5, 20);
            papel.FillRectangle(LapizRojo, 20, 65, 5, 10);
            //6 columna OK
            papel.FillRectangle(lápiz, 25, 35, 5, 25);
            papel.FillRectangle(LapizRojo, 25, 60, 5, 15);
            //7 columna OK
            papel.FillRectangle(lápiz, 30, 15, 5, 30);
            papel.FillRectangle(LapizRojo, 30, 45, 5, 10);
            papel.FillRectangle(lápiz, 30, 55, 5, 15);
            //8 columna Ok
            papel.FillRectangle(lápiz, 35, 0, 5, 40);
            papel.FillRectangle(LapizRojo, 35, 40, 5, 10);
            papel.FillRectangle(lápiz, 35, 50, 5, 30);
            //9 columna OK 
            papel.FillRectangle(lápiz, 40, 15, 5, 30);
            papel.FillRectangle(LapizRojo, 40, 45, 5, 10);
            papel.FillRectangle(lápiz, 40, 55, 5, 15);
            //10 columna
            papel.FillRectangle(lápiz, 45, 35, 5, 25);
            papel.FillRectangle(LapizRojo, 45, 60, 5, 15);
            //11 columna
            papel.FillRectangle(LapizAzul, 50, 40, 5, 5);
            papel.FillRectangle(lápiz, 50, 45, 5, 20);
            papel.FillRectangle(LapizRojo, 50, 65, 5, 10);
            //12 columna
            papel.FillRectangle(LapizRojo, 55, 25, 5, 10);
            papel.FillRectangle(lápiz, 55, 35, 5, 10);
            papel.FillRectangle(LapizAzul, 55, 45, 5, 5);
            papel.FillRectangle(lápiz, 55, 50, 5, 15);
            //13 columna
            papel.FillRectangle(lápiz, 60, 55, 5, 15);
            //14 columna
            papel.FillRectangle(lápiz, 65, 60, 5, 15);
            //15 columna
            papel.FillRectangle(LapizRojo, 70, 40, 5, 10);
            papel.FillRectangle(lápiz, 70, 50, 5, 30);
        }

    }
}