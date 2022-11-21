﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server=.;Database=Northwind;Integrated Security=true;";

            SqlCommand komut = new SqlCommand();
            komut.CommandText = "Select * from Urunler";
            komut.Connection = baglanti;

            baglanti.Open();
            SqlDataReader rdr = komut.ExecuteReader();

            while(rdr.Read())
            {
                string adi = rdr["UrunAdi"].ToString();
                string fiyat = rdr["BirimFiyati"].ToString();
                string stok = rdr["BirimdekiMiktar"].ToString();

                listUrunler.Items.Add(string.Format("{0} - {1} - {2}", adi, fiyat, stok));
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 kategori = new Form2();
            kategori.ShowDialog();

        }
    }
}
