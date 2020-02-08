using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu_vote_calculator
{

    class VoteCalc
    {
        public enum VoteChoice
        {
            Yes,
            No,
            Abstain
        }

        public static void countryVotes(List<Country> x)
        {
            foreach (var item in x)
            {
                Console.WriteLine("Enter Yes, No or Abstain.");
                string input = Console.ReadLine().ToLower();
                switch (input)
                {
                    case "yes":
                        item.VoteChoice = (int)VoteChoice.Yes;
                        break;
                    case "no":
                        item.VoteChoice = (int)VoteChoice.No;
                        break;
                    case "abstain":
                        item.VoteChoice = (int)VoteChoice.Abstain;
                        break;
                    default:
                        Console.WriteLine("Enter a correct vote choice.");
                        break;
                }
            }
        }
    }
}
