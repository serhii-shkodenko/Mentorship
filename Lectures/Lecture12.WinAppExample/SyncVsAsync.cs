using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecture12.WinAppExample
{
    public partial class SyncVsAsync : Form
    {
        private readonly RemoteService _remoteService;

        public SyncVsAsync()
        {
            InitializeComponent();
            _remoteService = new RemoteService();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            _remoteService.GetData();
            await UpdateText(label1);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await _remoteService.GetDataAsync();
            await UpdateText(label2);
        }

        private async Task<Product<MySuperType>> UpdateText(Label label)
        {
            label.Text = "Retrieveing data";

            for (var i = 0; i < 10; i++)
            {
                await Task.Delay(250);
                label.Text += ".";
            }

            return new Product<MySuperType>();
        }

        public class Product<TType> where TType : class, new()
        {
            TType GetT => new TType();
        }

        public class MySuperType { }
    }
}