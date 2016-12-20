namespace MediaBlueTest.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MediaBlueTest.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MediaBlueTest.Models.ApplicationDbContext context)
        {
            //Seed our images into the Image table
            List<Image> imageList = context.Images.ToList();
            
            for (int i = 1; i <= 10; i++)
            {
                Image newImage = new Image { ImageURL = "/Content/images/" + i.ToString().PadLeft(2, '0') + ".png", ImageName = i.ToString().PadLeft(2, '0') };
                if (!imageList.Any(im => im.ImageURL == newImage.ImageURL))
                {
                    context.Images.Add(newImage);
                }
            }

            //Seed our scale points into the Scale table
            List<Scale> scaleList = context.Scales.ToList();

            for (int i = 1; i <= 10; i++)
            {
                Scale newScale = new Scale { Weight = i, Order = i, CssClass = "default", Name = i.ToString() };
                if (!scaleList.Any(sc => sc.Weight == newScale.Weight))
                {
                    context.Scales.Add(newScale);
                }
            }

            //Save our changes
            context.SaveChanges();
        }
    }
}
