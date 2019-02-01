using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brad.BrewClub.Data
{
    public class BrewClubDbContext : DbContext
    {
        public BrewClubDbContext(DbContextOptions<BrewClubDbContext> options)
            : base(options)
        {

        }

        public DbSet<NewsItemData> NewsItems { get; set; }
    }
}
