namespace pryLopezS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics papel;
            papel = pictureBox1.CreateGraphics();
            Pen l�piz = new Pen(Color.Black);
            papel.DrawRectangle(l�piz, 10, 10, 100, 50);
            papel.DrawRectangle(l�piz, 10, 75, 100, 100);
            papel.DrawEllipse(l�piz, 10, 75, 100, 100);
        }
    }
}