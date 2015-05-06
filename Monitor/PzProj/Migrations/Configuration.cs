namespace PzProj.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PzProj.Models.PzProjContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PzProj.Models.PzProjContext context)
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

            context.Users.AddOrUpdate(p => p.login, 
                new PzProj.Models.Users{
                    id=1,
                    login="Pierwszy",
                    mail="pierwszy@asd.pl",
                    password="Fitst",
                    status="good",
                    superuser=0},
                new PzProj.Models.Users{
                    id=2,
                    login="Pierwszy2",
                    mail="pierwsz22y@asd.pl",
                    password="Fits222t",
                    status="good222",
                    superuser=0});

            context.Hosts.AddOrUpdate(p => p.ip_addr,
                new PzProj.Models.Hosts
                {
                    id=1,
                    ip_addr="127.0.0.1",
                    name="first",
                    status="good"
                },
                new PzProj.Models.Hosts
                {
                    id=2,
                    ip_addr="127.0.0.2",
                    name="first2222",
                    status="good2222"
                }
                );

                }
        }
    
}
