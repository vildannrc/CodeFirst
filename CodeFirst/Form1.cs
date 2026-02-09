using CodeFirst.ContextVeri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        MusteriDbContext dbcontext = new MusteriDbContext();

        private void Form1_Load(object sender, EventArgs e)
        {

            var liste = from x in dbcontext.Uruns join y in dbcontext.Kategoris
                        on x.KategoriID equals y.KategoriID join z in dbcontext.Markas 
                        on x.MarkaID equals z.MarkaID
                        
                //tablo birleştirme kategori marka ve ürün tablolarını birleştirdik


                        select new { 
                            x.UrunID,
                            x.UrunAdi,
                            y.KategoriAdi,
                            z.MarkaAdi,
                            x.BarkodNo,
                            x.Miktari,
                            x.AlisFiyati,
                            x.SatisFiyati,
                            x.Tarih 
                        };
            


            // dataGridView1.DataSource = dbcontext.Musteris.ToList();
            dataGridView1.DataSource = liste.ToList();
            var MiktarToplam = dbcontext.Uruns.Sum(x => x.Miktari);
            var MiktarKayitSayisi = dbcontext.Uruns.Count();
            var MiktarOrtalama = dbcontext.Uruns.Average(x => x.Miktari);
            var MiktarMax = dbcontext.Uruns.Max(x => x.Miktari);
            var MiktarMin = dbcontext.Uruns.Min(x => x.Miktari);

            lblToplamMiktari.Text = "Toplam Ürün Miktari= " + MiktarToplam;
            lblKayitSayisi.Text = "Toplam " + MiktarKayitSayisi + " Kayıt listelendi";
            lblOrtalama.Text = "Ortalama Miktar = " + MiktarOrtalama;
            lblMax.Text = "En yüksek Miktar = " + MiktarMax;
            lblMin.Text = "En düşük Miktar = " + MiktarMin;

        }

        void Temizle() 
        {
            //işlem bittikten sonra text boxları temizlesin
            foreach(Control item in Controls )
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
            dateTarih.Value = DateTime.Now;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var tbl = new Musteri();
            tbl.AdiSoyadi = txtAdiSoyadi.Text;
            tbl.Telefon = txtTelefon.Text;
            tbl.Sehir = txtSehir.Text;
            tbl.Email = txtEmail.Text;
            tbl.Tarih = dateTarih.Value;

            dbcontext.Musteris.Add(tbl);
            dbcontext.SaveChanges();
            MessageBox.Show("Kayıt Eklendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            dataGridView1.DataSource = dbcontext.Musteris.ToList();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAdiSoyadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSehir.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dateTarih.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();



        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            var tbl = dbcontext.Musteris.FirstOrDefault(x => x.MusteriID == ID);
            tbl.AdiSoyadi = txtAdiSoyadi.Text;
            tbl.Telefon = txtTelefon.Text;
            tbl.Sehir = txtSehir.Text;
            tbl.Email = txtEmail.Text;
            tbl.Tarih = dateTarih.Value;
            dbcontext.SaveChanges();
            MessageBox.Show("Kayıt Güncellendi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            dataGridView1.DataSource = dbcontext.Musteris.ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var tbl = dbcontext.Musteris.FirstOrDefault(x => x.MusteriID == ID);
            dbcontext.Musteris.Remove(tbl);
            dbcontext.SaveChanges();
            MessageBox.Show("Kayıt Silindi.", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            dataGridView1.DataSource = dbcontext.Musteris.ToList();

        }

        private void txtAdSoyadAra_TextChanged(object sender, EventArgs e)
        {
            var ara = from x in dbcontext.Musteris select x;
            if(txtAdSoyadAra.Text!=null)
            {
                dataGridView1.DataSource = ara.Where(x => x.AdiSoyadi.Contains(txtAdSoyadAra.Text)).ToList();
            }
        }

    }
}
