using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lecture9.WinFormsAppExample
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var result = selectDocumentDialog.ShowDialog();

        //    if (result.HasFlag(DialogResult.OK))
        //    {
        //        textBox2.Text = selectDocumentDialog.FileName;
        //    }
        //}

        private void selectDocumentDialog_FileOk(object sender, CancelEventArgs e)
        {
        }
    }
}