using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice1
{
    public static class HangmanGameList
    {
        static string? Answer { get; set; }
        public static int RandomMethod1(List<string> list)
        {
            Random r = new Random();
            int index = r.Next(list.Count);
            string thsiString = list[index];

            string qvedaTire = "";
            for (int i = 0; i < thsiString.Length; i ++)
            {
                qvedaTire += "_ ";
            }
            Console.WriteLine(qvedaTire);
            return index;
        }
        public static char ReadlineChar()
        {
            try
            {
                char readChar = Convert.ToChar(Console.ReadLine());
                return readChar;
            }
            catch
            {
                Console.WriteLine("shemoiyavne mxolod erti simbolo");
                return default;
            }
           
        }
        public static string  printAnswer(int index, char charInput, List<string> list)
        {
            string word = list[index];
           
            string printiedOutput =" ";

            for (int i = 0; i < list[index].Length; i++)
            {
                if (word[i] == charInput)
                {
                    printiedOutput += charInput +" ";
                }
                else
                {
                    printiedOutput += "_ ";
                }
            }
            Console.WriteLine(printiedOutput);
            Answer = printiedOutput;
            return printiedOutput;

        }


    }
}
