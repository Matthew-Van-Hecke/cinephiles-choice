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
        public static string CreateJsonVoteCollection(NominationViewModel viewModel)
        {
            List<NomineeDateOfVoteViewModel> votesObjectList = viewModel.Votes.Select(v => new NomineeDateOfVoteViewModel(v.Date.Year, viewModel.Nominations.Where(n => n.Id == v.NominationId).First().Nominee.Replace("\"", ""))).ToList();
            List<string> votesAsStringList = votesObjectList.Select(v => JsonConvert.SerializeObject(v)).ToList();
            string votesAsJsonString = JsonConvert.SerializeObject(votesAsStringList);
            return votesAsJsonString;
        }
        public static string CreateJsonStringFromStringList(List<string> stringList)
        {
            return JsonConvert.SerializeObject(stringList);
        }
    }
}
