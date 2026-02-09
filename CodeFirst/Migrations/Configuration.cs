namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.ContextVeri.MusteriDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true ;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CodeFirst.ContextVeri.MusteriDbContext";
        }

        protected override void Seed(CodeFirst.ContextVeri.MusteriDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
