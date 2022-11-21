using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoliceDepartment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PoliceDepartmantEntities db = new PoliceDepartmantEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            PoliceDepartmantEntities db = new PoliceDepartmantEntities();    
            dataGridView1.DataSource = db.Personellers.ToList();             

            cmbDepartman.DataSource = db.Departmanlars.ToList();
            cmbDepartman.DisplayMember = "departmanAdi";
            cmbDepartman.ValueMember = "departmanID";

            cmbBölge.DisplayMember = "bölgeAdi";
            cmbBölge.ValueMember = "bölgeID";
            cmbBölge.DataSource = db.Bölgeler.ToList();

            cmbArac.DisplayMember = "aracPlaka";
            cmbArac.ValueMember = "aracID";
            cmbArac.DataSource = db.Ekip_Araclaris.ToList();

            cmbSilah.DisplayMember = "silahSeriNo";
            cmbSilah.ValueMember = "silahID";
            cmbSilah.DataSource = db.Silahlars.ToList();

            cmbMaas.DisplayMember = "personelMaasTutar";
            cmbMaas.ValueMember = "personelMaasID";
            cmbMaas.DataSource = db.Maaslars.ToList();

            cmbPrim.DisplayMember = "personelPrimTutari";
            cmbPrim.ValueMember = "personelPrimID";
            cmbPrim.DataSource = db.Primlers.ToList();



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            PoliceDepartmantEntities db = new PoliceDepartmantEntities();
            Personeller personel = new Personeller();

            personel.personelTC = mskTC.Text;
            personel.personelAdi = txtAdi.Text;
            personel.personelSoyadi = txtSoyadi.Text;
            personel.personelSehri = cmbSehir.Text;
            personel.personelYas = dtpYasi.Value;

            if (rdbErkek.Checked)
            {
                personel.personelCinsiyeti = "Erkek";
            }
            else if (rdbKadin.Checked)
            {
                personel.personelCinsiyeti = "Kadın";
            }
            else
            {
                MessageBox.Show("Cinsiyet Belirtmelisiniz! ");
            }

            db.Personellers.Add(personel);
            db.SaveChanges();
            dataGridView1.DataSource = db.Personellers.ToList();


        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            PoliceDepartmantEntities db = new PoliceDepartmantEntities();
            var sonuc = from p in db.Personellers
                        join d in db.Departmanlars on p.personelDepartmani equals d.departmanID
                        join b in db.Bölgeler on p.personelBölge equals b.bölgeID
                        select new
                        {

                            p.personelID,
                            p.personelAdi,
                            p.personelSoyadi,
                            p.personelCinsiyeti,
                            p.personelSehri,
                            d.departmanID,
                            d.departmanAdi,
                            d.departmanAmiri,
                            d.departmanBölge,
                            b.bölgeID,
                            b.bölgeAdi
                        };

            db.SaveChanges();
            dataGridView1.DataSource = sonuc.ToList();
            


            


        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            if (mskTC.Text != null)
            {   

                var ara = db.Personellers.Where(x => x.personelTC.Contains(mskTC.Text)).ToList();
                dataGridView1.DataSource = ara;

            }
            else
            {
                dataGridView1.DataSource = db.Personellers.ToList();
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            PoliceDepartmantEntities db = new PoliceDepartmantEntities();
            int vpersonelid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Personeller silinecek = db.Personellers.FirstOrDefault(x => x.personelID == vpersonelid);

            db.Personellers.Remove(silinecek);
            db.SaveChanges();
            dataGridView1.DataSource = db.Personellers.ToList();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string vpersonelTC = Convert.ToString(mskTC.Text);
            Personeller personel = db.Personellers.FirstOrDefault(x => x.personelTC == vpersonelTC);

            
            personel.personelTC = mskTC.Text;
            personel.personelAdi = txtAdi.Text;
            personel.personelSoyadi = txtSoyadi.Text;
            personel.personelSehri = cmbSehir.Text;
            personel.personelYas = dtpYasi.Value;

            if (rdbErkek.Checked)
            {
                personel.personelCinsiyeti = "Erkek";
            }
            else if (rdbKadin.Checked)
            {
                personel.personelCinsiyeti = "Kadın";
            }

            db.SaveChanges();
            db.Personellers.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;

            mskTC.Text = row.Cells["personelTC"].Value.ToString();
            txtAdi.Text = row.Cells["personelAdi"].Value.ToString();
            txtSoyadi.Text = row.Cells["personelSoyadi"].Value.ToString();
            cmbSehir.SelectedValue = row.Cells["personelSehri"].Value.ToString();
            

            mskTC.Tag = row.Cells["personelID"].Value;

            db.SaveChanges();
            db.Personellers.ToList();

        }

        private void mskTC_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskTC_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void rdbErkek_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {

            var sonuc = db.Personellers.Join(
                db.Departmanlars,
                p => p.personelDepartmani,
                d => d.departmanID,
                (personel, departman) => new
                {
                    personel.personelTC,
                    personel.personelAdi,
                    personel.personelSoyadi,
                    personel.personelSehri,
                    personel.personelCinsiyeti,
                    personel.personelYas,

                    departman.departmanID,
                    departman.departmanAdi,
                    departman.departmanAmiri,
                    departman.departmanBölge
                }).ToList();

            dataGridView1.DataSource = sonuc.ToList();
            

        }
    }
}
