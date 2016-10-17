using System.Collections;
using System.Text;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Entities
{
    public class SortedListWithArray : IEnumerable, IPrintable
    {
        int[] Container
        {
            get; set;
        }

        int _counter { get; set; }

        public SortedListWithArray()
        {
            Container = new int[3];
        }

        private void IncrementSize()
        {
            int[] holder = new int[Container.Length];

            Container.CopyTo(holder, 0);

            Container = new int[Container.Length * 2];

            holder.CopyTo(Container, 0);
        }

        private int Max()
        {
            int max = 0;

            foreach(int i in Container)
            {
                if(i > max)
                {
                    max = i;
                }
            }

            return max;
        }

        private int Min()
        {
            int min = 0;

            foreach(int i in Container)
            {
                if(i < min)
                {
                    min = i;
                }
            }

            return min;
        }

        private void Insert(int index, int item)
        {
            int[] holder = new int[Container.Length];

            int j = 0;

            for(int i = 0; i < _counter; i ++)
            {
                if(i == index)
                {
                    j++;
                }

                holder[j] = Container[i];

                j++;
            }

            holder[index] = item;

            Container = new int[holder.Length];

            holder.CopyTo(Container, 0);
        }

        public void Add(int item)
        {
            bool added = false;

            if(Container.Length == 0)
            {
                Container[0] = item;

                added = true;
            }
            else
            { 
                if (Container.Length == _counter)
                {
                    IncrementSize();
                }

                int max = Max();

                if(item > max)
                {
                    Container[_counter] = item;

                    added = true;
                }

                if(!added)
                {
                    int indexToInsert = 0;

                    while(item > Container[indexToInsert])
                    {
                        indexToInsert++;
                    }

                    Insert(indexToInsert, item);

                    added = true;
                }
            }

            if(added)
            {
                _counter++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _counter; i ++)
            {
                yield return Container[i];
            }
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            foreach(int i in this)
            {
                builder.AppendLine(i.ToString());
            }

            return builder.ToString();
        }
    }

}
