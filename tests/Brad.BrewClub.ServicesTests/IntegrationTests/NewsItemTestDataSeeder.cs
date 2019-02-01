using Brad.BrewClub.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brad.BrewClub.ServicesTests.IntegrationTests
{
    class NewsItemTestDataSeeder
    {
        public static void SetTestData(BrewClubDbContext brewClubDB)
        {
            brewClubDB.NewsItems.Add(new NewsItemData
            {
                Id = 1,
                Body = "the first test news item",
                DateCreated = DateTime.Now.AddDays(-3),
                Title = "The First Post"
            });

            brewClubDB.NewsItems.Add(new NewsItemData
             {
                 Id = 2,
                 Body = "the all important second news item",
                 DateCreated = DateTime.Now.AddDays(-3),
                 Title = "The Second Post"
             });

            brewClubDB.SaveChanges();
        }
    }
}
