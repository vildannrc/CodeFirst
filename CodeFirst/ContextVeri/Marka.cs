using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ContextVeri
{
    internal class Marka
    {
        public  int  MarkaID { get; set; }
        public int KategoriID { get; set; }
        public string MarkaAdi { get; set; }
        //kategoriye göre marka seçilecek 
        //1 den çoğa doğru bir ilişki olacak.

        public virtual ICollection<Urun> Uruns { get; set; }
        public virtual Kategori Kategori { get; set; }

    }
}
