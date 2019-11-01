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
            ((System.ComponentModel.ISupportInitialize)(this.YearBox)).BeginInit();
            // 
            // FindEnrollmentBtn
            // 
            this.FindEnrollmentBtn.Location = new System.Drawing.Point(41, 140);
            this.FindEnrollmentBtn.Name = "FindEnrollmentBtn";
            this.FindEnrollmentBtn.Size = new System.Drawing.Size(282, 29);
            this.FindEnrollmentBtn.TabIndex = 0;
            this.FindEnrollmentBtn.Text = "Find Enrollments";
            this.FindEnrollmentBtn.UseVisualStyleBackColor = true;
            this.FindEnrollmentBtn.Click += new System.EventHandler(this.FindEnrollmentBtn_Click);
            // 
            // LimitToBox
            // 
            this.LimitToBox.Location = new System.Drawing.Point(125, 107);
            this.LimitToBox.Name = "LimitToBox";
            this.LimitToBox.Size = new System.Drawing.Size(125, 27);
            this.LimitToBox.TabIndex = 2;
            this.LimitToBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Year";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
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
            this.SemesterBox.Location = new System.Drawing.Point(125, 24);
            this.SemesterBox.Name = "SemesterBox";
            this.SemesterBox.Size = new System.Drawing.Size(125, 28);
            this.SemesterBox.TabIndex = 7;
            // 
            // YearBox
            // 
            this.YearBox.Location = new System.Drawing.Point(125, 65);
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
            this.YearBox.Size = new System.Drawing.Size(125, 27);
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
            this.label4.Location = new System.Drawing.Point(256, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Courses";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(41, 192);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(569, 120);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(666, 338);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.YearBox);
            this.Controls.Add(this.SemesterBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LimitToBox);
            this.Controls.Add(this.FindEnrollmentBtn);
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
    }
}

