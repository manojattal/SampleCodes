using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.Async
{
    class SyncCode
    {
        public static void Run()
        {
            string url = "http://google.com";
            try
            {
                Console.WriteLine("Opening " + url + "....");
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse webResponse = webRequest.GetResponse();
                Console.WriteLine("....");
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    string text = reader.ReadToEnd();
                    Console.WriteLine(FormatBytes(text.Length));
                }
                Console.Read();
            }
            catch(WebException)
            {

            }
            catch (IOException)
            {

            }
            catch (NotSupportedException)
            {

            }
        }

        static public string FormatBytes(long bytes)
        {
            string[] magnitudes =
            new string[] { "GB", "MB", "KB", "Bytes" };
            long max =
            (long)Math.Pow(1024, magnitudes.Length);
            return string.Format("{1:##.##} {0}",
            magnitudes.FirstOrDefault(
            magnitude =>
            bytes > (max /= 1024)) ?? "0 Bytes",
            (decimal)bytes / (decimal)max);
        }
    }
}
