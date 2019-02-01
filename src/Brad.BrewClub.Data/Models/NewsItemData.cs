using System;

namespace Brad.BrewClub.Data
{
    public class NewsItemData
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
