using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu_vote_calculator
{
    class Country
    {
        public string CountryName { get; set; }
        public double PopulationPercentage { get; set; }
        public int VoteChoice { get; set; }

        public Country(string CountryName, double PopulationPercentage)
        {
            this.CountryName = CountryName;
            this.PopulationPercentage = PopulationPercentage;
        }
    }
}
