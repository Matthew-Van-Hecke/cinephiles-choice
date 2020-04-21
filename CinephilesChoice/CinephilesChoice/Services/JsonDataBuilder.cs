using CinephilesChoice.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class JsonDataBuilder
    {
        public static string CreateJsonVoteCollection(List<Vote> votes)
        {
            var votesStringList = votes.SelectMany(,)
            string votesAsJsonString = JsonConvert.SerializeObject(votes);
            return votesAsJsonString;
        }
    }
}
