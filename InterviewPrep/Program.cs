using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterviewPrep.Interfaces;
using InterviewPrep.Printers;

namespace InterviewPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = TypeFactory.Create<ConsolePrinter>();

            InterviewPrepApplication app = new InterviewPrepApplication(printer)
            {
                RunCustomIteratorDemo = false,
                RunGraphDemo = false,
                RunSortedArrayDemo = false,
                RunSortedListDemo = false,
                RunPalindromeDemo = false,
                RunWorldPopulationCounter = false,
                RunSetDemo = false,
                RunInsertionSort =  false,
                RunNumberPairsDemo = false,
                RunExpressionValidatorDemo = false,
                RunPathFinderDemo = true
            };

            app.RunDemo();
        }
    }
}
