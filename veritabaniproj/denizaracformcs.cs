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
    public partial class denizaracformcs : Form
    {
        public denizaracformcs()
        {
            con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd='onur2001';");

            InitializeComponent();
        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;
        void VeriGetir()
        {
            dt = new DataTable();
            // con.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM denizarac", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            // con.Close();
        }
        void KayıtSil(int id)
        {
            string sql = "DELETE FROM denizarac WHERE denizid=@id";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            // con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
            // con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "Insert into denizarac (aractip,uzunluk,itkitip,renk,kirabedel) values (@aract,@uzunluk,@itki,@renk,@kira)";
            cmd = new MySqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@aract", comboBox1.Text);
            cmd.Parameters.AddWithValue("@uzunluk", uzunluktxt.Text);
            cmd.Parameters.AddWithValue("@itki", itkiBox1.Text);
            cmd.Parameters.AddWithValue("@renk", renkBox2.Text);
            cmd.Parameters.AddWithValue("@kira", kiraBox1.Text);
            cmd.ExecuteNonQuery();
            // con.Close();
            VeriGetir();
            MessageBox.Show("Kayıt Eklendi.");
        }

        private void denizaracformcs_Load(object sender, EventArgs e)
        {
            con.Open();
            string cmd = "select * from denizbakis";

             MySqlDataAdapter da = new MySqlDataAdapter(cmd, con);
             DataTable dt = new DataTable();
             da.Fill(dt);
             dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(id);
                VeriGetir();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Secimform form2sec = new Secimform();
            form2sec.Show();
            this.Hide();
        }
    }
}
