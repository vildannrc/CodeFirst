namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UrunTablosuEkle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunID = c.Int(nullable: false, identity: true),
                        BarkodNo = c.String(maxLength: 20),
                        UrunAdi = c.String(maxLength: 50, unicode: false),
                        Miktari = c.Int(nullable: false),
                        AlisFiyati = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SatisFiyati = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UrunID);
            
            AddColumn("dbo.Musteris", "Adres", c => c.String());
            DropColumn("dbo.Musteris", "Kolon1");
            DropColumn("dbo.Musteris", "Kolon2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musteris", "Kolon2", c => c.Double(nullable: false));
            AddColumn("dbo.Musteris", "Kolon1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Musteris", "Adres");
            DropTable("dbo.Uruns");
        }
    }
}
