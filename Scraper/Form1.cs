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
            // Make sure every box has a value
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

                // This will catch any timeExceed > 5 sec, and not foundElement exception
                try
                {
                    driver.Navigate().GoToUrl(url);
                    var link = driver.FindElement(By.XPath(
                        "//a[contains(text(),'" + ConfigurationManager.AppSettings["SeatingAvailibilityLinkText"] + "')]"));
                    driver.Navigate().GoToUrl(link.GetAttribute("href"));
                    // Filter out needed sections
                    var td = driver.FindElement(By.XPath("//td[contains(text()"+
                        ConfigurationManager.AppSettings["ConsiderSection"] + "')]"));
                    foreach (var col)
                }
                catch(Exception ex)
                {

                }

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

// reference: https://stackoverflow.com/questions/6992993/selenium-c-sharp-webdriver-wait-until-element-is-present
// Author: Loudenvier
public static class WebDriverExtensions
{
    public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
    {
        if (timeoutInSeconds > 0)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(by));
        }
        return driver.FindElement(by);
    }
}
