namespace Testing_students.Forms.TestForms
{
    partial class ResultsForm
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
            this.PointLabel = new System.Windows.Forms.Label();
            this.ReturnButton = new System.Windows.Forms.Button();
            this.AnswersInfoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PointLabel
            // 
            this.PointLabel.AutoSize = true;
            this.PointLabel.Location = new System.Drawing.Point(12, 9);
            this.PointLabel.Name = "PointLabel";
            this.PointLabel.Size = new System.Drawing.Size(0, 16);
            this.PointLabel.TabIndex = 0;
            // 
            // ReturnButton
            // 
            this.ReturnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReturnButton.Location = new System.Drawing.Point(12, 43);
            this.ReturnButton.Name = "ReturnButton";
            this.ReturnButton.Size = new System.Drawing.Size(101, 23);
            this.ReturnButton.TabIndex = 1;
            this.ReturnButton.Text = "Назад";
            this.ReturnButton.UseVisualStyleBackColor = true;
            this.ReturnButton.Click += new System.EventHandler(this.ReturnButton_Click);
            // 
            // AnswersInfoButton
            // 
            this.AnswersInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AnswersInfoButton.Location = new System.Drawing.Point(269, 43);
            this.AnswersInfoButton.Name = "AnswersInfoButton";
            this.AnswersInfoButton.Size = new System.Drawing.Size(101, 23);
            this.AnswersInfoButton.TabIndex = 2;
            this.AnswersInfoButton.Text = "Звіт";
            this.AnswersInfoButton.UseVisualStyleBackColor = true;
            this.AnswersInfoButton.Click += new System.EventHandler(this.AnswersInfoButton_Click);
            // 
            // ResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 78);
            this.Controls.Add(this.AnswersInfoButton);
            this.Controls.Add(this.ReturnButton);
            this.Controls.Add(this.PointLabel);
            this.MaximumSize = new System.Drawing.Size(400, 125);
            this.MinimumSize = new System.Drawing.Size(400, 125);
            this.Name = "ResultsForm";
            this.Text = "Результат";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PointLabel;
        private System.Windows.Forms.Button ReturnButton;
        private System.Windows.Forms.Button AnswersInfoButton;
    }
}