using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random _r = new Random();
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = $"X: {e.X}   --   Y: {e.Y}";
            label1.ForeColor = Color.FromArgb(_r.Next(256),_r.Next(256),_r.Next(256));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
