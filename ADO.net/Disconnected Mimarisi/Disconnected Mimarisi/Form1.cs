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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=.;Database=Northwind;Integrated Security=true");

        private void Form1_Load(object sender, EventArgs e)
        {
            UrunleriListele();   // ctrl ' rm

            //Listeleme işlemlerini birçok kez kullandığımız için Metod haline getirdik !
            

        }

        private void UrunleriListele()
        {
            SqlDataAdapter adp = new SqlDataAdapter("Select * From Urunler", baglanti);

            DataTable dt = new DataTable();

            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["UrunID"].Visible = false;
            dataGridView1.Columns["KategoriID"].Visible = false;
            dataGridView1.Columns["TedarikciID"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adi = txtUrunAdi.Text;
            decimal fiyat = nmpFiyat.Value;
            decimal stok = nmpStok.Value;

            if(adi == "" || fiyat == null || stok==null)  //eksik veya hatalı kayıt eklemi olmaması için
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!");
                // Error provider eklenecek

            }

            SqlCommand komut = new SqlCommand();
            komut.CommandText = string.Format
            ("insert Urunler(UrunAdi,BirimFiyati,BirimdekiMiktar) values ('{0}',{1},{2})", adi, fiyat, stok);

            komut.Connection = baglanti;

            baglanti.Open();

            int etkilenen = komut.ExecuteNonQuery();
            // etkilenen 0'dan büyük ise bir hata yoktur ve başarılı şekilde eklenmiştir
            // aksi takdirde bir hata oluşmuştur ve kayıt eklenememiştir.

            if (etkilenen > 0 )
            {
                MessageBox.Show("Kayıt Başarılı");
                UrunleriListele();   // Yeniden güncel listeyi aktarması için metodu çağırdık
            }
            else
            {
                MessageBox.Show("Hata Oluştu !");
            }


            baglanti.Close();



        }

        private void btnKategoriler_Click(object sender, EventArgs e)
        {   
            // Click => Form2 açılacak

            Form2 Kategori = new Form2();
            Kategori.ShowDialog();      
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // datagridview'den seçili satırı seçme


            txtUrunAdi.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();

            txtUrunAdi.Tag = dataGridView1.CurrentRow.Cells["UrunID"].Value;

            nmpFiyat.Value = (decimal)dataGridView1.CurrentRow.Cells["BirimFiyati"].Value;

            nmpStok.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["BirimdekiMiktar"].Value);

            //db ' de nmpFiyat "int" iken  nmpStok "Short" veri tipinde bu yüzden convert gerekiyor

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText =
            string.Format
            ("update Urunler set UrunAdi='{0}', BirimFiyati={1}, BirimdekiMiktar={2} where UrunID={3}", txtUrunAdi.Text, nmpFiyat.Value, nmpStok.Value,txtUrunAdi.Tag);

            komut.Connection = baglanti;
            baglanti.Open();

            

            baglanti.Close();

            try
            {
                int etkilenen = komut.ExecuteNonQuery();
                baglanti.Close();
                if (etkilenen > 0)
                {
                    MessageBox.Show("Kayıt Güncellendi");
                    UrunleriListele();
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Kayıt Başarısız !" + ex.Message);
                baglanti.Close();
            }

            
            
            
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32
                        (dataGridView1.CurrentRow.Cells["UrunID"].Value);

                SqlCommand komut = new SqlCommand(string.Format("delete Urunler where UrunID = {0}", id), baglanti);

                int etkilenen = komut.ExecuteNonQuery();

                baglanti.Close();

                if(etkilenen > 0)
                {
                    MessageBox.Show("Kayıt Silinmiştir!");
                    UrunleriListele();
                }
                else
                {
                    MessageBox.Show("Hata Oluştu!");
                }
                    
            }
        }
    }
}
