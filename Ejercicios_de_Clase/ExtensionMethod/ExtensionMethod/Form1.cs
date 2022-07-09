using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExtensionMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string codigo = "1234-re4-2022/06/01";
            MessageBox.Show(codigo.ContarPartesCodigo().ToString());
            List<string> l;l.First()
        }
    }

    public static class MiExtensiones
    {
        public static int ContarPartesCodigo(this string str)
        {
            return str.Split(new char[] {'-'}).Count();
        }
    }
}

