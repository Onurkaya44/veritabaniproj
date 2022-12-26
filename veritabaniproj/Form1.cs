using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace veritabaniproj
{
    public partial class girisform : System.Windows.Forms.Form
    {


        public girisform()
        {


            con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd='onur2001';");

            InitializeComponent();

        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        private void girisform_Load(object sender, EventArgs e)
        {
                


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kayitfrom form2sec = new Kayitfrom();
            form2sec.Show();
            this.Hide();
        }

        public void button2_Click(object sender, EventArgs e)
        {

            string kad = textBoxad.Text;
            string sif = textBoxsif.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM giris where kad='" + textBoxad.Text + "' AND sif='" + textBoxsif.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                Secimform frm = new Secimform();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string kullad = textBox2.Text;
            string sifre = textBox1.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kulgiris where kullad='" + textBox2.Text + "' AND sifre='" + textBox1.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                this.Hide();
                kullform frm = new kullform();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
            }
            con.Close();

        }
    }
}

