using System.Collections.Generic;
using System.Linq;
using System;

namespace eu_vote_calculator
{
    /* This class takes in a list of countries and allows different actions to be done on said list in regards to votes. */

    class VoteCalc
    {
        private List<Country> countries;
        public IEnumerable<Country> yesVotes, participationVotes;
        public List<Country> Countries
        {
            get => countries;
            set
            {
                countries = value;
                yesVotes = from countries in Countries
                           where countries.VoteChoice == 0
                           select countries;

                participationVotes = from countries in Countries
                           where countries.VoteChoice == 3
                           select countries;
            }
        }
        /* This is an enum for the vote choice. This makes it a lot easier to manage if a country has abstained or not. And it is
         * a lot easier to convert between the types. It also makes abstain the default option. */

        public enum VoteChoice
        {
            Yes, Abstain, No, Participation
        }

        public int AmountOfYesVotes() => yesVotes.Count();

        public double AmountOfYesPopulation()
        {
            double population = 0;

            for (int i = 0; i < yesVotes.Count(); i++)
                population += yesVotes.ElementAt(i).PopulationPercentage;

            return population;
        }

        public bool QualifiedMajority()
        {
            double population = 0;

            for (int i = 0; i < yesVotes.Count(); i++)
                population += yesVotes.ElementAt(i).PopulationPercentage;

            return yesVotes.Count() > 0.55 * Countries.Count && population > 65;
        }

        public bool ReinforcedQualifiedMajority() => Math.Round((double)yesVotes.Count() / (Countries.Count() - participationVotes.Count()), 2) >= 0.65;
        public bool SimpleMajority() => yesVotes.Count() >= 0.5 * (Countries.Count - participationVotes.Count());
        public bool Unanimity() => yesVotes.Count() == Countries.Count - participationVotes.Count();
        public VoteCalc(List<Country> countries) => Countries = countries;
    }
}
