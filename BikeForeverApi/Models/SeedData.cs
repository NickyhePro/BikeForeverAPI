using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeForeverApi.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BikeForeverContext(
                serviceProvider.GetRequiredService<DbContextOptions<BikeForeverContext>>()))
            {
                // Look for any movies.
                if (context.PostItem.Count() > 0)
                {
                    return;   // DB has been seeded
                }

                context.PostItem.AddRange(
                    new PostItem
                    {
                        UserId = "8tixSDQ0UVO5bb4Uxl60WVyZCkJ3",
                        Title = "My yamaha r6",
                        ImageUrl = "https://ftecu.com/shop/images/54712/17_r6_blue_b1.jpeg",
                        Tags = "Sportbike",
                        UploadTime = "07-10-18 4:20T18:25:43.511Z",
                        Author = "Nick He",
                        Subscribers = "8tixSDQ0UVO5bb4Uxl60WVyZCkJ3",
                        Width = "1000",
                        Height = "667"
                    }


                );
                context.SaveChanges();
            }
        }
    }
}
