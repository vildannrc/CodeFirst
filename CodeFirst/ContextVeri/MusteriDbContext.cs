using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.ContextVeri
{
    internal class MusteriDbContext:DbContext
    {
        public  DbSet<Musteri> Musteris  { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Sepet> Sepets { get; set; }

        public DbSet<Marka> Markas { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Urun());
            modelBuilder.Configurations.Add(new Sepet());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention> ();

        }


    }
}
