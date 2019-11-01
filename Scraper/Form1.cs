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
                    var td = driver.FindElements(By.XPath("//td[contains(text(),'" +
                        ConfigurationManager.AppSettings["ConsiderSection"] + "')]"));

                    List<IWebElement> filteredRows = new List<IWebElement>();
                    foreach (var child in td)
                    {
                        var parent = child.FindElement(By.XPath("./parent::*")); // <tr> that is sec 001
                        var cols = parent.FindElements(By.TagName("td")); //re-dive into the <tr> to filter course numbers
                        var cat = cols[2].Text; // category

                        // Filter out the correct course numbers
                        int number = TryToParse(cat);
                        if (!(number <= TryToParse(ConfigurationManager.AppSettings["CourseRangeEnd"]) &&
                            number >= TryToParse(ConfigurationManager.AppSettings["CourseRangeStart"])))
                        {
                            continue;
                        }

                        // Filter out key words
                        var filter = ConfigurationManager.AppSettings["Filters"].Split(',');
                        var title = cols[4].Text;
                        if(title.Contains(filter[0]) || title.Contains(filter[1]))
                        {
                            continue;
                        }

                        // At this point it's a valid row
                        richTextBox1.AppendText(cat + ", " + title + "\n");

                           // Console.WriteLine();
                           // Filter out the correct course numbers, <td>s in a <tr> that fits the course number constraint
                           //foreach (var d in cols)
                           //{
                           //    int number = TryToParse(d.Text);
                           //    if (number <= TryToParse(ConfigurationManager.AppSettings["CourseRangeEnd"]) &&
                           //        number >= TryToParse(ConfigurationManager.AppSettings["CourseRangeStart"]))
                           //    {
                           //        //Filter out the components , <tr> that fits the filter
                           //        var filter = ConfigurationManager.AppSettings["Filters"].Split(',');
                           //        // richTextBox1.AppendText(number.ToString());
                           //        var tmpParent = d.FindElement(By.XPath("./parent::*"));
                           //        var l = tmpParent.FindElements(By.TagName("td"));
                           //        //foreach (var c in l)
                           //        //{
                           //          richTextBox1.AppendText(l[2].Text + ", " + l[3].Text +  ", " + l[4].Text + ", " + l[5].Text);
                           //        //}
                           //        richTextBox1.AppendText("\n");

                            //        // Ones that does not need
                            //        //var f = tmpParent.FindElements(By.XPath("//td[contains(text(),'" + filter[0] + "')]"));
                            //          // + " or contains(text(),'" + filter[1] + "')]"));

                            //        // if f did not find any thing, then it's the final filtered version
                            //        //if (f.Count == 0)
                            //        //{
                            //        //    filteredRows.Add(tmpParent);
                            //        //}

                            //    }
                            //}
                    }

                    //foreach (var r in filteredRows)
                    //{
                    //    IReadOnlyList<IWebElement> childs = r.FindElements(By.XPath(".//*"));
                    //    foreach(var c in childs)
                    //    {
                    //        richTextBox1.AppendText(c.Text + ",");
                    //    }
                    //    richTextBox1.AppendText("\n");
                    //}
                }
                catch (Exception ex)
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
public class Data
{

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
