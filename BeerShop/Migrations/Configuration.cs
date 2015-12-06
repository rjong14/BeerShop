namespace BeerShop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BeerShop.Models.Beercontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "BeerShop.Models.BeerDBContext";
        }

        protected override void Seed(BeerShop.Models.Beercontext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            context.Beers.AddOrUpdate(b => b.Name,
              new Models.Beer() { Name = "Heineken", Price = 2.20 },
              new Models.Beer() { Name = "Hertog Jan", Price = 3.20 }


            );
            //
        }
    }
}
