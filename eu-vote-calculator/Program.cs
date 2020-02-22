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

            List<Country> countryList = new List<Country>();
            string[] textFile = File.ReadAllLines("CountryList.txt");

            for (int i = 0; i < textFile.Length; i++)
            {
                string[] splitText = textFile[i].Split(',');
                if (double.TryParse(splitText[1], out double population))
                {
                    Country countryObject = new Country(splitText[0], population);
                    countryList.Add(countryObject);
                }
                else
                {
                    Console.WriteLine($"{splitText[0]} has an invalid population. Skipping...");
                    Console.ReadKey();
                }
            }
            while (true)
            {
                Console.Clear();
                VoteCalc voteCalc = new VoteCalc(countryList);
                Console.WriteLine($"EU Voting Calculator");
                Console.WriteLine($"{voteCalc.AmountOfYesVotes()} Countries out of {voteCalc.Countries.Count} have voted yes.\n" +
                    $"{Math.Round(voteCalc.AmountOfYesPopulation(),0)}% Percent of the population voted yes.\n" + 
                    $"Has Qualified Majority passed?: {voteCalc.QualifiedMajority()}\n" +
                    $"Has Unanimity?: {voteCalc.Unanimity()}\n" +
                    $"Has Simple Majority?: {voteCalc.SimpleMajority()}\n"+
                    $"Has Reinforced Qualified Majority?: {voteCalc.ReinforcedQualifiedMajority()}\n" +
                    $"Please select a country");
                for (int i = 0; i < voteCalc.Countries.Count; i++)
                    Console.WriteLine($"[{i}] {voteCalc.Countries[i].CountryName}: {(VoteCalc.VoteChoice)voteCalc.Countries[i].VoteChoice}");

                bool tryParseIntCountry = int.TryParse(Console.ReadLine(), out int intUserCountry);
                if (tryParseIntCountry)
                {
                    Console.Clear();
                    Console.WriteLine($"Changing vote for {voteCalc.Countries[intUserCountry].CountryName}");
                    Console.WriteLine("Choose (Y)es, (N)o, (A)bstain or (P)articipation");
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
                        case "p":
                            countryList[intUserCountry].VoteChoice = (int)VoteCalc.VoteChoice.Participation;
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
