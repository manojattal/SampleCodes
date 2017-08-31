using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class TaskIntro
    {
        public static void Run()
        {
            const int repetitions = 1000000000;
            Task task = Task.Run(() =>
            {
                for (int count = 0; count < repetitions; count++)
                    Console.Write("-");
            });
            for (int count = 0; count < repetitions; count++)
                Console.Write("+");
            task.Wait();
            
        }
    }
}
