namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using NinjaDomain.Classes;

    internal sealed class Configuration : DbMigrationsConfiguration<NinjaDomain.DataModel.NinjaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NinjaDomain.DataModel.NinjaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            Clan clan = new Clan()
            {
                ClanName = "Uchiha Ninjas"
            };

            context.Clan.Add(clan);
            base.Seed(context);

        }
    }
}
