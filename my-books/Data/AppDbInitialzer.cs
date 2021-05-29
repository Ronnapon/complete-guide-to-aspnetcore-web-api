using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitialzer
    {
        public static void Seed(IApplicationBuilder appliationBuilder)
        {
            using (var serviceScrope = appliationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScrope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "http.....",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2st Book Title",
                        Description = "2st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        CoverUrl = "http.....",
                        DateAdded = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }

        }
    }
}
