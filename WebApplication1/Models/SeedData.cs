using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WebApplication1Context(serviceProvider.GetRequiredService<DbContextOptions<WebApplication1Context>>()))
            {
                if (context.Dexter.Any())
                {
                    return;
                }
                context.Dexter.AddRange(
                    new Dexter
                    {
                        Name = "Morgan",
                        Gender = "male",
                        EntryID = 1,
                        ElementType = "Mayami",
                        ImageUrl = "https://i2.wp.com/ilarge.lisimg.com/image/5877298/740full-dexter-morgan.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
