using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncInWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //label1.Text = GetText();
            label2.Text =await GetTextAsync();

        }
        private string GetText()
        {
            Thread.Sleep(5000);
            return "Hello Synchronous";
        }
        private Task<string> GetTextAsync()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                return "Hello Async";
            });
        }
    }
}
