namespace eu_vote_calculator
{
    class Country
    {
        /* Country class, contains name, population percentage and VoteChoice. 
         * VoteChoice is an int here as a default int value is 0 which is in the enum for Abstain. */
        public string CountryName { get; set; }
        public double PopulationPercentage { get; set; }
        public int VoteChoice { get; set; }

        public Country(string CountryName, double PopulationPercentage)
        {
            this.CountryName = CountryName;
            this.PopulationPercentage = PopulationPercentage;
        }
    }
}
