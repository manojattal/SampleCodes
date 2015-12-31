namespace Video.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Video.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoDb context)
        {
            context.Videos.AddOrUpdate(v => v.Name,
                new Video() { Name = "abc", Length = 100 },
                new Video() { Name = "xyz", Length = 200 });

        }
    }
}
