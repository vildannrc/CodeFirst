namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class silAdres : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Musteris", "Adres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Musteris", "Adres", c => c.String());
        }
    }
}
