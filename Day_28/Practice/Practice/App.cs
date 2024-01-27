using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public static class App
    {
        private static CancellationTokenSource cancellationTokenSource = new();

        public static void Start()
        {
            TaskRun();
            CancelToken();
        }

        private static void TaskRun()
        {
            for(int i = 1; i <= 10; i++)
            {
                int index = i;
                Task.Run(() =>
                {
                    while (!cancellationTokenSource.IsCancellationRequested)
                    {
                        FileWriter.FileWriterAsync(index);
                    }
                });
            }
        }

        private static void CancelToken()
        {
            Console.WriteLine("Enter x to cancel toke");
            while(!cancellationTokenSource.IsCancellationRequested)
            {
                string input = Console.ReadLine();
                if ( input.ToLower() == "x")
                {
                    cancellationTokenSource.Cancel();   
                }
            }
        }
    }
}
