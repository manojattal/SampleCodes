using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Async
{
    class AsyncTPL
    {
        public static void Run()
        {
            string url = "http://google.com";
            Console.WriteLine("Opening " + url + "....");
            Task task = WriteWebRequestSizeAsync(url);
            try
            {
                while (!task.Wait(100))
                {
                    Console.Write(".");
                }
            }
            catch (AggregateException exception)
            {
                exception = exception.Flatten();
                try
                {
                    exception.Handle(innerException =>
                    {
                        // Rethrowing rather than using
                        // if condition on the type.
                        ExceptionDispatchInfo.Capture(
                        exception.InnerException)
                        .Throw();
                        return true;
                    });
                }
                catch (WebException)
                {
                    // ...
                }
                catch (IOException)
                {
                    // ...
                }
                catch (NotSupportedException)
                {
                    // ...
                }
            }        
        }
        private static Task WriteWebRequestSizeAsync(string url)
        {
            StreamReader reader = null;
            WebRequest webRequest =  WebRequest.Create(url);
            Task task = webRequest.GetResponseAsync()
                            .ContinueWith(antecedent =>
                            {
                                WebResponse response = antecedent.Result;
                                reader = new StreamReader(response.GetResponseStream());
                                return reader.ReadToEndAsync();
                            })
                            .Unwrap()
                            .ContinueWith(antecedent =>
                            {
                                if (reader != null)
                                    reader.Dispose();
                                string text = antecedent.Result;
                                Console.WriteLine(SyncCode.FormatBytes(text.Length));
                            });
            return task;
        }
    }
}
