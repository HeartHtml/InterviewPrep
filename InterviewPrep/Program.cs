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
                RunCustomIteratorDemo = true,
                RunGraphDemo = true,
                RunSortedArrayDemo = true,
                RunSortedListDemo = true,
                RunPalindromeDemo = true,
                RunWorldPopulationCounter = true,
                RunSetDemo = true
            };

            app.RunDemo();
        }
    }
}
