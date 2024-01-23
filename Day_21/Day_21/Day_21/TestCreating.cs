using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    internal class TestCreating
    {
        static string Question { get; set; }
        static string Answer1 { get; set; }
        static string Answer2 { get; set; }
        static string Answer3 { get; set; }
        static string Answer4 { get; set; }

        public static string convertTostring()
        {
            return $"{Question}|{Answer1}|{Answer2}|{Answer3}|{Answer4}";
        }
        public void AppendTestToFail(string str)
        {
            File.AppendText(str);
        }
        public static void fillFidles()
        {
            Console.Write("Enter the question : ");
            Question = Console.ReadLine();
            Console.WriteLine("Enter 4 answers separating Enter button, if the answer is correct select it\r\nwith ‘*’");
            Console.Write("Answer 1 : ");
            Answer1 = Console.ReadLine();
            Console.Write("Answer 2 : ");
            Answer2 = Console.ReadLine();
            Console.Write("Answer 3 : ");
            Answer3 = Console.ReadLine();
            Console.Write("Answer 4 : ");
            Answer4 = Console.ReadLine();
        }
        public static void IsEveryAnswerDifferent()
        {
                HashSet<string> answers = new HashSet<string>();
                bool canAddAnswer = answers.Add(Answer1);
                canAddAnswer = answers.Add(Answer2);
                canAddAnswer = answers.Add(Answer3);
                canAddAnswer = answers.Add(Answer4);
                if (!canAddAnswer)
                {
                    Console.WriteLine("Answers must be different");
                    throw new Exception();
                }
                bool endWith = false;
                foreach(string str in answers)
                {
                    if (str.EndsWith("*"))
                    {
                        endWith = true;
                    }
                }
                if (!endWith)
                {
                    Console.WriteLine("if the answer is correct select it with ‘*’ symbol at the end!");
                    throw new Exception();
                }
        }
    }
}
