using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class Visit
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }

    public static class VisitDeterminator
    {
        public static Tuple<DateTime, int> Max(List<Visit> visits)
        {
            DateTime peakTime = new DateTime(1,1,1);

            int peakTimes = 0;

            DateTime currentStart = visits.Min(dd => dd.Start);

            DateTime maxEnd = visits.Max((dd => dd.End));

            while (currentStart <= maxEnd)
            {
                List<Visit> visitsByTime =
                    visits.Where(dd => dd.Start >= currentStart && currentStart <= dd.End).ToList();

                int numberOfVisitsInTime = visitsByTime.Count;

                DateTime potentialStart = currentStart;

                if (numberOfVisitsInTime > peakTimes)
                {
                    peakTimes = numberOfVisitsInTime;

                    peakTime = potentialStart;
                }

                currentStart = currentStart.AddMilliseconds(1);
            }

            Tuple<DateTime, int> maxTuple = new Tuple<DateTime, int>(peakTime, peakTimes);

            return maxTuple;
        } 
    }
}
