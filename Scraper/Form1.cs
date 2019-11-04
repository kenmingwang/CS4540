using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Scraper;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scraper
{
    public partial class Form1 : Form
    {
        Scraper _scraper;
        delegate void AsynUpdateUI(string step);

        public Form1()
        {
            InitializeComponent();
            _scraper = new Scraper(this);
        }

        private async void FindEnrollmentBtn_Click(object sender, EventArgs e)
        {
            // Make sure every box has a value
            if (SemesterBox.Text != "" && YearBox.Text != "" && LimitToBox.Text != "")
            {
                var a = SemesterBox.Text;
                var b = YearBox.Text;
                var c = LimitToBox.Text;
                await Task.Run(() => 
                {
                    _scraper.FindEnrollments(b, a, c);
                });
                    
            }
            else
            {
                MessageBox.Show("Enter all values before find");
            }
        }

        public void ConsoleOutput(string line)
        {
            if (richTextBox1.InvokeRequired)
            {
                TextBox2Invoke m = new TextBox2Invoke(ConsoleOutput);
                Invoke(m, line);
            }
            else
            {
                richTextBox1.AppendText(line + "\n");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private delegate void TextBox2Invoke(string str);
    }
}
public class Data
{

}


