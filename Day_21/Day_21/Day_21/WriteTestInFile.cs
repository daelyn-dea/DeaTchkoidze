using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    internal class WriteTestInFile
    {
        public static void CallCreateTest()
        {
            string failpath = @"C:\Users\dchko\Desktop\visual studio\.NET\Day_21\Test.txt";

            TestCreating.fillFidles();
            TestCreating.IsEveryAnswerDifferent();

            using (StreamWriter sw = File.AppendText(failpath))
            {
                sw.WriteLine();
                sw.WriteLine(TestCreating.convertTostring());
            }
        }
    }
}
