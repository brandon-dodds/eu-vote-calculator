using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eu_vote_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List < Country > countryList = new List<Country>();
            string[] textFile = File.ReadAllLines(@"C:\Users\Brandon\source\repos\eu-vote-calculator\eu-vote-calculator\CountryList.txt");
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
