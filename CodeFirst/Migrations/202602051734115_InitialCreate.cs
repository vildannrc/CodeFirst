namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Musteris",
                c => new
                    {
                        MusteriID = c.Int(nullable: false, identity: true),
                        AdiSoyadi = c.String(),
                        Telefon = c.String(),
                        Sehir = c.String(),
                        Email = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MusteriID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Musteris");
        }
    }
}
