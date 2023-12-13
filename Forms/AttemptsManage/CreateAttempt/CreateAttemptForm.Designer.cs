namespace Testing_students.Forms.AttemptsManage.CreateAttempt
{
    partial class CreateAttemptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChooseGroupsList = new System.Windows.Forms.CheckedListBox();
            this.ChooseStudentsList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChooseDate = new System.Windows.Forms.DateTimePicker();
            this.CreateButton = new System.Windows.Forms.Button();
            this.CommentBox = new System.Windows.Forms.TextBox();
            this.CommentLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChooseGroupsList
            // 
            this.ChooseGroupsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseGroupsList.FormattingEnabled = true;
            this.ChooseGroupsList.HorizontalScrollbar = true;
            this.ChooseGroupsList.Location = new System.Drawing.Point(12, 28);
            this.ChooseGroupsList.Name = "ChooseGroupsList";
            this.ChooseGroupsList.Size = new System.Drawing.Size(598, 123);
            this.ChooseGroupsList.TabIndex = 0;
            // 
            // ChooseStudentsList
            // 
            this.ChooseStudentsList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseStudentsList.FormattingEnabled = true;
            this.ChooseStudentsList.HorizontalScrollbar = true;
            this.ChooseStudentsList.Location = new System.Drawing.Point(12, 186);
            this.ChooseStudentsList.Name = "ChooseStudentsList";
            this.ChooseStudentsList.Size = new System.Drawing.Size(598, 123);
            this.ChooseStudentsList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Групи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Студенти:";
            // 
            // ChooseDate
            // 
            this.ChooseDate.Location = new System.Drawing.Point(12, 419);
            this.ChooseDate.MinDate = new System.DateTime(2023, 1, 26, 0, 0, 0, 0);
            this.ChooseDate.Name = "ChooseDate";
            this.ChooseDate.Size = new System.Drawing.Size(258, 22);
            this.ChooseDate.TabIndex = 4;
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.Location = new System.Drawing.Point(519, 418);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(91, 23);
            this.CreateButton.TabIndex = 5;
            this.CreateButton.Text = "Створити";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CommentBox
            // 
            this.CommentBox.Location = new System.Drawing.Point(12, 334);
            this.CommentBox.Multiline = true;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.Size = new System.Drawing.Size(598, 78);
            this.CommentBox.TabIndex = 6;
            // 
            // CommentLabel
            // 
            this.CommentLabel.AutoSize = true;
            this.CommentLabel.Location = new System.Drawing.Point(17, 315);
            this.CommentLabel.Name = "CommentLabel";
            this.CommentLabel.Size = new System.Drawing.Size(74, 16);
            this.CommentLabel.TabIndex = 7;
            this.CommentLabel.Text = "Коментар:";
            // 
            // CreateAttemptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 453);
            this.Controls.Add(this.CommentLabel);
            this.Controls.Add(this.CommentBox);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ChooseDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChooseStudentsList);
            this.Controls.Add(this.ChooseGroupsList);
            this.MaximumSize = new System.Drawing.Size(640, 500);
            this.MinimumSize = new System.Drawing.Size(640, 500);
            this.Name = "CreateAttemptForm";
            this.Text = "Створення спроби";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ChooseGroupsList;
        private System.Windows.Forms.CheckedListBox ChooseStudentsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ChooseDate;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.TextBox CommentBox;
        private System.Windows.Forms.Label CommentLabel;
    }
}