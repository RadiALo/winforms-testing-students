namespace Testing_students.Forms.TestForms
{
    partial class PrestartTestForm
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
            this.TestNameLabel = new System.Windows.Forms.Label();
            this.TestDescriptionBox = new System.Windows.Forms.TextBox();
            this.StartTestButton = new System.Windows.Forms.Button();
            this.PassTimeLabel = new System.Windows.Forms.Label();
            this.QuestionsCountLabel = new System.Windows.Forms.Label();
            this.CommentBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TestNameLabel
            // 
            this.TestNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestNameLabel.AutoSize = true;
            this.TestNameLabel.Location = new System.Drawing.Point(12, 9);
            this.TestNameLabel.Name = "TestNameLabel";
            this.TestNameLabel.Size = new System.Drawing.Size(57, 16);
            this.TestNameLabel.TabIndex = 0;
            this.TestNameLabel.Text = "(Назва)";
            this.TestNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestDescriptionBox
            // 
            this.TestDescriptionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestDescriptionBox.Location = new System.Drawing.Point(12, 69);
            this.TestDescriptionBox.Multiline = true;
            this.TestDescriptionBox.Name = "TestDescriptionBox";
            this.TestDescriptionBox.ReadOnly = true;
            this.TestDescriptionBox.Size = new System.Drawing.Size(358, 149);
            this.TestDescriptionBox.TabIndex = 1;
            // 
            // StartTestButton
            // 
            this.StartTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTestButton.Location = new System.Drawing.Point(115, 293);
            this.StartTestButton.Name = "StartTestButton";
            this.StartTestButton.Size = new System.Drawing.Size(162, 23);
            this.StartTestButton.TabIndex = 2;
            this.StartTestButton.Text = "Старт";
            this.StartTestButton.UseVisualStyleBackColor = true;
            this.StartTestButton.Click += new System.EventHandler(this.StartTestButton_Click);
            // 
            // PassTimeLabel
            // 
            this.PassTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassTimeLabel.AutoSize = true;
            this.PassTimeLabel.Location = new System.Drawing.Point(12, 41);
            this.PassTimeLabel.Name = "PassTimeLabel";
            this.PassTimeLabel.Size = new System.Drawing.Size(147, 16);
            this.PassTimeLabel.TabIndex = 3;
            this.PassTimeLabel.Text = "(Час на проходження)";
            this.PassTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // QuestionsCountLabel
            // 
            this.QuestionsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionsCountLabel.AutoSize = true;
            this.QuestionsCountLabel.Location = new System.Drawing.Point(12, 25);
            this.QuestionsCountLabel.Name = "QuestionsCountLabel";
            this.QuestionsCountLabel.Size = new System.Drawing.Size(121, 16);
            this.QuestionsCountLabel.TabIndex = 4;
            this.QuestionsCountLabel.Text = "(Кількість питань)";
            this.QuestionsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CommentBox
            // 
            this.CommentBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentBox.Location = new System.Drawing.Point(12, 224);
            this.CommentBox.Multiline = true;
            this.CommentBox.Name = "CommentBox";
            this.CommentBox.ReadOnly = true;
            this.CommentBox.Size = new System.Drawing.Size(358, 63);
            this.CommentBox.TabIndex = 5;
            // 
            // PrestartTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 328);
            this.Controls.Add(this.CommentBox);
            this.Controls.Add(this.QuestionsCountLabel);
            this.Controls.Add(this.PassTimeLabel);
            this.Controls.Add(this.StartTestButton);
            this.Controls.Add(this.TestDescriptionBox);
            this.Controls.Add(this.TestNameLabel);
            this.MaximumSize = new System.Drawing.Size(400, 375);
            this.MinimumSize = new System.Drawing.Size(400, 375);
            this.Name = "PrestartTestForm";
            this.Text = "Про тест";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TestNameLabel;
        private System.Windows.Forms.TextBox TestDescriptionBox;
        private System.Windows.Forms.Button StartTestButton;
        private System.Windows.Forms.Label PassTimeLabel;
        private System.Windows.Forms.Label QuestionsCountLabel;
        private System.Windows.Forms.TextBox CommentBox;
    }
}