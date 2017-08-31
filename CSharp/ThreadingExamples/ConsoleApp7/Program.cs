using ConsoleApp7;
using ConsoleApp7.Async;
using System;
using System.Threading;

public class Program
{
    public const int repititions = 1000;
    public static void Main()
    {
        //TaskIntro.Run();
        //TaskReturningResult.Run();
        //TaskContinuationUsage.Run();
        //TaskUnhandelledException.Run();
        //TaskCancellable.Run();
        //SyncCode.Run();
        //AsyncTPL.Run();
        asyncAwait.Run();

        //ThreadPool.QueueUserWorkItem(DoWork, '+');
        //ThreadStart threadStart = DoWork;
        //Thread thread = new Thread(threadStart);
        //thread.Start();

        //for (int count = 0; count < repititions; count++)
        //{
        //    Console.Write('-');
        //}
        ////DoWork('+');
        //thread.Join();
        Console.Read();
    }

    //public static void DoWork(object state)
    //{
    //    for (int count = 0; count < repititions; count++)
    //    {
    //        Console.Write(state);
    //    }
    //}
    public static void DoWork()
    {
        for (int count = 0; count < repititions; count++)
        {
            Console.Write('+');
        }
    }
}