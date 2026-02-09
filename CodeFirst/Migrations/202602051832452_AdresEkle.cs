namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdresEkle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Musteris", "Adres", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Musteris", "Adres");
        }
    }
}
