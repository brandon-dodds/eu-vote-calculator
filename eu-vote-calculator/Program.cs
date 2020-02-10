using System;
using System.Collections.Generic;
using System.IO;

namespace eu_vote_calculator
{
    class Program
    {
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
            while (true)
            {
                Console.Clear();
                VoteCalc voteCalc = new VoteCalc(countryList);
                Console.WriteLine("{0} Countries out of {1} have voted yes.",voteCalc.AmountOfYesVotes(), voteCalc.Countries.Count);
                Console.WriteLine("{0}% Percent of the population voted yes.", voteCalc.AmountOfYesPopulation());
                Console.WriteLine("Please select a country");
                for (int i = 0; i < voteCalc.Countries.Count; i++)
                {
                    Console.WriteLine("[{0}] {1}: {2}", i, voteCalc.Countries[i].CountryName, (VoteCalc.VoteChoice)voteCalc.Countries[i].VoteChoice);
                }
                bool tryParseIntCountry = int.TryParse(Console.ReadLine(), out int intUserCountry);
                if (tryParseIntCountry)
                {
                    Console.Clear();
                    Console.WriteLine("Changing vote for {0}", voteCalc.Countries[intUserCountry].CountryName);
                    Console.WriteLine("Choose (Y)es, (N)o or (A)bstain.");
                    var userChoice = Console.ReadLine();
                    switch (userChoice.Trim().ToLower())
                    {
                        case "y":
                            countryList[intUserCountry].VoteChoice = (int)VoteCalc.VoteChoice.Yes;
                            break;
                        case "n":
                            countryList[intUserCountry].VoteChoice = (int)VoteCalc.VoteChoice.No;
                            break;
                        case "a":
                            countryList[intUserCountry].VoteChoice = (int)VoteCalc.VoteChoice.Abstain;
                            break;
                        default:
                            Console.WriteLine("Abstaining by default.");
                            Console.ReadKey();
                            countryList[intUserCountry].VoteChoice = (int)VoteCalc.VoteChoice.Abstain;
                            break;
                    }
                }
            }
        }
    }
}
