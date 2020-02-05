using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eu_vote_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Country Belgium = new Country("Belgium", 0.75);
            Console.WriteLine(Belgium.PopulationPercentage);
            Console.ReadKey();
        }
    }
}
