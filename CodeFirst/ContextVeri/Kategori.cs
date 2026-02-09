using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ContextVeri
{
    internal class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }


        public virtual ICollection<Urun> Uruns { get; set; }
        public virtual ICollection<Marka> Markas { get; set; }


    }
}
