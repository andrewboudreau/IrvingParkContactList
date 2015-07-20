using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using IrvingParkContactList.Models;

namespace IrvingParkContactList.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<IrvingParkContactList.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "IrvingParkContactList.Models.ApplicationDbContext";
        }

        protected override void Seed(IrvingParkContactList.Models.ApplicationDbContext context)
        {
            context.CityBlocks.AddOrUpdate(
                new CityBlock { Number = 3600, Street = "Drake Ave" },
                new CityBlock { Number = 3700, Street = "Drake Ave" },
                new CityBlock { Number = 3800, Street = "Drake Ave" },
                new CityBlock { Number = 3600, Street = "Saint Louis Ave" },
                new CityBlock { Number = 3700, Street = "Saint Louis Ave" },
                new CityBlock { Number = 3800, Street = "Saint Louis Ave" },
                new CityBlock { Number = 3600, Street = "Bernard St" },
                new CityBlock { Number = 3700, Street = "Bernard St" },
                new CityBlock { Number = 3800, Street = "Bernard St" },
                new CityBlock { Number = 3600, Street = "Central Park Ave" },
                new CityBlock { Number = 3700, Street = "Central Park Ave" },
                new CityBlock { Number = 3800, Street = "Central Park Ave" });
        }
    }
}
