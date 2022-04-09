using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_18_NotifyIcon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Icon = new Icon("appicon.ico");
                notifyIcon1.BalloonTipText = "Se ha minimizado el formulario";
                notifyIcon1.ShowBalloonTip(1000);
            }
            else if(this.WindowState == FormWindowState.Normal)
            {
                notifyIcon1.BalloonTipText = "El formulario volvio al estado normal";
                notifyIcon1.ShowBalloonTip(1000);
            }
        }
    }
}
