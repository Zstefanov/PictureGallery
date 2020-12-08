using PictureGallery.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PictureGallery.Data.Seeding
{
    public class PictureSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Pictures.Any())
            {
                return;
            }

            var category = dbContext.Categories.FirstOrDefault();

            await dbContext.Pictures.AddAsync(new Picture
            {
                Name = "Summer love", IsAvailable = true,
                ImageUrl = "https://www.google.com/search?q=summer+love&source=lnms&tbm=isch&sa=X&ved=2ahUKEwiBxf3s0bztAhXjBxAIHTPgBxsQ_AUoAXoECAkQAw&biw=1745&bih=881#imgrc=KEYlSs3IwHYBsM",
                Category = category,
            });

            await dbContext.Pictures.AddAsync(new Picture
            {
                Name = "Holy night", IsAvailable = true,
                ImageUrl = "https://www.google.com/search?q=holy+night&tbm=isch&ved=2ahUKEwjcm47u0bztAhVK4oUKHalYCTwQ2-cCegQIABAA&oq=holy+night&gs_lcp=CgNpbWcQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6BAgAEENQmGRY3ndgo3hoAHAAeACAAZsBiAH7CJIBAzAuOZgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=J4fOX5zsAsrElwSpsaXgAw&bih=881&biw=1745#imgrc=5SzrnYU-aiXgqM",
                Category = category,
            });

            await dbContext.Pictures.AddAsync(new Picture
            {
                Name = "Sweet cookies", IsAvailable = false,
                ImageUrl = "https://www.google.com/search?q=sweet+cookies&tbm=isch&ved=2ahUKEwjmjZ720bztAhUYahoKHauPCwEQ2-cCegQIABAA&oq=sweet+cookies&gs_lcp=CgNpbWcQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgYIABAFEB4yBggAEAUQHjoECAAQQ1Djc1i8gAFgroEBaABwAHgAgAGFAYgBvQuSAQQxLjEymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=OIfOX-aRBZjUaaufrgg&bih=881&biw=1745#imgrc=hdQpPaQJqd-gPM",
                Category = category,
            });

            await dbContext.Pictures.AddAsync(new Picture
            {
                Name = "Winter heaven", IsAvailable = false,
                ImageUrl = "https://www.google.com/search?q=winter+scene&tbm=isch&ved=2ahUKEwiulpWL0rztAhUCZxoKHafuCtEQ2-cCegQIABAA&oq=winter+scene&gs_lcp=CgNpbWcQAzICCAAyAggAMgIIADICCAAyAggAMgIIADICCAAyAggAMgIIADICCAA6BggAEAgQHjoECAAQQ1CsFVj7N2DgOGgAcAB4AIABjwGIAa4JkgEEMC4xMJgBAKABAaoBC2d3cy13aXotaW1nwAEB&sclient=img&ei=Y4fOX-7YO4LOaafdq4gN&bih=881&biw=1745#imgrc=22gVEDGIHNTiJM",
                Category = category,
            });

            await dbContext.Pictures.AddAsync(new Picture
            {
                Name = "Sunset", IsAvailable = false,
                ImageUrl = "https://www.google.com/search?q=sunset&tbm=isch&ved=2ahUKEwiDtaKP0rztAhVO2xoKHRMZArsQ2-cCegQIABAA&oq=sunset&gs_lcp=CgNpbWcQAzIECAAQQzICCAAyBAgAEEMyBAgAEEMyBAgAEEMyBAgAEEMyBAgAEEMyAggAMgIIADIECAAQQ1DRdFj-eWDKemgAcAB4AIABogGIAbIFkgEDMC41mAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=bIfOX4PPI862a5OyiNgL&bih=881&biw=1745#imgrc=nXBh4984cI5SJM",
                Category = category,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
