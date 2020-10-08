using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace RingAssigment.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Ring.Any())
                {
                    return;
                }

                context.Ring.AddRange(
                    new Ring
                    {
                        RingNumber = 1,
                        Rank = "White - Yellow",
                        AgeRange = "8-9",
                        Gender = "Male",
                        Division = "Traditional",
                        status = true
                    },

                    new Ring
                    {
                        RingNumber = 2,
                        Rank = "White - Yellow",
                        AgeRange = "10-12",
                        Gender = "Female",
                        Division = "Traditional",
                        status = true
                    },

                    new Ring
                    {
                        RingNumber = 3,
                        Rank = "Black Belts",
                        AgeRange = "14-16",
                        Gender = "Male",
                        Division = "Traditional",
                        status = true
                    },

                    new Ring
                    {
                        RingNumber = 4,
                        Rank = "Camo - Blue",
                        AgeRange = "8-9",
                        Gender = "Female",
                        Division = "Traditional",
                        status = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}