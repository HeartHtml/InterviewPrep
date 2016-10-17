using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Entities
{
    public class SortedListWithArrayList : IEnumerable, IPrintable
    {
        public List<int> Container { get; set; }

        public SortedListWithArrayList()
        {
            Container = new List<int>();
        }

        public void Add(int item)
        {
            bool added = false;

            if (Container.Count == 0)
            {
                Container.Add(item);
                added = true;
            }

            if (!added)
            {
                int max = Container.Max();

                if (item > max)
                {
                    Container.Add(item);
                    added = true;
                }

                if (!added)
                {
                    int indexToInsert = 0;

                    while (item > Container[indexToInsert])
                    {
                        indexToInsert++;
                    }

                    Container.Insert(indexToInsert, item);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            return Container.GetEnumerator();
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            foreach(int item in this)
            {
                builder.AppendLine(item.ToString());
            }

            return builder.ToString();
        }
    }
}
