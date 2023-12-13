namespace Testing_students.Forms
{
    partial class TeacherForm
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
            this.TeacherNameLabel = new System.Windows.Forms.Label();
            this.TeacherLoginLabel = new System.Windows.Forms.Label();
            this.ViewCreatedTests = new System.Windows.Forms.DataGridView();
            this.ReviewAttemptsButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.EditTestButton = new System.Windows.Forms.Button();
            this.RateListButton = new System.Windows.Forms.Button();
            this.DeleteTestButton = new System.Windows.Forms.Button();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ViewCreatedTests)).BeginInit();
            this.SuspendLayout();
            // 
            // TeacherNameLabel
            // 
            this.TeacherNameLabel.AutoSize = true;
            this.TeacherNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TeacherNameLabel.Location = new System.Drawing.Point(12, 9);
            this.TeacherNameLabel.Name = "TeacherNameLabel";
            this.TeacherNameLabel.Size = new System.Drawing.Size(78, 29);
            this.TeacherNameLabel.TabIndex = 0;
            this.TeacherNameLabel.Text = "Name";
            // 
            // TeacherLoginLabel
            // 
            this.TeacherLoginLabel.AutoSize = true;
            this.TeacherLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TeacherLoginLabel.Location = new System.Drawing.Point(12, 49);
            this.TeacherLoginLabel.Name = "TeacherLoginLabel";
            this.TeacherLoginLabel.Size = new System.Drawing.Size(81, 25);
            this.TeacherLoginLabel.TabIndex = 1;
            this.TeacherLoginLabel.Text = "Position";
            // 
            // ViewCreatedTests
            // 
            this.ViewCreatedTests.AllowUserToAddRows = false;
            this.ViewCreatedTests.AllowUserToDeleteRows = false;
            this.ViewCreatedTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewCreatedTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewCreatedTests.Location = new System.Drawing.Point(12, 126);
            this.ViewCreatedTests.Name = "ViewCreatedTests";
            this.ViewCreatedTests.ReadOnly = true;
            this.ViewCreatedTests.RowHeadersWidth = 51;
            this.ViewCreatedTests.RowTemplate.Height = 24;
            this.ViewCreatedTests.Size = new System.Drawing.Size(832, 307);
            this.ViewCreatedTests.TabIndex = 0;
            // 
            // ReviewAttemptsButton
            // 
            this.ReviewAttemptsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReviewAttemptsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.ReviewAttemptsButton.Location = new System.Drawing.Point(166, 439);
            this.ReviewAttemptsButton.Name = "ReviewAttemptsButton";
            this.ReviewAttemptsButton.Size = new System.Drawing.Size(157, 23);
            this.ReviewAttemptsButton.TabIndex = 3;
            this.ReviewAttemptsButton.Text = "Переглянути спроби";
            this.ReviewAttemptsButton.UseVisualStyleBackColor = true;
            this.ReviewAttemptsButton.Click += new System.EventHandler(this.ReviewAttemptsButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.CreateButton.Location = new System.Drawing.Point(436, 439);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(135, 23);
            this.CreateButton.TabIndex = 4;
            this.CreateButton.Text = "Створити тест";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateTestButton_Click);
            // 
            // EditTestButton
            // 
            this.EditTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.EditTestButton.Location = new System.Drawing.Point(718, 439);
            this.EditTestButton.Name = "EditTestButton";
            this.EditTestButton.Size = new System.Drawing.Size(126, 23);
            this.EditTestButton.TabIndex = 5;
            this.EditTestButton.Text = "Редагувати тест";
            this.EditTestButton.UseVisualStyleBackColor = true;
            this.EditTestButton.Click += new System.EventHandler(this.EditTestButton_Click);
            // 
            // RateListButton
            // 
            this.RateListButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RateListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.RateListButton.Location = new System.Drawing.Point(12, 439);
            this.RateListButton.Name = "RateListButton";
            this.RateListButton.Size = new System.Drawing.Size(148, 23);
            this.RateListButton.TabIndex = 6;
            this.RateListButton.Text = "Список студентів";
            this.RateListButton.UseVisualStyleBackColor = true;
            this.RateListButton.Click += new System.EventHandler(this.RateListButton_Click);
            // 
            // DeleteTestButton
            // 
            this.DeleteTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.DeleteTestButton.Location = new System.Drawing.Point(577, 439);
            this.DeleteTestButton.Name = "DeleteTestButton";
            this.DeleteTestButton.Size = new System.Drawing.Size(135, 23);
            this.DeleteTestButton.TabIndex = 8;
            this.DeleteTestButton.Text = "Видалити тест";
            this.DeleteTestButton.UseVisualStyleBackColor = true;
            this.DeleteTestButton.Click += new System.EventHandler(this.DeleteTestButton_Click);
            // 
            // SearchBox
            // 
            this.SearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchBox.Location = new System.Drawing.Point(72, 468);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(199, 22);
            this.SearchBox.TabIndex = 9;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(14, 471);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(52, 16);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "Назва:";
            // 
            // TeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 496);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.DeleteTestButton);
            this.Controls.Add(this.EditTestButton);
            this.Controls.Add(this.RateListButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.ReviewAttemptsButton);
            this.Controls.Add(this.ViewCreatedTests);
            this.Controls.Add(this.TeacherLoginLabel);
            this.Controls.Add(this.TeacherNameLabel);
            this.Name = "TeacherForm";
            this.Text = "Аккаунт вчителя";
            ((System.ComponentModel.ISupportInitialize)(this.ViewCreatedTests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TeacherNameLabel;
        private System.Windows.Forms.Label TeacherLoginLabel;
        private System.Windows.Forms.DataGridView ViewCreatedTests;
        private System.Windows.Forms.Button ReviewAttemptsButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button EditTestButton;
        private System.Windows.Forms.Button RateListButton;
        private System.Windows.Forms.Button DeleteTestButton;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label SearchLabel;
    }
}