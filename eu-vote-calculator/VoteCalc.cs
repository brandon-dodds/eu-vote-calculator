using System.Collections.Generic;
using System.Linq;

namespace eu_vote_calculator
{
    /* This class takes in a list of countries and allows different actions to be done on said list in regards to votes. */

    class VoteCalc
    {
        public List<Country> Countries { get; set; }
        /* This is an enum for the vote choice. This makes it a lot easier to manage if a country has abstained or not. And it is
         * a lot easier to convert between the types. It also makes abstain the default option. */

        public enum VoteChoice
        {
            Abstain,
            Yes,
            No,
        }

        public int AmountOfYesVotes()
        {
            /* This is what is known as a LINQ Query! It's cool as it allows us to use an SQL like system to figure
             * who voted yes or not. We can use this to get a percentage for the vote mechanics! */

            IEnumerable<Country> yesVotes =
                from countries in Countries
                where countries.VoteChoice == 1
                select countries;

            return yesVotes.Count();
        }

        public double AmountOfYesPopulation()
        {
            double population = 0;
            IEnumerable<Country> yesVotes =
                from countries in Countries
                where countries.VoteChoice == 1
                select countries;

            foreach (Country country in yesVotes)
            {
                population += country.PopulationPercentage;
            }

            return population;
        }

        public VoteCalc(List<Country> countries)
        {
            Countries = countries;
        }
    }
}
