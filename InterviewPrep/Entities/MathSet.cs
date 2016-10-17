using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Entities
{
    public class MathSet : IEnumerable, IPrintable
    {
        int[] Container { get; set; }

        int _counter { get; set; }

        public MathSet()
        {
            Container = new int[4];
        }

        public bool Contains(int element)
        {
            foreach (int i in this)
            {
                if (element.Equals(i))
                {
                    return true;
                }
            }

            return false;
        }

        public void Add(int element)
        {
            if (!Contains(element))
            {
                if (_counter == Container.Length - 1)
                {
                    IncrementSize();
                }

                Container[_counter] = element;

                _counter ++;
            }
        }

        public int Size()
        {
            return _counter;
        }

        private void IncrementSize()
        {
            int[] holder = new int[Container.Length];

            Container.CopyTo(holder, 0);

            Container = new int[Container.Length + 10];

            holder.CopyTo(Container, 0);
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

            foreach (int i in this)
            {
                builder.AppendLine(i.ToString());
            }

            return builder.ToString();
        }

    }
}
