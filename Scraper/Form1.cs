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
        private delegate void TextBox2Invoke(string str);
        private delegate void SaveBtn2Invoke(bool active);
        private delegate void AddcourseBox2Invoke(string course);



        public Form1()
        {
            InitializeComponent();
            _scraper = new Scraper(this);
        }

        private async void FindEnrollmentBtn_Click(object sender, EventArgs e)
        {
            ClearConsoleAndCache();
            //Clear out console
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text = "";
            }

            // Make sure every box has a value
            if (SemesterBox.Text != "" && YearBox.Text != "" && LimitToBox.Text != "")
            {
                var Semester = SemesterBox.Text;
                var Year = YearBox.Text;
                var Limit = LimitToBox.Text;
                await Task.Run(() =>
                {
                    _scraper.FindEnrollments(Year, Semester, Limit);
                });

            }
            else
            {
                MessageBox.Show("Enter all values before find");
            }
        }

        public void ActivateSaveBtn(bool active)
        {
            if (SaveBtn.InvokeRequired)
            {
                SaveBtn2Invoke m = new SaveBtn2Invoke(ActivateSaveBtn);
                Invoke(m, active);
            }
            else
            {
                SaveBtn.Enabled = active;
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

        public void AddcourseConsoleOutput(string course)
        {
            if (AddCourseConsole.InvokeRequired)
            {
                AddcourseBox2Invoke m = new AddcourseBox2Invoke(AddcourseConsoleOutput);
                Invoke(m, course);
            }
            else
            {
                AddCourseConsole.AppendText(course + "\n");
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "courses.csv";
            savefile.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                _scraper.WriteToCSV(savefile.FileName);
            }
            MessageBox.Show("File saved!");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddCourseBtn_Click(object sender, EventArgs e)
        {
            if (CatalogBox.Text != "" && NumberBox.Text != "")
            {
                _scraper.AddCourse(CatalogBox.Text, NumberBox.Text);
            }
        }

        public void ShowMessagebox(string content)
        {
            MessageBox.Show(content);
        }
        private void FindCourseBtn_Click(object sender, EventArgs e)
        {
            if (AddCourseConsole.Text.Length > 0)
            {
                ClearConsoleAndCache();
                SaveBtn.Enabled = false;
                List<string> courses = AddCourseConsole.Text.Split("\n").ToList();
                courses.RemoveAt(courses.Count - 1);
                _scraper.FindCourses(courses);
            }
            else
            {
                ShowMessagebox("Please add course before find");
            }
        }

        private void ClearConsoleAndCache()
        {
            //Clear out console
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text = "";
            }

            _scraper.ClearCache();
        }
    }
}

