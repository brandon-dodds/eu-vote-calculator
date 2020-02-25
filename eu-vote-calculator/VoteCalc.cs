using System.Collections.Generic;
using System.Linq;
using System;

namespace eu_vote_calculator
{
    /* This class takes in a list of countries and allows different actions to be done */

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

        /* Enumerator sets  the voting choice */
        public enum VoteChoice
        {
            Yes, Abstain, No, Participation
        }

        /* This counts the amount of yes votes and returns an integer value */
        public int AmountOfYesVotes() => yesVotes.Count();

        /* This counts the amount of yes votes based on the population and returns a double value */
        public double AmountOfYesPopulation()
        {
            double population = 0;

            for (int i = 0; i < yesVotes.Count(); i++)
                population += yesVotes.ElementAt(i).PopulationPercentage;

            return population;
        }

        /* This calculates the qualified majority and returns a boolean value */
        public bool QualifiedMajority()
        {
            double population = 0;

            for (int i = 0; i < yesVotes.Count(); i++)
                population += yesVotes.ElementAt(i).PopulationPercentage;

            return yesVotes.Count() > 0.55 * Countries.Count && population > 65;
        }

        /* This calculates the reinforced majority and returns a boolean value */
        public bool ReinforcedQualifiedMajority() => Math.Round((double)yesVotes.Count() / (Countries.Count() - participationVotes.Count()), 2) >= 0.65;

        /* This calculates the simple majority and returns a boolean value */
        public bool SimpleMajority() => yesVotes.Count() >= 0.5 * (Countries.Count - participationVotes.Count());

        /* This calculates the unanimity and returns a boolean value */
        public bool Unanimity() => yesVotes.Count() == Countries.Count - participationVotes.Count();

        public VoteCalc(List<Country> countries) => Countries = countries;
    }
}
