using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scraper
{
    public partial class Form1 : Form
    {
        ChromeDriver driver;

        public Form1()
        {
            InitializeComponent();
            InitializeDriver();
        }

        private void InitializeDriver()
        {
            driver = new ChromeDriver();
        }

        private void DestroyDriver()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
