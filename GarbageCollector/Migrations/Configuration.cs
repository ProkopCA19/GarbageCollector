namespace GarbageCollector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GarbageCollector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GarbageCollector.Models.ApplicationDbContext";
        }

        protected override void Seed(GarbageCollector.Models.ApplicationDbContext context)
        {
            context.Zipcode.AddOrUpdate(z => z.ZipId,
               new Models.Zipcode() { Areacode= 53226 },
               new Models.Zipcode() { Areacode = 53149 },
               new Models.Zipcode() { Areacode = 53005 },
               new Models.Zipcode() { Areacode = 53018 },
               new Models.Zipcode() { Areacode = 53022 },
               new Models.Zipcode() { Areacode = 53094 },
               new Models.Zipcode() { Areacode = 53098 },
               new Models.Zipcode() { Areacode = 53103 },
               new Models.Zipcode() { Areacode = 53129 },
               new Models.Zipcode() { Areacode = 53132 },
               new Models.Zipcode() { Areacode = 53122 },
               new Models.Zipcode() { Areacode = 53121 },
               new Models.Zipcode() { Areacode = 53151 },
               new Models.Zipcode() { Areacode = 53150 },
               new Models.Zipcode() { Areacode = 53154 },
               new Models.Zipcode() { Areacode = 53186 },
               new Models.Zipcode() { Areacode = 53187 },
               new Models.Zipcode() { Areacode = 53188 },
               new Models.Zipcode() { Areacode = 53189 },
               new Models.Zipcode() { Areacode = 53201 },
               new Models.Zipcode() { Areacode = 53202 },
               new Models.Zipcode() { Areacode = 53203 },
               new Models.Zipcode() { Areacode = 53204 },
               new Models.Zipcode() { Areacode = 53511 });


        }
    }
}
