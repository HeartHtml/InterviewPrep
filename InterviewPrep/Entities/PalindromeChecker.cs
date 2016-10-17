using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class PalindromeChecker
    {
        public static bool IsMatch(string palindrome)
        {
            if (string.IsNullOrWhiteSpace(palindrome))
            {
                return true;
            }
            if (palindrome.Length == 1)
            {
                return true;
            }
            if (palindrome[0].Equals(palindrome[palindrome.Length - 1]))
            {
                string newTestString = palindrome.Substring(1, palindrome.Length - 2);

                return IsMatch(newTestString);
            }

            return false;
        }
    }
}
