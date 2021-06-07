using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture12.WinAppExample
{
    public partial class Deadlock : Form
    {
        private readonly RemoteService _remoteService;

        public Deadlock()
        {
            InitializeComponent();
            _remoteService = new RemoteService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var uiContext = TaskScheduler.FromCurrentSynchronizationContext();
            var customScheduler = new CustomTaskScheduler(2);

            Console.WriteLine("====== Before call ======");
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");

            //textBox1.Text = await _remoteService.GetPlaceHolderApiDataAsync();
            var result = await _remoteService.GetPlaceHolderApiDataAsync(uiContext, SetText);

            Console.WriteLine("====== After call ======");
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine($"ThreadCount: {ThreadPool.ThreadCount}");
        }

        private void SetText(string text)
        {
            textBox1.Text = text;
        }

        private void JustDumbAction(string text)
        {
            Console.WriteLine(text);
        }
    }
}