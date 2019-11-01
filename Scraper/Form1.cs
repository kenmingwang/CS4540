using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        }

        private void InitializeDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
            }
        }

        private void DestroyDriver()
        {
            driver.Close();
            driver.Dispose();
        }

        private void FindEnrollmentBtn_Click(object sender, EventArgs e)
        {
            if (SemesterBox.Text != "" && YearBox.Text != "" && LimitToBox.Text != "")
            {
                int year = TryToParse(YearBox.Text);
                int limit = TryToParse(LimitToBox.Text);

                int semester = -1;
                switch (SemesterBox.Text)
                {
                    case "Spring": semester = TryToParse(ConfigurationManager.AppSettings["Spring"]); break;
                    case "Summer": semester = TryToParse(ConfigurationManager.AppSettings["Summer"]); break;
                    case "Fall": semester = TryToParse(ConfigurationManager.AppSettings["Fall"]); break;
                }

                if (year == -1 || limit == -1 || semester == -1)
                    return;

                // Construct url following the rule provided by the website
                var urlPram = new StringBuilder();
                urlPram.Append(year > 2000 ? '1' : '0'); // 19XX is 0, 20XX is 1
                urlPram.Append(YearBox.Text.Substring(2)); // middle 2 char are the year, XX19
                urlPram.Append(semester.ToString()); // last char is the semester

                var url = ConfigurationManager.AppSettings["ClassScheduleUrl"] + urlPram + ConfigurationManager.AppSettings["EndUrl"];

                InitializeDriver();
                driver.Navigate().GoToUrl(url);

            }
            else
            {
                // Error message
            }
        }

        private int TryToParse(string value)
        {
            Int32 number;
            bool result = Int32.TryParse(value, out number);
            if (result)
            {
                return number;
            }
            else
            {
                return -1;
            }
        }

    }
}
