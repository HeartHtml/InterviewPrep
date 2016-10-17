using System.Collections;
using System.Collections.Generic;
using System.Text;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Entities
{
    public class CustomIteratorList : IEnumerable, IPrintable
    {
        List<List<int>> Container { get; set; }

        public CustomIteratorList()
        {
            Container = new List<List<int>>();
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < Container.Count; i ++)
            {
                yield return Container[i];
            }
        }

        public void Add(List<int> list)
        {
            Container.Add(list);
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            int listCounter = 1;

            foreach(List<int> child in this)
            {
                builder.AppendLine(string.Format("List {0}", listCounter));

                foreach(int i in child)
                {
                    builder.AppendLine(i.ToString());
                }

                listCounter++;
            }

            return builder.ToString();
        }
    }
}
