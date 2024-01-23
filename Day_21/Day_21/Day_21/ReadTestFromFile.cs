using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    internal class ReadTestFromFile
    {
        internal static void ReadFileMethod()
        {
            string path = @"C:\Users\dchko\Desktop\visual studio\.NET\Day_21\Test.txt";
            using (StreamReader sr = new StreamReader(path))
            {
                var line = sr.ReadLine();
            if (line != null)
            {

                string[] pathArray = File.ReadAllLines(path);

            List<Test> readedTestList = new List<Test>();
            foreach (string str in pathArray)
            {
                readedTestList.Add(Test.parseMethod(str));
            }

            int count = 0;
            for (int i = 0; i < readedTestList.Count; i++)
            {
                Console.WriteLine(readedTestList[i].QuestionText);
                Console.WriteLine(readedTestList[i].Answer1);
                Console.WriteLine(readedTestList[i].Answer2);
                Console.WriteLine(readedTestList[i].Answer3);
                Console.WriteLine(readedTestList[i].Answer4);

                string correct = Console.ReadLine();
                if (readedTestList[i].IsCorrectAnswer(correct))
                {
                    count++;
                }

            }
            Console.WriteLine($"Total score {count}/{readedTestList.Count}"); ;
                }
                else
                {
                    throw new Exception($"File is empty");
                }
            }
        }
    }
}
