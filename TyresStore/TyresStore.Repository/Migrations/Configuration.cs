namespace TyresStore.Repository.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using TyresStore.Repository.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TyresStore.Repository.TyresStoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TyresStoreContext context)
        {
            var vehicles = new List<Vehicle>
            {
                new Vehicle{Manufacturer="Ford", Model="Focus", Year=2015, Color="Gray"},
                new Vehicle{Manufacturer="BMV", Model="X3", Year=2017, Color="Black"},
                new Vehicle{Manufacturer="VW", Model="Passat", Year= 2001, Color="Red"},
                new Vehicle{Manufacturer="Opel", Model="Corsa", Year= 2013, Color="Red"}
            };

			vehicles.ForEach(v => context.Vehicles.AddOrUpdate(x => new { x.Manufacturer, x.Model, x.Year }, v));
			context.SaveChanges();

            var tyres = new List<Tyre>
            {
                new Tyre{VehicleId=1,Brand="Pirelli", Season="Winter", ArticleCode="205/55R16 91V TL", Price = 100.75},
                new Tyre{VehicleId=1,Brand="GoodYear", Season="Summer",  ArticleCode="205/55R16 91W TL", Price=85.75},
                new Tyre{VehicleId=1,Brand="Dunlop", Season="All",  ArticleCode="225/75R16 90W TL", Price=185.6},
                new Tyre{VehicleId=1,Brand="Continental", Season="Winter",  ArticleCode="205/55R16 91V TL", Price=205.5},
                new Tyre{VehicleId=2,Brand="Pirelli", Season="Summer",  ArticleCode="245/75R16	55V TL", Price=302.6},
                new Tyre{VehicleId=2,Brand="Continental", Season="All",  ArticleCode="205/55R16 91W TL", Price=104},
                new Tyre{VehicleId=3,Brand="GoodYear", Season="Winter",  ArticleCode="245/75R16	55V TL", Price=155.9},
                new Tyre{VehicleId=3,Brand="Pirelli", Season="All",  ArticleCode="205/55R16 91V TL", Price=274.6},
                new Tyre{VehicleId=3,Brand="Continental", Season="Summer",  ArticleCode="225/75R16 90W TL", Price= 300}
            };
			tyres.ForEach(t => context.Tyres.AddOrUpdate(x => new { x.Brand, x.Season, x.ArticleCode }, t));
			context.SaveChanges();
        }
    }
}
