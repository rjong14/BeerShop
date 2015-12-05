namespace BeerShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerShop.Models.BeerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BeerShop.Models.BeerDBContext";
        }

        protected override void Seed(BeerShop.Models.BeerDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Beers.AddOrUpdate(b => b.Name,
              new Models.Beer() { Name = "Heineken", Country = "Netherlands", Type = "Pils", Price = 2.20 },
              new Models.Beer() { Name = "Hertog Jan", Country = "Netherlands", Type = "Pils", Price = 3.20 }


            );
            //
        }
    }
}
