using System.Collections.Generic;

namespace AB.TwitterAPI.Models
{
    public class SearchResponse : ModelBase
    {
        public List<Status> Statuses { get; set; }
    }
}