using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace UsingAsyncWebViewCounter
{
    class Program
    {
        private const string url = "https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1";
        static void Main(string[] args)
        {
            DoSyncWork();
            var someTask = DoAsyncWork();
            DoSynchronousWorkAfterAwait();
            someTask.Wait();
            Console.ReadLine();
        }

        private static void DoSyncWork()
        {
            Console.WriteLine("1-Sync Work");
        }
         static async Task DoAsyncWork()
        {
            Console.WriteLine("Async Task has started!");
            await GetStingAsync();
        }
        static async Task GetStingAsync()
        {
            using (var httpClient=new HttpClient())
            {
                Console.WriteLine("3. Awaiting the result of GetStringAsync of Http Client...");
                string result = await httpClient.GetStringAsync(url);
                Console.WriteLine("4. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"5. The length of http Get for {url}");
                Console.WriteLine($"6. {result.Length} character");
            }
        }
        static void DoSynchronousWorkAfterAwait()
        {
            //This is the work we can do while waiting for the awaited Async Task to complete
            Console.WriteLine("7. While waiting for the async task to finish, we can do some unrelated work...");
            for (var i = 0; i <= 5; i++)
            {
                for (var j = i; j <= 5; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

        }
    }
}
