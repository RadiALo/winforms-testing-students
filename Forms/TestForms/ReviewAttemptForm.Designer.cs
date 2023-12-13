namespace Testing_students.Forms.TestForms
{
    partial class ReviewAttemptForm
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
            this.QuestionsList = new System.Windows.Forms.TabControl();
            this.ReviewPDFButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // QuestionsList
            // 
            this.QuestionsList.AllowDrop = true;
            this.QuestionsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QuestionsList.Location = new System.Drawing.Point(12, 12);
            this.QuestionsList.Name = "QuestionsList";
            this.QuestionsList.SelectedIndex = 0;
            this.QuestionsList.Size = new System.Drawing.Size(458, 355);
            this.QuestionsList.TabIndex = 1;
            // 
            // ReviewPDFButton
            // 
            this.ReviewPDFButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ReviewPDFButton.Location = new System.Drawing.Point(193, 373);
            this.ReviewPDFButton.Name = "ReviewPDFButton";
            this.ReviewPDFButton.Size = new System.Drawing.Size(106, 23);
            this.ReviewPDFButton.TabIndex = 2;
            this.ReviewPDFButton.Text = "Звіт";
            this.ReviewPDFButton.UseVisualStyleBackColor = true;
            this.ReviewPDFButton.Click += new System.EventHandler(this.ReviewPDFButton_Click);
            // 
            // ReviewAttemptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 403);
            this.Controls.Add(this.ReviewPDFButton);
            this.Controls.Add(this.QuestionsList);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "ReviewAttemptForm";
            this.Text = "Перегляд відповідей";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl QuestionsList;
        private System.Windows.Forms.Button ReviewPDFButton;
    }
}