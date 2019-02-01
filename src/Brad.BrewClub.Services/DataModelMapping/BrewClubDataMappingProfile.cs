using AutoMapper;
using Brad.BrewClub.Data;
using Brad.BrewClub.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brad.BrewClub.Services.DataModelMapping
{
    public class BrewClubDataMappingProfile : Profile
    {
        public BrewClubDataMappingProfile()
        {
            CreateMap<NewsItemData, NewsItem>();
        }
    }
}
