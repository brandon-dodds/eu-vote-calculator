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
            for(int i = 0; i < countryList.Count; i++)
            {
                Console.WriteLine("{0}, {1}",countryList[i].CountryName, countryList[i].PopulationPercentage.ToString());
            }
            Console.ReadKey();
        }
    }
}
