using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public static class Logger
    {
        public static void LogInConsole(string message)
        {
            Console.WriteLine(message); 
        }

        public static void LogInFile(string message)
        {
            using (StreamWriter streamwriter = new StreamWriter(message))
            {
                streamwriter.WriteLine(message);    
            }
        }
    }
}
