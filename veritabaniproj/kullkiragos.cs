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
    public partial class kullkiragos : Form
    {
        public kullkiragos()
        {
            con = new MySqlConnection("Server=localhost;Database=deneme;Uid=root;Pwd='onur2001';");

            InitializeComponent();
        }
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        MySqlDataAdapter adapter;
        DataTable dt;
        int SecilenAracID;
        int gunsayisi;
        int toplamucret;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kullkiragos_Load(object sender, EventArgs e)
        {
            con.Open();
            string cmd = "select * from arabagetir";

            MySqlDataAdapter da = new MySqlDataAdapter(cmd, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlCommand komut = new MySqlCommand("SELECT ucrethesaplaaraba(@p1, @p2)", con);
            komut.Parameters.AddWithValue("@p1", SecilenAracID);
            komut.Parameters.AddWithValue("@p2", Convert.ToInt16(textBox1.Text));
            MySqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                toplamucret = Convert.ToInt16(dr[0]);

            }
            label1.Text = toplamucret.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            SecilenAracID = Convert.ToInt16(dataGridView1.Rows[secilen].Cells[7].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kullform form2sec = new kullform();
            form2sec.Show();
            this.Hide();
        }
    }
}
