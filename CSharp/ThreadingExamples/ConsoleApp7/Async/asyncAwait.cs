using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Async
{
    class asyncAwait
    {
        public static void Run()
        {
            string url = "http://google.com";
            Console.WriteLine("Opening " + url + "....");
            Task task = WriteWebRequestSizeAsync(url);
        }

        private static async Task WriteWebRequestSizeAsync(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse response = await webRequest.GetResponseAsync();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string text =
                    await reader.ReadToEndAsync();
                    Console.WriteLine(SyncCode.FormatBytes(text.Length));
                }
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
}
