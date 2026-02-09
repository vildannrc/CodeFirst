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
    internal class Urun:EntityTypeConfiguration<Urun> 
    {
        public int UrunID { get; set; }

        public int KategoriID { get; set; }
        public int MarkaID { get; set; }

        [StringLength(30)]   //kütüphane tanımı
        //büyük ihtimalle nvarchar olarak tanımlanacak
        public string BarkodNo { get; set; }
        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string UrunAdi { get; set; }
        public int Miktari { get; set; }
        
        public decimal AlisFiyati { get; set; }
        
        public decimal SatisFiyati { get; set; }
        public DateTime Tarih { get; set; }
        public virtual   ICollection<Sepet>  sepet { get; set; }
        //koleksiyon tanımı


        public virtual Kategori Kategori { get; set; }

        public virtual Marka Marka { get; set; }

        public Urun()
        {
            this.Property(x => x.AlisFiyati).HasPrecision(8, 3);
            this.Property(x => x.SatisFiyati).HasPrecision(8, 3);
        }

        
       
    }
}
