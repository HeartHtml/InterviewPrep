using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Entities;
using InterviewPrep.Interfaces;

namespace InterviewPrep
{
    public class InterviewPrepApplication
    {
        IPrinter Printer { get; set; }

        public bool RunSortedListDemo { get; set; }

        public bool RunSortedArrayDemo { get; set; }

        public bool RunGraphDemo { get; set; }

        public bool RunCustomIteratorDemo { get; set; }

        public bool RunPalindromeDemo { get; set; }

        public bool RunWorldPopulationCounter { get; set; }

        public bool RunSetDemo { get; set; }

        public bool RunInsertionSort { get; set; }

        public bool RunNumberPairsDemo { get; set; }

        public bool RunExpressionValidatorDemo { get; set; }

        public bool RunPathFinderDemo { get; set; }

        public InterviewPrepApplication(IPrinter printer)
        {
            Printer = printer;
        }

        public void RunDemo()
        {
            if (RunSortedListDemo)
            {
                SortedListWithArrayList list = new SortedListWithArrayList();

                list.Add(56);

                list.Add(12);

                list.Add(98);

                list.Add(45);

                list.Add(7);

                list.Add(3);

                list.Add(1);

                list.Add(78);

                list.Add(4478);

                list.Add(-67);

                list.Add(-198);

                list.Add(6);

                list.Add(9);

                Printer.PrintToMedium(list.Print());
            }

            if (RunSortedArrayDemo)
            {

                SortedListWithArray array = new SortedListWithArray();

                array.Add(56);

                array.Add(12);

                array.Add(98);

                array.Add(45);

                array.Add(7);

                array.Add(3);

                array.Add(1);

                array.Add(78);

                array.Add(4478);

                array.Add(-67);

                array.Add(-198);

                array.Add(6);

                array.Add(9);

                Printer.PrintToMedium(array.Print());
            }

            if (RunGraphDemo)
            {
                Graph graph = new Graph();

                graph.Add(-5, 3);

                graph.Add(-2, 5);

                graph.Add(1, -4);

                graph.Add(4, 5);

                graph.Add(6, 4);

                Printer.PrintToMedium(graph.Print());

                GraphTuple[] mins = graph.GetLocalMin(-5, 6);

                foreach (GraphTuple tuple in mins)
                {
                    Printer.PrintToMedium(string.Format("({0},{1})", tuple.X, tuple.Y));
                }
            }

            if(RunCustomIteratorDemo)
            {
                List<int> test1 = new List<int>() { 1, 2, 3, 4, 5, 6 };

                List<int> test2 = new List<int>() { 7, 8, 9, 10, 11, 12 };

                List<int> test3 = new List<int>() { 13, 14, 15, 16, 17, 18 };

                List<int> test4 = new List<int>() { 19, 20, 21, 22, 23, 24 };

                List<int> test5 = new List<int>() { 25, 26, 27, 28, 29, 30 };

                CustomIteratorList iteratorList = new CustomIteratorList();

                iteratorList.Add(test1);

                iteratorList.Add(test2);
                 
                iteratorList.Add(test3);

                iteratorList.Add(test4);

                iteratorList.Add(test5);

                Printer.PrintToMedium(iteratorList.Print());
            }

            if (RunPalindromeDemo)
            {
                string testString = "mom";

                string testString2 = "12345654321";

                string testString3 = "fafasdfasd";

                string testString4 = "bob";

                Printer.PrintToMedium(string.Format("{0}: {1}", testString, PalindromeChecker.IsMatch(testString)));

                Printer.PrintToMedium(string.Format("{0}: {1}", testString2, PalindromeChecker.IsMatch(testString2)));

                Printer.PrintToMedium(string.Format("{0}: {1}", testString3, PalindromeChecker.IsMatch(testString3)));

                Printer.PrintToMedium(string.Format("{0}: {1}", testString4, PalindromeChecker.IsMatch(testString4)));
            }

            if (RunWorldPopulationCounter)
            {
                int population = WorldPopulationCounter.EstimatePopulation(new DateTime(2099, 5, 23));

                Printer.PrintToMedium(string.Format("Population on 5/23/2099 is: {0}", population));
            }

            if (RunSetDemo)
            {
                MathSet set = new MathSet();

                set.Add(10);

                set.Add(5);

                set.Add(5);

                set.Add(15);

                set.Add(89);

                set.Add(7);

                set.Add(98);

                Printer.PrintToMedium(set.Print());
            }

            if (RunInsertionSort)
            {
                int[] array = new int[] { 1, 10, 56, -45, 89, 4, -976, 100, 45 };

                InsertionSort.Sort(array);

                foreach (int i in array)
                {
                    Console.WriteLine(i);
                }
            }

            if (RunNumberPairsDemo)
            {
                List<int> testList = new List<int>();

                testList.Add(6);

                testList.Add(1);

                testList.Add(3);

                testList.Add(46);

                testList.Add(1);

                testList.Add(3);

                testList.Add(9);

                int numberOfPairs = NumberPairsChecker.NumberOfPairs(testList.ToArray(), 47);

                Printer.PrintToMedium(numberOfPairs.ToString());
            }

            if(RunExpressionValidatorDemo)
            {
                string expression1 = "{[()]}"; //valid
                string expression2 = "{{{}}}"; //valid
                string expression3 = "([({})])"; //valid
                string expression4 = "(()))"; //valid
                string expression5 = "AAAA"; //invalid
                string expression6 = "]]]";
                string expression7 = "}}}";
                string expression8 = "}";
                string expression9 = "{{{}}}]";
                string expression10 = "{";

                List<string> expressions = new List<string>
                { expression1, expression2, expression3, expression4, expression5, expression6, expression7, expression8, expression9, expression10};

                for (int i = 0; i < expressions.Count; i++)
                {
                    Printer.PrintToMedium(
                        $"Expression {i + 1} - {expressions[i]} is: {(ExpressionValidator.Validate(expressions[i]) ? "Valid" : "Invalid")}");
                }
            }

            if (RunPathFinderDemo)
            {
                int[][] matrix1 = {
                    new[] {1, 0, 1, 0},
                    new[] {1, 1, 0, 0},
                    new[] {0, 1, 1, 0},
                    new[] {1, 1, 1, 1},
                };

                int[][] matrix2 = {
                    new[] {1, 0, 1, 0},
                    new[] {1, 1, 1, 0},
                    new[] {0, 1, 0, 0},
                    new[] {1, 1, 1, 1},
                };

                int[][] matrix3 = {
                    new[] {1, 1, 1, 1},
                    new[] {1, 1, 1, 1},
                    new[] {1, 1, 1, 1},
                    new[] {1, 1, 1, 1},
                };

                List<Tuple<int, int>> path = PathFinder.FindPath(matrix1);

                Printer.PrintToMedium($"Path for Matrix 1 is");

                foreach (Tuple<int, int> tuple in path)
                {
                    Printer.PrintToMedium($"({tuple.Item1}, {tuple.Item2})");
                }

                path = PathFinder.FindPath(matrix2);

                Printer.PrintToMedium($"Path for Matrix 2 is");

                foreach (Tuple<int, int> tuple in path)
                {
                    Printer.PrintToMedium($"({tuple.Item1}, {tuple.Item2})");
                }

                path = PathFinder.FindPath(matrix3);

                Printer.PrintToMedium($"Path for Matrix 3 is");

                foreach (Tuple<int, int> tuple in path)
                {
                    Printer.PrintToMedium($"({tuple.Item1}, {tuple.Item2})");
                }
            }
        }
    }
}
