using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep.Entities
{
    public class ExpressionValidator
    {
        public const char LEFT_CURLY_BRACE = '{';

        public const char RIGHT_CURLY_BRACE = '}';

        public const char LEFT_PAREN = '(';

        public const char RIGHT_PAREN = ')';

        public const char LEFT_BRACKET = '[';

        public const char RIGHT_BRACKET = ']';

        protected static List<char> ValidCharacters = new List<char> { LEFT_CURLY_BRACE,
                                                                       RIGHT_CURLY_BRACE,
                                                                       RIGHT_BRACKET,
                                                                       LEFT_BRACKET,
                                                                       RIGHT_PAREN,
                                                                       LEFT_PAREN };

        protected static bool AreCharactersValid(string expression)
        {
            bool valid = true;

            if (!string.IsNullOrWhiteSpace(expression))
            {
                foreach (char token in expression)
                {
                    if (!ValidCharacters.Contains(token))
                    {
                        valid = false;
                    }
                }
            }

            return valid;
        }

        public static bool Validate(string expression)
        {
            bool isValid = false;

            if (AreCharactersValid(expression))
            {
                Stack<char> tokenizer = new Stack<char>(expression.Length);

                foreach (char token in expression)
                {
                    if (tokenizer.Count == 0)
                    {
                        tokenizer.Push(token);
                    }
                    else
                    {
                        if (AreOpposites(tokenizer.Peek(), token))
                        {
                            tokenizer.Pop();
                        }
                        else
                        {
                            tokenizer.Push(token);
                        }
                    }
                }
                
                isValid = tokenizer.Count == 0;
            }

            return isValid;
        }

        protected static bool AreOpposites(char left, char right)
        {
            if (left == LEFT_CURLY_BRACE && right == RIGHT_CURLY_BRACE)
            {
                return true;
            }

            if (left == LEFT_BRACKET && right == RIGHT_BRACKET)
            {
                return true;
            }

            if (left == LEFT_PAREN && right == RIGHT_PAREN)
            {
                return true;
            }

            return false;
        }

    }
}
