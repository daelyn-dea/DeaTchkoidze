using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_21
{
    internal static class ErrorLog
    {
        internal static void ErrorLogInFile(string errorMessage, string errorStackTrace)
        {
            string logFilePath = @"C:\Users\dchko\Desktop\visual studio\.NET\Day_21\Logs.txt";

            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {errorMessage}: StackTrace: {errorStackTrace}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
