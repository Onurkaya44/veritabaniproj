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
using System.Configuration;



namespace veritabaniproj
{
    public partial class Formaracekle : Form
    {
        public Formaracekle()
        {
            con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd='onur2001';");

            InitializeComponent();
        }

        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;



        private void button1_Click(object sender, EventArgs e)
        {
            Secimform form2sec = new Secimform();
            form2sec.Show();
             this.Hide();
        }
        void VeriGetir()
        {
            dt = new DataTable();
           // con.Open();
            adapter = new MySqlDataAdapter("SELECT *FROM arabalar", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
           // con.Close();
        }
        

        private void Formaracekle_Load(object sender, EventArgs e)
        {
            string komut = "CALL `arabagetir`();";
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           // con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {


            string sorgu = "Insert into arabalar (plaka,marka,model,modelyil,vites,renk,kirabedel) values (@plaka,@marka,@model,@modelyil,@vites,@renk,@kira)";
            cmd = new MySqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@plaka", plktxt.Text);
            cmd.Parameters.AddWithValue("@marka", marktxt.Text);
            cmd.Parameters.AddWithValue("@model", modtxt.Text);
            cmd.Parameters.AddWithValue("@modelyil",yiltxt.Text );
            cmd.Parameters.AddWithValue("@vites", vitesBox1.Text);
            cmd.Parameters.AddWithValue("@renk", renkBox2.Text);
            cmd.Parameters.AddWithValue("@kira", textBox1.Text);


            cmd.ExecuteNonQuery();
           // con.Close();
            VeriGetir();
            MessageBox.Show("Kayıt Eklendi.");
        }
        void KayıtSil(int id)
        {
            string sql = "DELETE FROM arabalar WHERE aid=@id";
            cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
           // con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Silindi");
           // con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)  //Seçili Satırları Silme
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                KayıtSil(id);
                VeriGetir();

            }


        }
    }
}

/*  string komut = "select * from arabalar";
            con.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(komut, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/