using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veritabaniproj
{
    public partial class Secimform : Form
    {
        public Secimform()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            girisform form2sec = new girisform();
            form2sec.Show();
           // this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formaracekle form2sec = new Formaracekle();
            form2sec.Show();
            // this.Hide();
        }
    }
}
