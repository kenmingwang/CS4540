namespace Scraper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FindEnrollmentBtn = new System.Windows.Forms.Button();
            this.LimitToBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SemesterBox = new System.Windows.Forms.ComboBox();
            this.YearBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.FindCourseBtn = new System.Windows.Forms.Button();
            this.AddCourseBtn = new System.Windows.Forms.Button();
            this.AddCourseConsole = new System.Windows.Forms.RichTextBox();
            this.CatalogBox = new System.Windows.Forms.TextBox();
            this.NumberBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.YearBox)).BeginInit();
            // 
            // FindEnrollmentBtn
            // 
            this.FindEnrollmentBtn.Location = new System.Drawing.Point(58, 180);
            this.FindEnrollmentBtn.Name = "FindEnrollmentBtn";
            this.FindEnrollmentBtn.Size = new System.Drawing.Size(282, 29);
            this.FindEnrollmentBtn.TabIndex = 0;
            this.FindEnrollmentBtn.Text = "Find Enrollments";
            this.FindEnrollmentBtn.UseVisualStyleBackColor = true;
            this.FindEnrollmentBtn.Click += new System.EventHandler(this.FindEnrollmentBtn_Click);
            // 
            // LimitToBox
            // 
            this.LimitToBox.Location = new System.Drawing.Point(137, 134);
            this.LimitToBox.Name = "LimitToBox";
            this.LimitToBox.Size = new System.Drawing.Size(125, 31);
            this.LimitToBox.TabIndex = 2;
            this.LimitToBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Limit to";
            // 
            // SemesterBox
            // 
            this.SemesterBox.FormattingEnabled = true;
            this.SemesterBox.Items.AddRange(new object[] {
            "Spring",
            "Fall",
            "Summer"});
            this.SemesterBox.Location = new System.Drawing.Point(137, 48);
            this.SemesterBox.Name = "SemesterBox";
            this.SemesterBox.Size = new System.Drawing.Size(125, 33);
            this.SemesterBox.TabIndex = 7;
            // 
            // YearBox
            // 
            this.YearBox.Location = new System.Drawing.Point(137, 89);
            this.YearBox.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.YearBox.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearBox.Name = "YearBox";
            this.YearBox.Size = new System.Drawing.Size(125, 31);
            this.YearBox.TabIndex = 8;
            this.YearBox.Value = new decimal(new int[] {
            2019,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(268, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "Courses";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(53, 234);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(900, 499);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Enabled = false;
            this.SaveBtn.Location = new System.Drawing.Point(366, 140);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(112, 69);
            this.SaveBtn.TabIndex = 11;
            this.SaveBtn.Text = "Save Enrollments";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // FindCourseBtn
            // 
            this.FindCourseBtn.Location = new System.Drawing.Point(730, 175);
            this.FindCourseBtn.Name = "FindCourseBtn";
            this.FindCourseBtn.Size = new System.Drawing.Size(211, 34);
            this.FindCourseBtn.TabIndex = 12;
            this.FindCourseBtn.Text = "Find Course(s)";
            this.FindCourseBtn.UseVisualStyleBackColor = true;
            this.FindCourseBtn.Click += new System.EventHandler(this.FindCourseBtn_Click);
            // 
            // AddCourseBtn
            // 
            this.AddCourseBtn.Location = new System.Drawing.Point(562, 175);
            this.AddCourseBtn.Name = "AddCourseBtn";
            this.AddCourseBtn.Size = new System.Drawing.Size(152, 34);
            this.AddCourseBtn.TabIndex = 13;
            this.AddCourseBtn.Text = "Add Course";
            this.AddCourseBtn.UseVisualStyleBackColor = true;
            this.AddCourseBtn.Click += new System.EventHandler(this.AddCourseBtn_Click);
            // 
            // AddCourseConsole
            // 
            this.AddCourseConsole.Location = new System.Drawing.Point(562, 89);
            this.AddCourseConsole.Name = "AddCourseConsole";
            this.AddCourseConsole.Size = new System.Drawing.Size(379, 70);
            this.AddCourseConsole.TabIndex = 14;
            this.AddCourseConsole.Text = "";
            this.AddCourseConsole.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // CatalogBox
            // 
            this.CatalogBox.Location = new System.Drawing.Point(562, 48);
            this.CatalogBox.Name = "CatalogBox";
            this.CatalogBox.Size = new System.Drawing.Size(150, 31);
            this.CatalogBox.TabIndex = 15;
            // 
            // NumberBox
            // 
            this.NumberBox.Location = new System.Drawing.Point(791, 48);
            this.NumberBox.Name = "NumberBox";
            this.NumberBox.Size = new System.Drawing.Size(150, 31);
            this.NumberBox.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(562, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 25);
            this.label5.TabIndex = 16;
            this.label5.Text = "Catalog: eg. CS";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(791, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Number: eg.3500";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(978, 744);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CatalogBox);
            this.Controls.Add(this.AddCourseConsole);
            this.Controls.Add(this.AddCourseBtn);
            this.Controls.Add(this.FindCourseBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.SemesterBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LimitToBox);
            this.Controls.Add(this.FindEnrollmentBtn);
            this.Controls.Add(this.NumberBox);
            this.MaximumSize = new System.Drawing.Size(1000, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 800);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.YearBox)).EndInit();

        }

        private System.Windows.Forms.Button FindEnrollmentBtn;
        private System.Windows.Forms.TextBox LimitToBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SemesterBox;
        private System.Windows.Forms.NumericUpDown YearBox;
        private System.Windows.Forms.Label label4;

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button FindCourseBtn;
        private System.Windows.Forms.Button AddCourseBtn;
        private System.Windows.Forms.RichTextBox AddCourseConsole;
        private System.Windows.Forms.TextBox CatalogBox;
        private System.Windows.Forms.TextBox NumberBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

