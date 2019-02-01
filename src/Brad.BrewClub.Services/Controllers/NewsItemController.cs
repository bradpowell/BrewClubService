using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Brad.BrewClub.Data;
using Brad.BrewClub.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brad.BrewClub.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsItemController : ControllerBase
    {
        private BrewClubDbContext brewClubDbContext;
        private IMapper dataModelMapper;

        public NewsItemController(BrewClubDbContext brewClubDbContext, IMapper dataModelMapper)
        {
            this.brewClubDbContext = brewClubDbContext;
            this.dataModelMapper = dataModelMapper;
        }

        // GET api/newsitem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsItem>>> Get()
        {
            var newsItems = await brewClubDbContext.NewsItems.ToListAsync();

            return dataModelMapper.Map<List<NewsItemData>, List<NewsItem>>(newsItems);
        }

        // GET api/newsitem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsItemData>> Get(int id)
        {
            var newsItem = await brewClubDbContext.NewsItems.FindAsync(id);

            if (newsItem == null)
            {
                return NotFound();
            }
            else
            {
                return newsItem;
            }

        }

        // POST api/newsitem
        [HttpPost]
        public void Post([FromBody] NewsItemData value)
        {
        }

        // PUT api/newsitem/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/newsitem/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
