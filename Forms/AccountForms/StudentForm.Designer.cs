namespace Testing_students
{
    partial class StudentForm
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
            this.StudentNameLabel = new System.Windows.Forms.Label();
            this.ViewEnabledTests = new System.Windows.Forms.DataGridView();
            this.StudentGroupLabel = new System.Windows.Forms.Label();
            this.StudentIdLabel = new System.Windows.Forms.Label();
            this.MenuTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StartTestButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ReviewAttemptButton = new System.Windows.Forms.Button();
            this.ViewEndedTests = new System.Windows.Forms.DataGridView();
            this.SeacrhBox = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.SeacrhLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ViewEnabledTests)).BeginInit();
            this.MenuTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewEndedTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // StudentNameLabel
            // 
            this.StudentNameLabel.AutoSize = true;
            this.StudentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.StudentNameLabel.Location = new System.Drawing.Point(12, 9);
            this.StudentNameLabel.Name = "StudentNameLabel";
            this.StudentNameLabel.Size = new System.Drawing.Size(78, 29);
            this.StudentNameLabel.TabIndex = 0;
            this.StudentNameLabel.Text = "Name";
            // 
            // ViewEnabledTests
            // 
            this.ViewEnabledTests.AllowUserToAddRows = false;
            this.ViewEnabledTests.AllowUserToDeleteRows = false;
            this.ViewEnabledTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewEnabledTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewEnabledTests.Location = new System.Drawing.Point(6, 6);
            this.ViewEnabledTests.Name = "ViewEnabledTests";
            this.ViewEnabledTests.ReadOnly = true;
            this.ViewEnabledTests.RowHeadersWidth = 51;
            this.ViewEnabledTests.RowTemplate.Height = 24;
            this.ViewEnabledTests.Size = new System.Drawing.Size(534, 191);
            this.ViewEnabledTests.TabIndex = 1;
            // 
            // StudentGroupLabel
            // 
            this.StudentGroupLabel.AutoSize = true;
            this.StudentGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.StudentGroupLabel.Location = new System.Drawing.Point(12, 41);
            this.StudentGroupLabel.Name = "StudentGroupLabel";
            this.StudentGroupLabel.Size = new System.Drawing.Size(66, 25);
            this.StudentGroupLabel.TabIndex = 3;
            this.StudentGroupLabel.Text = "Group";
            // 
            // StudentIdLabel
            // 
            this.StudentIdLabel.AutoSize = true;
            this.StudentIdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.StudentIdLabel.Location = new System.Drawing.Point(12, 70);
            this.StudentIdLabel.Name = "StudentIdLabel";
            this.StudentIdLabel.Size = new System.Drawing.Size(28, 25);
            this.StudentIdLabel.TabIndex = 4;
            this.StudentIdLabel.Text = "Id";
            // 
            // MenuTabs
            // 
            this.MenuTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuTabs.Controls.Add(this.tabPage1);
            this.MenuTabs.Controls.Add(this.tabPage2);
            this.MenuTabs.Location = new System.Drawing.Point(12, 231);
            this.MenuTabs.Name = "MenuTabs";
            this.MenuTabs.SelectedIndex = 0;
            this.MenuTabs.Size = new System.Drawing.Size(554, 264);
            this.MenuTabs.TabIndex = 5;
            this.MenuTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.MenuTabs_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.StartTestButton);
            this.tabPage1.Controls.Add(this.ViewEnabledTests);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Відкриті тести";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StartTestButton
            // 
            this.StartTestButton.Location = new System.Drawing.Point(6, 203);
            this.StartTestButton.Name = "StartTestButton";
            this.StartTestButton.Size = new System.Drawing.Size(97, 23);
            this.StartTestButton.TabIndex = 2;
            this.StartTestButton.Text = "Розпочати";
            this.StartTestButton.UseVisualStyleBackColor = true;
            this.StartTestButton.Click += new System.EventHandler(this.StartTestButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ReviewAttemptButton);
            this.tabPage2.Controls.Add(this.ViewEndedTests);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Отримані бали";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ReviewAttemptButton
            // 
            this.ReviewAttemptButton.Location = new System.Drawing.Point(6, 206);
            this.ReviewAttemptButton.Name = "ReviewAttemptButton";
            this.ReviewAttemptButton.Size = new System.Drawing.Size(107, 23);
            this.ReviewAttemptButton.TabIndex = 3;
            this.ReviewAttemptButton.Text = "Переглянути";
            this.ReviewAttemptButton.UseVisualStyleBackColor = true;
            this.ReviewAttemptButton.Click += new System.EventHandler(this.ReviewAttemptButton_Click);
            // 
            // ViewEndedTests
            // 
            this.ViewEndedTests.AllowUserToAddRows = false;
            this.ViewEndedTests.AllowUserToDeleteRows = false;
            this.ViewEndedTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewEndedTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ViewEndedTests.Location = new System.Drawing.Point(6, 6);
            this.ViewEndedTests.Name = "ViewEndedTests";
            this.ViewEndedTests.ReadOnly = true;
            this.ViewEndedTests.RowHeadersWidth = 51;
            this.ViewEndedTests.RowTemplate.Height = 24;
            this.ViewEndedTests.Size = new System.Drawing.Size(534, 194);
            this.ViewEndedTests.TabIndex = 2;
            // 
            // SeacrhBox
            // 
            this.SeacrhBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SeacrhBox.Location = new System.Drawing.Point(368, 499);
            this.SeacrhBox.Name = "SeacrhBox";
            this.SeacrhBox.Size = new System.Drawing.Size(194, 22);
            this.SeacrhBox.TabIndex = 3;
            this.SeacrhBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // SeacrhLabel
            // 
            this.SeacrhLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SeacrhLabel.AutoSize = true;
            this.SeacrhLabel.Location = new System.Drawing.Point(310, 502);
            this.SeacrhLabel.Name = "SeacrhLabel";
            this.SeacrhLabel.Size = new System.Drawing.Size(52, 16);
            this.SeacrhLabel.TabIndex = 4;
            this.SeacrhLabel.Text = "Назва:";
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 533);
            this.Controls.Add(this.SeacrhLabel);
            this.Controls.Add(this.MenuTabs);
            this.Controls.Add(this.SeacrhBox);
            this.Controls.Add(this.StudentIdLabel);
            this.Controls.Add(this.StudentGroupLabel);
            this.Controls.Add(this.StudentNameLabel);
            this.Name = "StudentForm";
            this.Text = "Аккаунт студента";
            this.Load += new System.EventHandler(this.StudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ViewEnabledTests)).EndInit();
            this.MenuTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ViewEndedTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StudentNameLabel;
        private System.Windows.Forms.DataGridView ViewEnabledTests;
        private System.Windows.Forms.Label StudentGroupLabel;
        private System.Windows.Forms.Label StudentIdLabel;
        private System.Windows.Forms.TabControl MenuTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView ViewEndedTests;
        private System.Windows.Forms.Button StartTestButton;
        private System.Windows.Forms.Button ReviewAttemptButton;
        private System.Windows.Forms.TextBox SeacrhBox;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label SeacrhLabel;
    }
}