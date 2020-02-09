using System;
using System.Collections.Generic;
using System.IO;

namespace eu_vote_calculator
{
    class Program
    {
        static void TakeVotes(VoteCalc voteCalculator, List<Country> countryList)
        {
            foreach (var item in countryList)
            {
                voteCalculator.Countries = countryList;
                Console.Clear();
                Console.WriteLine("{0} Countries have voted yes out of {1}.", voteCalculator.AmountOfYesVotes(), voteCalculator.Countries.Count);
                Console.WriteLine("{0}% of the population have voted yes.", voteCalculator.AmountOfYesPopulation());
                Console.WriteLine("Country: {0}. \nEnter (Y)es, (N)o or (A)bstain.", item.CountryName);
                string input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "y":
                        item.VoteChoice = (int)VoteCalc.VoteChoice.Yes;
                        break;
                    case "n":
                        item.VoteChoice = (int)VoteCalc.VoteChoice.No;
                        break;
                    case "a":
                        item.VoteChoice = (int)VoteCalc.VoteChoice.Abstain;
                        break;
                    default:
                        Console.WriteLine("Choosing Abstain by default, press any key.");
                        Console.ReadKey();
                        break;
                }
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {

            //All this does is creates a list of country objects from the file given.
            
            List < Country > countryList = new List<Country>();
            string[] textFile = File.ReadAllLines("CountryList.txt");

            for (int i = 0; i < textFile.Length; i++)
            {
                string[] splitText = textFile[i].Split(',');
                Country countryObject = new Country(splitText[0], double.Parse(splitText[1]));
                countryList.Add(countryObject);
            }

            /* This then takes all the countries and takes their votes. */
            VoteCalc voteCalculator = new VoteCalc(countryList);
            TakeVotes(voteCalculator, countryList);
            
        }
    }
}
