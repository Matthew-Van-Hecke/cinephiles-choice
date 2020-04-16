using CinephilesChoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinephilesChoice.Services
{
    public static class NominationImporter
    {
        public static void ImportNominations()
        {
            List<CSVEntry> lines = CSVReader.ReadCSV("../../oscar_nominations_csv.csv");
            foreach (CSVEntry entry in lines)
            {

            }
        }
    }
}
