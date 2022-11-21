using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductEntities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwindEntities db = new NorthwindEntities(); //   (global / scope alanı)

        private void Form1_Load(object sender, EventArgs e)
        {
            NorthwindEntities db = new NorthwindEntities();     // vt ile baglantı kuruldu
            dataGridView1.DataSource = db.Urunlers.ToList();    // vt  datagrid'e aktarıldı


            // comboboxlar'a verileri aktarıyoruz.

            cmbUrunKategori.DisplayMember = "KategoriAdi";          // urun kategorsi blg. 
            cmbUrunKategori.ValueMember = "KategoriID";             // Kategoriler tablsndan alıyoruz
            cmbUrunKategori.DataSource = db.Kategorilers.ToList();


            cmbUrunTedarikci.DisplayMember = "SirketAdi";           //tedarikci adi 
            cmbUrunTedarikci.ValueMember = "TedarikciID";           //tedarıkcı bilg. tedarikciler tblsndan alıyoruz    
            cmbUrunTedarikci.DataSource = db.Tedarikcilers.ToList();


        }

        private void btnEkle_Click(object sender, EventArgs e)
        {


            Urunler urun = new Urunler();                          // urun tabls aktarma yapcgmz ıcın 
            Tedarikciler tedarikci = new Tedarikciler();            // ve tedarikciler

            // nereden nereye aktarma yapacagmzı yazıyoruz.

            // urun bilg. için
            urun.UrunAdi = txtUrunAdi.Text;
            urun.BirimFiyati = nmpBirimFiyati.Value;         //sayi
            urun.BirimdekiMiktar = Convert.ToString(nmpBirimMiktari.Value);    //metin
            urun.KategoriID = Convert.ToInt32(cmbUrunKategori.SelectedValue);       // seçili ögeyi ekle
            urun.TedarikciID = Convert.ToInt16(cmbUrunTedarikci.SelectedValue);     // seçili ögeyi ekle

            // tedarikci için
            tedarikci.SirketAdi = txtSirketAdi.Text;
            tedarikci.MusteriAdi = txtMüsteriAdi.Text;
            tedarikci.MusteriUnvani = cmbMüsteriUnvani.SelectedText;
            tedarikci.Sehir = cmbSehri.SelectedText;
            tedarikci.Telefon = mskTelefon.Text;


            db.Urunlers.Add(urun);      // urunler tablosuna urunlerı ekle

            db.Tedarikcilers.Add(tedarikci);    //tedarikciler tablosuna tedarikcileri ekle

            db.SaveChanges();           // degısıklıklerı kaydet

            dataGridView1.DataSource = db.Urunlers.ToList();   // Urunler tabls. listele



        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            // datagridde seçili olan cells (hücreyi)
            // vurunID adındaki  int degere aktar.

            int vurunID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            // seçili olan ögeyi ,  firstordefault yani var olan değer olarak kabul et
            // ve bu degeri  " sil " adlı ögeye ver
            Urunler sil = db.Urunlers.FirstOrDefault(urun => urun.UrunID == vurunID);

            // verilen ögeyi  REMOVE  ile kaldırıyor.
            db.Urunlers.Remove(sil);
            db.SaveChanges();
            dataGridView1.DataSource = db.Urunlers.ToList();

        }

        private void btnJoin_Click(object sender, EventArgs e)
        {

            var sonuc = from k in db.Kategorilers
                        join u in db.Urunlers on k.KategoriID equals u.KategoriID   // equals = eşittir
                        join t in db.Tedarikcilers on u.TedarikciID equals t.TedarikciID
                        select new
                        {
                            k.KategoriID,
                            k.KategoriAdi,
                            u.UrunID,
                            u.UrunAdi,
                            t.TedarikciID,
                            t.MusteriAdi,
                            t.SirketAdi,
                            t.MusteriUnvani,
                            t.Telefon
                        };

            db.SaveChanges();
            dataGridView1.DataSource = sonuc.ToList();




        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int vurunid = (int)txtUrunID.Tag;

            //Urunler urun = db.Urunlers.FirstOrDefault(urun => urun.UrunID == vurunid);

            //urun.UrunID = txtUrunID.Text;
            //urun.UrunAdi = txtUrunAdi.Text;
            //urun.BirimFiyati = nmpBirimFiyati.Value;
            ////urun.BirimdekiMiktar = nmpBirimMiktari.Value;
            //urun.KategoriID = (int)cmbUrunKategori.SelectedValue;
            //urun.TedarikciID = (int)cmbUrunTedarikci.SelectedValue;

            //db.SaveChanges();
            //db.Urunlers.ToList();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {


            if (txtUrunAdi.Text != null)
            {   // contains = içerir demek
                // eğer txturunadinin içi boş  ise bizim yazdıgımız şeyi içersin diyoruz.

                var ara = db.Urunlers.Where(urun => urun.UrunAdi.Contains(txtUrunAdi.Text)).ToList();
                dataGridView1.DataSource = ara;

            }
            else
            {
                dataGridView1.DataSource = db.Urunlers.ToList();
            }


            // btnAra için textchanged özelligini unutmuyoruz
        }


        private void btnListele_Click(object sender, EventArgs e)
        {


            var sonuc = db.Urunlers.Join(
                db.Kategorilers,
                urunler => urunler.KategoriID,
                kategoriler => kategoriler.KategoriID,
                (urunler, kategoriler) => new
                {

                    urunler.UrunAdi,
                    urunler.BirimFiyati,
                    urunler.BirimdekiMiktar,
                    kategoriler.KategoriAdi
                }).ToList();

            dataGridView1.DataSource = sonuc.ToList();



            var sonuc2 = db.Urunlers.Join(
                 db.Tedarikcilers,
                 urunler => urunler.TedarikciID,
                 tedarikciler => tedarikciler.TedarikciID,
                 (urunler, tedarikciler) => new
                 {
                     urunler.UrunAdi,
                     urunler.UrunID,
                     urunler.BirimFiyati,
                     urunler.BirimdekiMiktar,
                     tedarikciler.SirketAdi,
                     tedarikciler.MusteriAdi,
                     tedarikciler.MusteriUnvani

                 }).ToList();

            dataGridView1.DataSource = sonuc2.ToList();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dataGridView1.CurrentRow;

            //txtUrunAdi.Text = row.Cells
            //    ["UrunAdi"].Value.ToString();

            //nmpBirimFiyati.Value = (decimal)row.Cells["BirimFiyat"].Value;

            //nmpBirimMiktari.Value = Convert.ToDecimal(row.Cells
            //    ["BirimdekiMiktar"]);

            //cmbUrunKategori.SelectedValue = row.Cells
            //    ["KategoriID"].Value;

            //cmbUrunTedarikci.SelectedValue = row.Cells
            //    ["TedarikciID"].Value;

            //txtUrunAdi.Tag = row.Cells["UrunID"].Value;

        }
    }
}

