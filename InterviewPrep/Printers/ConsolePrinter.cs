using System;
using InterviewPrep.Interfaces;

namespace InterviewPrep.Printers
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintToMedium(string content)
        {
            Console.WriteLine(content);
        }
    }
}
