using MySql.Data.MySqlClient;
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
    public partial class Kayitfrom : Form
    {
    



    
        MySqlConnection con;
        MySqlCommand cmd;
        
        public Kayitfrom()
        {
            con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd='onur2001';");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            girisform form2sec = new girisform();
            form2sec.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string sorgu = "CALL `kekle`(@p1,@p2);";
            cmd = new MySqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@p1", textBox1.Text);
            cmd.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void Kayitfrom_Load(object sender, EventArgs e)
        {

        }
    }
}
