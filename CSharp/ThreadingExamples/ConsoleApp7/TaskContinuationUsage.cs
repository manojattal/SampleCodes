using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class TaskContinuationUsage
    {
        public static void Run()
        {
            Console.WriteLine("Before...");
            var taskA = Task.Run(() => Console.WriteLine("Starting..."))
                                        .ContinueWith(anticident => Console.WriteLine("Continuing A..."));
            var taskB = taskA.ContinueWith(anticident => Console.WriteLine("Continuing B"));
            var taskC = taskA.ContinueWith(anticident => Console.WriteLine("Continuing C"));
            Task.WaitAll(taskB, taskC);
            Console.WriteLine("Finshed...");
            Console.Read();
        }
    }
}
