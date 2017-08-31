using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class TaskCancellable
    {
        public static void Run()
        {
            string stars = "*".PadRight(Console.WindowWidth - 1, '*');
            Console.WriteLine("Push ENTER to exit.");
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task task = Task.Run(() => WritePi(cancellationTokenSource.Token));
            Console.Read();
            cancellationTokenSource.Cancel();
            Console.WriteLine(stars);
            task.Wait();
            Console.WriteLine();
            Console.Read();
        }
        private static void WritePi(CancellationToken cancellationToken)
        {
            string piSection = string.Empty;
            int i = 0;
            while (!cancellationToken.IsCancellationRequested || i == int.MaxValue)
            {
                Console.Write(i++ + " ");
                Thread.Sleep(1);
            }
        }

    }
}

   