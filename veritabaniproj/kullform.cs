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
    public partial class kullform : Form
    {
        public kullform()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            girisform form2sec = new girisform();
            form2sec.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kullkiragos form2sec = new kullkiragos();
            form2sec.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kullnicikiragos2 form2sec = new kullnicikiragos2();
            form2sec.Show();
            //this.Hide();
        }
    }
}
