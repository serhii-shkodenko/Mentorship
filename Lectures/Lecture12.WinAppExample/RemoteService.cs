using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture12.WinAppExample
{
    public class RemoteService
    {
        public async Task GetDataAsync()
        {
            await Task.Delay(3000);
            MessageBox.Show("Remote service returned data.");
        }

        public void GetData()
        {
            Thread.Sleep(3000);
            MessageBox.Show("Remote service returned data.");
        }

        public async Task<string> GetPlaceHolderApiDataAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/todos");
            var response = await client.SendAsync(request).ConfigureAwait(false);

            Console.WriteLine("====== Inside the call ======");
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetPlaceHolderApiDataAsync(TaskScheduler scheduler, Action<string> perfomActionOverUiControl)
        {
            using var cancellationSource = new CancellationTokenSource();

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://jsonplaceholder.typicode.com/todos");

            var sendingTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("====== Inside the sending task ======");
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

                return client.SendAsync(request);
            }, cancellationSource.Token).Unwrap();

            var getContentTask = sendingTask.ContinueWith((response) =>
            {
                Console.WriteLine("====== Inside the getting content task ======");
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

                return response.GetAwaiter().GetResult().Content.ReadAsStringAsync();
            }, cancellationSource.Token).Unwrap();

            return await await getContentTask.ContinueWith(async (content, obj) =>
            {
                Console.WriteLine("====== Inside the TextBox manipulating task ======");
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

                var text = await content;

                perfomActionOverUiControl(text);

                return text;
            }, cancellationSource.Token, scheduler);
        }

        public ValueTask<int> GetStatusCode()
        {
            return ValueTask.FromResult(10);
        }
    }
}