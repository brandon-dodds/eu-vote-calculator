using System;
using System.Collections.Generic;
using System.Linq;

namespace eu_vote_calculator
{

    class VoteCalc
    {  
        /* This is an enum for the vote choice. This makes it a lot easier to manage if a country has abstained or not. And it is
         * a lot easier to convert between the types. It also makes abstain the default option. */

        public enum VoteChoice
        {
            Abstain,
            Yes,
            No,
        }

        public static void CountryVotes(List<Country> x)
        {
            foreach (var item in x)
            {
                Console.Clear();
                ShowVotes(x);
                Console.WriteLine("Country: {0}. \nEnter (Y)es, (N)o or (A)bstain.", item.CountryName);
                string input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "y":
                        item.VoteChoice = (int)VoteChoice.Yes;
                        break;
                    case "n":
                        item.VoteChoice = (int)VoteChoice.No;
                        break;
                    case "a":
                        item.VoteChoice = (int)VoteChoice.Abstain;
                        break;
                    default:
                        Console.WriteLine("Choosing Abstain by default, press any key.");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }

        public static void ShowVotes(List<Country> x)
        {
            /* This is what is known as a LINQ Query! It's cool as it allows us to use an SQL like system to figure
             * who voted yes or not. We can use this to get a percentage for the vote mechanics! */

            IEnumerable<Country> yesVotes =
                from countries in x
                where countries.VoteChoice == 1
                select countries;

            Console.WriteLine("{0} Countries have voted yes out of {1}", yesVotes.Count(), x.Count());
        }
    }
}
