using Microsoft.EntityFrameworkCore;
using RealEstate_Tracker.Data;

namespace RealEstate_Tracker.Models;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RealEstate_TrackerContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RealEstate_TrackerContext>>()))
        {
            if (context == null || context.Estate == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any estates.
            if (context.Estate.Any())
            {
                return;   // DB has been seeded
            }

            context.Estate.AddRange(
                new Estate
                {
                    Title = "https://www.zillow.com/homedetails/2638-Pursell-Cir-Sarasota-FL-34232/47491503_zpid/",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Type_of_Estate = "Fixer Upper",
                    Price = 375000.00M,
                    Rating = "Good"
                },

                new Estate
                {
                    Title = "https://www.zillow.com/homes/for_sale/house_type/47494828_zpid/20362_rid/0-900000_price/0-4427_mp/0_singlestory/days_sort/27.334336335921712,-82.43720054626465,27.207694089483486,-82.6380443572998_rect/0_mmm/",
                    ReleaseDate = DateTime.Parse("2023-3-13"),
                    Type_of_Estate = "Sarasota Fixer Upper",
                    Price = 299000.00M,
                    Rating = "Moderate Work"
                },

                new Estate
                {
                    Title = "https://www.zillow.com/homedetails/19-NW-92nd-St-Miami-Shores-FL-33150/44007631_zpid/",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Type_of_Estate = "Miami top of the Market Small Family house",
                    Price = 875000.00M,
                    Rating = "Total ReHab"
                },

                new Estate
                {
                    Title = "https://www.zillow.com/homedetails/2812-Whisper-Pine-Dr-Gulf-Breeze-FL-32563/47895170_zpid/",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Type_of_Estate = "Gulf Breeze fixer Upper",
                    Price = 389900.00M,
                    Rating = "Good Standing"
                }
            );
            context.SaveChanges();
        }
    }
}
