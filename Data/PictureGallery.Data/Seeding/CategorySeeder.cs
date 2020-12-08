namespace PictureGallery.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using PictureGallery.Data.Models;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category { Name = "Picture" });

            await dbContext.Categories.AddAsync(new Category { Name = "Bookmark" });

            await dbContext.Categories.AddAsync(new Category { Name = "Postcard" });

            await dbContext.SaveChangesAsync();
        }
    }
}
