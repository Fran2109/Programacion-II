using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_14_Linklabel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Link.LinkVisited = true;
            System.Diagnostics.Process.Start("https://docs.microsoft.com/es-es/dotnet/api/system.windows.forms.linklabel?view=windowsdesktop-6.0");
        }
    }
}
