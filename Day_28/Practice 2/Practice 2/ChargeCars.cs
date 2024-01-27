using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{

    internal static class ChargeCars
    {
        private static CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public static double RunChargingTasks(List<ElectricCar> cars)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Task[] tasks = new Task[cars.Count];

            for (int i = 0; i < cars.Count; i++)
            {
                int index = i;
                tasks[index] = Task.Run(() => cars[index].Charge());
            }

            Task isCompleted = Task.WhenAll(tasks);

            while (true)
            {
                if (stopWatch.Elapsed.TotalSeconds > 200 || isCompleted.IsCompletedSuccessfully)
                {
                    cancellationTokenSource.Cancel();
                    stopWatch.Stop();
                    return stopWatch.Elapsed.TotalSeconds;
                }
            }
        } 
    }
}
