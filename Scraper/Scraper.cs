using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Scraper
{
    public class Scraper
    {
        ChromeDriver driver;
        Form1 view;

        public Scraper(Form1 _view)
        {
            view = _view;
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

        public void FindEnrollments(string _year, string _semester, string _limit)
        {
            view.ConsoleOutput("Starting to find enrollments...");

            int year = TryToParse(_year);
            int limit = TryToParse(_limit);

            int semester = -1;
            switch (_semester)
            {
                case "Spring": semester = TryToParse(ConfigurationManager.AppSettings["Spring"]); break;
                case "Summer": semester = TryToParse(ConfigurationManager.AppSettings["Summer"]); break;
                case "Fall": semester = TryToParse(ConfigurationManager.AppSettings["Fall"]); break;
            }
            
            if (year == -1 || limit == -1 || semester == -1)
            {
                view.ConsoleOutput("Something is wrong with the parameter, please try again with the right values...");
                return;
            }
                

            // Construct url following the rule provided by the website
            var urlPram = new StringBuilder();
            urlPram.Append(year > 2000 ? '1' : '0'); // 19XX is 0, 20XX is 1
            urlPram.Append(_year.Substring(2)); // middle 2 char are the year, XX19
            urlPram.Append(semester.ToString()); // last char is the semester

            var url = ConfigurationManager.AppSettings["ClassScheduleUrl"] + urlPram + ConfigurationManager.AppSettings["EndUrl"];
            view.ConsoleOutput("Url constructed, now starting Selenium...");
            // After all the checks, we start selenium
            InitializeDriver();

            view.ConsoleOutput("Searching...");
            view.ConsoleOutput("----------Results----------");

            // This will catch any timeExceed > 5 sec, and not foundElement exception
            try
            {
                // Navigate to seating availibility
                driver.Navigate().GoToUrl(url);
                var link = driver.FindElement(By.XPath(
                    "//a[contains(text(),'" + ConfigurationManager.AppSettings["SeatingAvailibilityLinkText"] + "')]"));
                driver.Navigate().GoToUrl(link.GetAttribute("href"));

                // Filter out needed sections
                var td = driver.FindElements(By.XPath("//td[contains(text(),'" +
                    ConfigurationManager.AppSettings["ConsiderSection"] + "')]"));

                // Filter out the rows that we want
                List<IWebElement> filteredRows = new List<IWebElement>();

                int count = td.Count;
                for(int i = 0; i<count; i++)
                {
                    var child = td[i];
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
                    if (title.Contains(filter[0]) || title.Contains(filter[1]))
                    {
                        continue;
                    }

                    // At this point it's a valid row. Navigate to get units and description

                    var desLink = cols[1].FindElement(By.TagName("a")).GetAttribute("href");
                    driver.Navigate().GoToUrl(desLink);
                    var units = driver.FindElement(By.XPath("//*[@id='DERIVED_CRSECAT_UNITS_RANGE$0']")).Text;
                    var description = driver.FindElement(By.XPath("//*[@id='CATLG_SRCH_RSLT_DESCRLONG$0']")).Text;
                    view.ConsoleOutput("----------Class----------");
                    view.ConsoleOutput(cat + ", " + title + ", " + units + ", " + description);
                    
                    if (--limit <= 0)
                    {
                        break;
                    }
                    driver.Navigate().Back();
                    td = driver.FindElements(By.XPath("//td[contains(text(),'" +
                    ConfigurationManager.AppSettings["ConsiderSection"] + "')]"));
                }
                   
            }
            catch (Exception ex)
            {
                view.ConsoleOutput("Something went wrong...");
                view.ConsoleOutput(ex.Message);

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
}
