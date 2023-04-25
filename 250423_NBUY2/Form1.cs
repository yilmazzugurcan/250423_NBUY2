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

namespace _250423_NBUY2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int flag = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=Northwind;User=sa;Pwd=123");
            SqlCommand cmd = new SqlCommand("select * from Urunler");
            cmd.Connection = conn;
            try
            {
                conn.Open();
                SqlDataReader reader= cmd.ExecuteReader();
                while (reader.Read())
                {
                    listView1.Items.Add(reader["UrunAdi"].ToString());
                    listView1.Items[flag].SubItems.Add(reader["BirimFiyati"].ToString());
                    comboBox1.Items.Add(reader["UrunAdi"].ToString());
                    comboBox2.Items.Add(reader["BirimFiyati"].ToString());
                    flag++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
