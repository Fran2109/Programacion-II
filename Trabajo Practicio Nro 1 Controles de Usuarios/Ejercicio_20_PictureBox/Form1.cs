using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_20_PictureBox
{
    public partial class Form1 : Form
    {
        private Bitmap MyImage;
        int indice = 1;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            MyImage = new Bitmap(indice.ToString()+".png");
            pictureBox1.Image = (Image)MyImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            indice = indice != 3 ? indice+1 : 1; 
            MyImage = new Bitmap(indice.ToString() + ".png");
            pictureBox1.Image = (Image)MyImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            indice = indice != 1 ? indice - 1 : 3;
            MyImage = new Bitmap(indice.ToString() + ".png");
            pictureBox1.Image = (Image)MyImage;
        }
    }
}
