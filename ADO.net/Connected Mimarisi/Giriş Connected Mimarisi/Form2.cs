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

namespace Giriş_Connected_Mimarisi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server=.;Database=Northwind;Integrated Security=true;";

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select * from Kategoriler";
            komut.Connection = baglanti;

            baglanti.Open();

            SqlDataReader rdr = komut.ExecuteReader();

            while (rdr.Read())
            {
                string adi = rdr["KategoriAdi"].ToString();
                string tanimi = rdr["Tanimi"].ToString();
                

                listKategoriler.Items.Add(string.Format("{0} - {1}", adi, tanimi));
            }
            baglanti.Close();

        }
    }
}
