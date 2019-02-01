using AutoMapper;
using Brad.BrewClub.Services.DataModelMapping;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Brad.BrewClub.ServicesTests.UnitTests.DataModelMapping
{
    public class BrewClubDataMappingProfileTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void AutoMapperMapsAllBrewClubModels()
        {
            Mapper.Initialize(cfg =>
              cfg.AddProfile<BrewClubDataMappingProfile>());

            Mapper.AssertConfigurationIsValid();
        }
    }
}
