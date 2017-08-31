using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class TaskReturningResult
    {
        public static void Run()
        {
            var task = Task.Run<string>(() => CallMe());
            foreach (char busySymbol in Utility.BusySymbols())
            {
                if (task.IsCompleted)
                {
                    Console.Write('\b');
                    break;
                }
                Console.Write(busySymbol);
            }
            Console.WriteLine();
            Console.WriteLine(task.Result);
            System.Diagnostics.Trace.Assert(task.IsCompleted);
        }

        private static string CallMe()
        {
            Thread.Sleep(1000);
            return "hi";
        }
    }

    public class Utility
    {
        public static IEnumerable<char> BusySymbols()
        {
            string busySymbols = @"-\|/-\|/";
            int next = 0;
            while (true)
            {
                yield return busySymbols[next];
                next = (next + 1) % busySymbols.Length;
                yield return '\b';
            }
        }
    }
}
