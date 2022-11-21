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

namespace Disconnected_Mimarisi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=.;Database=Northwind;Integrated Security=true");
        private void button1_Click(object sender, EventArgs e)
        {
    

            SqlCommand komut = new SqlCommand();

            komut.Connection = baglanti;

            komut.CommandText = string.Format
            ("insert Kategoriler(KategoriAdi,Tanimi) values ('{0}','{1}')", txtKategoriAdi.Text, txtKategoriTanimi.Text);
            
            //degisken kullanmadan nesneleri atadık sadece

            

            baglanti.Open();

            int etkilenen = komut.ExecuteNonQuery();
            // etkilenen 0'dan büyük ise bir hata yoktur ve başarılı şekilde eklenmiştir
            // aksi takdirde bir hata oluşmuştur ve kayıt eklenememiştir.

            if (etkilenen > 0)
            {
                MessageBox.Show("Kayıt Başarılı");
                KategoriListesi();   // Yeniden güncel listeyi aktarması için metodu çağırdık
            }
            else
            {
                MessageBox.Show("Hata Oluştu !");
            }


            baglanti.Close();



        }

        

        private void KategoriListesi()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * From Kategoriler", baglanti);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["KategoriID"].Visible = false;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            KategoriListesi();
        }
    }
}
