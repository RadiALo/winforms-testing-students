namespace Testing_students.Forms.AttemptsManage
{
    partial class AttemptsListForm
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
            this.AttemptsGridView = new System.Windows.Forms.DataGridView();
            this.CreateNewAttemptView = new System.Windows.Forms.Button();
            this.AttemptViewButton = new System.Windows.Forms.Button();
            this.TestNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AttemptsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // AttemptsGridView
            // 
            this.AttemptsGridView.AllowUserToAddRows = false;
            this.AttemptsGridView.AllowUserToDeleteRows = false;
            this.AttemptsGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttemptsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttemptsGridView.Location = new System.Drawing.Point(12, 12);
            this.AttemptsGridView.Name = "AttemptsGridView";
            this.AttemptsGridView.ReadOnly = true;
            this.AttemptsGridView.RowHeadersWidth = 51;
            this.AttemptsGridView.RowTemplate.Height = 24;
            this.AttemptsGridView.Size = new System.Drawing.Size(708, 359);
            this.AttemptsGridView.TabIndex = 0;
            // 
            // CreateNewAttemptView
            // 
            this.CreateNewAttemptView.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CreateNewAttemptView.Location = new System.Drawing.Point(264, 418);
            this.CreateNewAttemptView.Name = "CreateNewAttemptView";
            this.CreateNewAttemptView.Size = new System.Drawing.Size(204, 23);
            this.CreateNewAttemptView.TabIndex = 1;
            this.CreateNewAttemptView.Text = "Створити нову спробу";
            this.CreateNewAttemptView.UseVisualStyleBackColor = true;
            this.CreateNewAttemptView.Click += new System.EventHandler(this.CreateNewAttemptView_Click);
            // 
            // AttemptViewButton
            // 
            this.AttemptViewButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AttemptViewButton.Location = new System.Drawing.Point(264, 389);
            this.AttemptViewButton.Name = "AttemptViewButton";
            this.AttemptViewButton.Size = new System.Drawing.Size(204, 23);
            this.AttemptViewButton.TabIndex = 2;
            this.AttemptViewButton.Text = "Переглянути інформацію";
            this.AttemptViewButton.UseVisualStyleBackColor = true;
            this.AttemptViewButton.Click += new System.EventHandler(this.AttemptViewButton_Click);
            // 
            // TestNameLabel
            // 
            this.TestNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TestNameLabel.AutoSize = true;
            this.TestNameLabel.Location = new System.Drawing.Point(12, 428);
            this.TestNameLabel.Name = "TestNameLabel";
            this.TestNameLabel.Size = new System.Drawing.Size(0, 16);
            this.TestNameLabel.TabIndex = 3;
            // 
            // ShowAttemptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 453);
            this.Controls.Add(this.TestNameLabel);
            this.Controls.Add(this.AttemptViewButton);
            this.Controls.Add(this.CreateNewAttemptView);
            this.Controls.Add(this.AttemptsGridView);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "ShowAttemptsForm";
            this.Text = "Перегляд спроб";
            ((System.ComponentModel.ISupportInitialize)(this.AttemptsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AttemptsGridView;
        private System.Windows.Forms.Button CreateNewAttemptView;
        private System.Windows.Forms.Button AttemptViewButton;
        private System.Windows.Forms.Label TestNameLabel;
    }
}