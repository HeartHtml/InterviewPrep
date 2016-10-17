using System.Collections;
using System.Linq;
using System.Text;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Entities
{
    public class Graph : IEnumerable, IPrintable
    {
        GraphTuple[] Plot { get; set; }

        int _counter { get; set; }

        public Graph()
        {
            Plot = new GraphTuple[2];

            _counter = 0;
        }

        private GraphTuple[] IncrementArray(GraphTuple[] array)
        {
            GraphTuple[] holder = new GraphTuple[array.Length];

            array.CopyTo(holder, 0);

            array = new GraphTuple[array.Length + 10];

            holder.CopyTo(array, 0);

            return array;
        }

        public void Add(int x, int y)
        {
            if (_counter == Plot.Length)
            {
                Plot = IncrementArray(Plot);
            }

            GraphTuple tuple = new GraphTuple();

            tuple.X = x;

            tuple.Y = y;

            Plot[_counter] = tuple;

            _counter++;
        }

        public GraphTuple[] GetLocalMin(int min, int max)
        {
            GraphTuple[] minTuple = new GraphTuple[5];

            int minTupleCounter = 0;

            for (int i = 0; i < _counter; i++)
            {
                GraphTuple tuple = Plot[i];

                if (tuple.X < min)
                {
                    continue;
                }

                if (tuple.X > max)
                {
                    break;
                }

                int x = Plot[i].X;

                int currentY = Plot[i].Y;

                int? previousY = null;

                int? nextY = null;

                if (minTuple.Length == minTupleCounter)
                {
                    minTuple = IncrementArray(minTuple);
                }

                if (i == 0)
                {
                    nextY = Plot[i + 1].Y;

                    if (nextY > currentY)
                    {
                        GraphTuple localMin = new GraphTuple();

                        tuple.X = x;

                        tuple.Y = currentY;

                        localMin.X = x;

                        localMin.Y = currentY;

                        minTuple[minTupleCounter] = localMin;

                        minTupleCounter++;
                    }
                }
                else if (i > 0 && i < _counter - 1)
                {
                    previousY = Plot[i - 1].Y;

                    nextY = Plot[i + 1].Y;

                    if (currentY < previousY && currentY < nextY)
                    {
                        GraphTuple localMin = new GraphTuple();

                        tuple.X = x;

                        tuple.Y = currentY;

                        localMin.X = x;

                        localMin.Y = currentY;

                        minTuple[minTupleCounter] = localMin;

                        minTupleCounter++;
                    }
                }
                else if (i > 0 && i == _counter - 1)
                {
                    previousY = Plot[i - 1].Y;

                    if (previousY > currentY)
                    {
                        GraphTuple localMin = new GraphTuple();

                        tuple.X = x;

                        tuple.Y = currentY;

                        localMin.X = x;

                        localMin.Y = currentY;

                        minTuple[minTupleCounter] = localMin;

                        minTupleCounter++;
                    }
                }
            }

            return minTuple.Where(dd => dd != null).ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < _counter; i ++)
            {
                yield return Plot[i];
            }
        }

        public string Print()
        {
            StringBuilder builder = new StringBuilder();

            foreach(GraphTuple tuple in this)
            {
                builder.AppendLine(string.Format("({0},{1})", tuple.X, tuple.Y));
            }

            return builder.ToString();
        }
    }

    public class GraphTuple
    {
        public int X { get; set; }

        public int Y { get; set; }

        public GraphTuple()
        {
            X = 0;

            Y = 0;
        }
    }
}
