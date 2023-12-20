using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    public static class BalancingBracket
    {
        public static bool BalancingBracketMethod(string input)
        {
            Stack<char> stack = new Stack<char>();
            foreach(char c in input)
            {
                if (OpeninBrackets(c))
                {
                    stack.Push(c);
                }
                if (ClosingBrackets(c))
                {
                    if (!MatchingBrackets(stack.Pop(), c) && stack.Count == 0)
                    {
                        return false;
                    }
                }     
            }
            return true;
        }
        private static bool OpeninBrackets(char open)
        {
            return (open == '(' || open == '{' || open == '[');
        }
        private static bool ClosingBrackets(char close)
        {
            return (close == ')' || close == '}' || close == ']');
        }
        private static bool MatchingBrackets(char open, char close)
        {
            return (open == '(' && close == ')') ||
                   (open == '{' && close == '}') ||
                   (open == '[' && close == ']');
        }
    }
}