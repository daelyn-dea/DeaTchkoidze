using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public static class FileWriter
    {
        private static string Path = "../../../";
        public static async Task FileWriterAsync(int num)
        {
            using (StreamWriter sw = new StreamWriter($"{Path}{num}.txt",true))
            {
                await Task.Delay(num * 100);
                sw.WriteLine($"Task.{num}");
            }
        }
    }
}
