using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class NumberPairsChecker
    {
        public static int NumberOfPairs(int[] a, long k)
        {
            HashSet<long> table = new HashSet<long>();

            List<Tuple<long, long>> numberOfPairsEqualToK = new List<Tuple<long, long>>(a.Length);

            foreach (int number in a)
            {
                long valueToSum = Convert.ToInt64(k) - Convert.ToInt64(number);

                if (!table.Contains(valueToSum))
                {
                    table.Add(number);
                }
                else
                {
                    numberOfPairsEqualToK.Add(new Tuple<long, long>(number, valueToSum));
                }
            }

            List<Tuple<long, long>> distinctTuples = new List<Tuple<long, long>>();

            foreach (Tuple<long, long> pairs in numberOfPairsEqualToK)
            {
                Tuple<long, long> foundPair =
                    distinctTuples.FirstOrDefault(
                    dd =>
                    (dd.Item1 == pairs.Item1 && dd.Item2 == pairs.Item2) ||
                    (dd.Item1 == pairs.Item2 && dd.Item2 == pairs.Item1));

                if (foundPair == null)
                {
                    distinctTuples.Add(pairs);
                }
            }

            return distinctTuples.Count;
        }
    }
}
