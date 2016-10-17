using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class WorldPopulationCounter
    {
        public static int CURRENT_POPULATION
        {
            get { return 325000000; }
        }

        public static double CURRENT_BIRTH_RATE_PER_SECOND
        {
            get { return .125; }
        }

        public static double CURRENT_DEATH_RATE_PER_SECOND
        {
            get { return 0.077; }
        }

        public static int EstimatePopulation(DateTime simulatedDate)
        {
            Contract.Requires(simulatedDate > DateTime.Today);

            TimeSpan totalTime = simulatedDate - DateTime.Now;

            double totalBirths = totalTime.TotalSeconds * CURRENT_BIRTH_RATE_PER_SECOND;

            double totalDeaths = totalTime.TotalSeconds * CURRENT_DEATH_RATE_PER_SECOND;

            double netGain = totalBirths - totalDeaths;

            int population = Convert.ToInt32(Math.Round(CURRENT_POPULATION + netGain));

            return population;
        }
    }
}
