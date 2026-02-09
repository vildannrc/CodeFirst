using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ContextVeri
{
     class Sepet : EntityTypeConfiguration<Sepet>
     {
        //iki tablo arasında eşleştirme yapılacak ürün tablosundaki ürün id ile sepet tablosundaki ürün id ile
        //1 den çoğa doğru bir ilişki
        public int SepetID { get; set; } //primary key olacak
        public int UrunID { get; set; }
        public int KategoriID { get; set; }
        public int MarkaID { get; set; }

        
        [StringLength(30)]   //kütüphane tanımı
        
        public string BarkodNo { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string UrunAdi { get; set; }
        public int Miktari { get; set; }

        public decimal BirimFiyati { get; set; }

        public decimal ToplamFiyati { get; set; }
        public DateTime Tarih { get; set; }
        public   virtual Urun urun { get; set; }
        public Sepet()
        {
            this.Property(x => x.BirimFiyati).HasPrecision(8, 3);
            this.Property(x => x.ToplamFiyati).HasPrecision(8, 3);
        }



     }

}
