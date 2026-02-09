namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YeniKolonlar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musteris", "Kolon1", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Musteris", "Kolon2", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musteris", "Kolon2");
            DropColumn("dbo.Musteris", "Kolon1");
        }
    }
}
