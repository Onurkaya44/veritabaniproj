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
    public partial class bakisform : Form
    {
        public bakisform()
        {
            con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd='onur2001';");

    
            InitializeComponent();
        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataTable dtt;
        MySqlCommand cmdd;

        private void bakisform_Load(object sender, EventArgs e)
        {
            
            string cmd = "select * from bakis";
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            string cmdd = "select * from denizsiparisbakis";
            
            MySqlDataAdapter daa = new MySqlDataAdapter(cmdd, con);
            DataTable dtt = new DataTable();
            daa.Fill(dtt);
            dataGridView2.DataSource = dtt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Secimform form2sec = new Secimform();
            form2sec.Show();
            this.Hide();
        }
    }
}
