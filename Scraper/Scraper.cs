using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Scraper
{
    public class Scraper
    {
        ChromeDriver driver;
        Form1 view;
        List<string> scrapedData;

        public Scraper(Form1 _view)
        {
            view = _view;
        }

        private void InitializeDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);

                scrapedData = new List<string>();
            }
        }

        private void DestroyDriver()
        {
            driver.Close();
            driver.Dispose();
            driver = null;
        }

        public void ClearCache()
        {
            scrapedData = new List<string>();
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
                    var enrollment = cols[6].Text;
                    var desLink = cols[1].FindElement(By.TagName("a")).GetAttribute("href");
                    driver.Navigate().GoToUrl(desLink);
                    var units = driver.FindElement(By.XPath("//*[@id='DERIVED_CRSECAT_UNITS_RANGE$0']")).Text;
                    var description = driver.FindElement(By.XPath("//*[@id='CATLG_SRCH_RSLT_DESCRLONG$0']")).Text;
                    title = driver.FindElement(By.XPath("//*[@id='DERIVED_CRSECAT_DESCR200$0']")).Text;

                    // Adding qutoes in title and description in order to avoid any commas within them.
                    title = title.Substring(title.IndexOf("-") + 2);
                    title = (char)34 + title + (char)34;
                    description = (char)34 + description + (char)34; 

                    // Output to view
                    view.ConsoleOutput("----------Class----------");
                    view.ConsoleOutput(cat + ", " + title + ", " + units + ", " + description);

                    // Store in list for saving
                    SaveToList("CS", cat, units, title, enrollment, _semester, _year, description);

                    // If it reaches limit, break out the loop and stop
                    if (--limit <= 0)
                    {
                        break;
                    }

                    // If continues, go back to previous page and re-anchor points.
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
            DestroyDriver();
            view.ConsoleOutput("-------------------------------------------------");
            view.ConsoleOutput("Search done...Click save to save in csv format");
            view.ActivateSaveBtn(true);
        }

        // Format :    
        // Course Dept,Course Number,Course Credits,Course Title,Course Enrollment,Course Semester,
        // Course Year,Course Description
        private void SaveToList(string dept, string num, string credit, string title,
            string enrollment, string semester, string year, string descr) 

        {
            StringBuilder result = new StringBuilder();
            // Corner case for credits 1-3
            credit = credit.Substring(0, credit.Length - 6);
            if (credit.Contains("-"))
            {
                credit = credit.Substring(3);
            }
            // Corner case for descriptions with new lines in it.
            descr = Regex.Replace(descr, @"\t|\n|\r", "");

            result.Append(dept + "," + num + "," + credit + "," + title + 
                "," + enrollment + "," + semester + "," + year + "," + descr);
            scrapedData.Add(result.ToString());
        }

        public void WriteToCSV(string filename)
        {
            File.WriteAllLines(filename + ".csv", scrapedData); 
        }

        public void AddCourse(string cat, string num)
        {
            if(cat.All(char.IsLetter) && num.All(char.IsDigit))
            {
                view.AddcourseConsoleOutput(cat.ToUpper() + num); 
            }
            else
            {
                view.ShowMessagebox("Bad input, please try again.");
            }
        }

        public void FindCourses(List<string> courses)
        {
            try
            {
                view.ConsoleOutput("Starting to search...");
                InitializeDriver();
                // Goto Courses catalog
                driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["CourseCatalog"]);
                driver.FindElement(By.XPath("//*[@id='top']/div/div[3]/div/nav/ul/li[3]/div")).Click();

                view.ConsoleOutput("Navigated to courses page, now searching course...");
                view.ConsoleOutput("--------------------------Results-------------------");

                // Find the course(s)
                foreach(var c in courses)
                {
                    var search = driver.FindElement(By.XPath("//*[@id='Search']"));
                    search.SendKeys(Keys.Control + "a");
                    search.SendKeys(Keys.Delete);

                    search.SendKeys(c);
                    search.SendKeys(Keys.Enter);
                    var link = driver.FindElements(By.XPath("//*[@id='__KUALI_TLP']/div/table/tbody/tr/th/a"));

                    if (link.Count > 0)
                    {
                        link[0].Click();
                        var title = driver.FindElement(By.XPath("//*[@id='__KUALI_TLP']/div/h2")).Text;
                        var desc = driver.FindElement(By.XPath("//*[@id='__KUALI_TLP']/div/div/div[4]/div/div")).Text;
                        view.ConsoleOutput(title + ": " + desc);
                        view.ConsoleOutput("-------------------------------------------------");

                        driver.Navigate().Back();
                    }
                    else
                    {
                        view.ConsoleOutput("Cant find course: " + c);
                        view.ConsoleOutput("-------------------------------------------------");

                        continue;
                    }
                }
                    
            }
            catch
            {
                view.ConsoleOutput("Something is wrong with the input! Please try again!");
            }
            view.ConsoleOutput("-------------------------------------------------");
            view.ConsoleOutput("Search done...");
            DestroyDriver();

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
