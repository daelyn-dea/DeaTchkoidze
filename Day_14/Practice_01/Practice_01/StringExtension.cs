using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    public static class StringExtension
    {
        //Write an extension method for string that returns a reversed version of the
        //string.
        public static string ReversecString(this string input)
        {
            string result = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i];
            }
            return result;
        }

       // Write an extension method for string that counts the number of occurrences of
       //a given character(you should pass the character).
       public static int CountCaracterInString(this string input, char caracter)
        {
            int count = 0;
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == caracter)
                    count++;
            }
            return count;
        }

        public static string StartOrEndString(this string input, string substring)
        {
            string result = "input does not start or end by this substring";
            for(int i = 0; i < substring.Length;)
            {
                if (input[i] == substring[i] && i < substring.Length-1)
                {
                    i++;
                    continue;     
                }
                if (input[i] == substring[i])
                {
                    i++;
                    result = "input is started by this substring";
                }
                break;
            }
            for (int i = substring.Length-1, k = input.Length-1; i >= 0;)
            {
                if (input[k] == substring[i] && i > 0)
                {
                    i--;
                    k--;
                    continue;
                }
                if (input[k] == substring[i])
                {
                    i--;
                    result = "input is ended by this substring";
                }
                break;
            }
            return result;
        }
    }
}
