using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class TaskUnhandelledException
    {
        public static void Run()
        {

            var task = Task.Run(() =>
            {
                throw new InvalidOperationException();
            });
            try
            {

                task.Wait();
            }
            catch (AggregateException exception)
            {
                exception.Handle(eachException =>
                {
                    Console.WriteLine("ERROR: { eachException.Message }");
                    return true;
                });
            }


            Console.Read();
        }
    }
}
