namespace Testing_students.Forms.AttemptsManage.Info
{
    partial class AttemptInfoForm
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
            this.AttemptInfoGrid = new System.Windows.Forms.DataGridView();
            this.ChangePointButton = new System.Windows.Forms.Button();
            this.DeleteAttempButton = new System.Windows.Forms.Button();
            this.ClearAttempButton = new System.Windows.Forms.Button();
            this.CheckAnswersButton = new System.Windows.Forms.Button();
            this.ReviewPDFButton = new System.Windows.Forms.Button();
            this.SearchNameBox = new System.Windows.Forms.TextBox();
            this.SearchNameLabel = new System.Windows.Forms.Label();
            this.SearchStatusLabel = new System.Windows.Forms.Label();
            this.SearchStatusBox = new System.Windows.Forms.TextBox();
            this.SearchPointLabel = new System.Windows.Forms.Label();
            this.SearchPointBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AttemptInfoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // AttemptInfoGrid
            // 
            this.AttemptInfoGrid.AllowUserToAddRows = false;
            this.AttemptInfoGrid.AllowUserToDeleteRows = false;
            this.AttemptInfoGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttemptInfoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttemptInfoGrid.Location = new System.Drawing.Point(12, 12);
            this.AttemptInfoGrid.Name = "AttemptInfoGrid";
            this.AttemptInfoGrid.ReadOnly = true;
            this.AttemptInfoGrid.RowHeadersWidth = 51;
            this.AttemptInfoGrid.RowTemplate.Height = 24;
            this.AttemptInfoGrid.Size = new System.Drawing.Size(708, 372);
            this.AttemptInfoGrid.TabIndex = 0;
            // 
            // ChangePointButton
            // 
            this.ChangePointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangePointButton.Location = new System.Drawing.Point(587, 390);
            this.ChangePointButton.Name = "ChangePointButton";
            this.ChangePointButton.Size = new System.Drawing.Size(133, 23);
            this.ChangePointButton.TabIndex = 1;
            this.ChangePointButton.Text = "Змінити оцінку";
            this.ChangePointButton.UseVisualStyleBackColor = true;
            this.ChangePointButton.Click += new System.EventHandler(this.ChangePointButton_Click);
            // 
            // DeleteAttempButton
            // 
            this.DeleteAttempButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteAttempButton.Location = new System.Drawing.Point(309, 390);
            this.DeleteAttempButton.Name = "DeleteAttempButton";
            this.DeleteAttempButton.Size = new System.Drawing.Size(133, 23);
            this.DeleteAttempButton.TabIndex = 2;
            this.DeleteAttempButton.Text = "Видалити";
            this.DeleteAttempButton.UseVisualStyleBackColor = true;
            this.DeleteAttempButton.Click += new System.EventHandler(this.DeleteAttempButton_Click);
            // 
            // ClearAttempButton
            // 
            this.ClearAttempButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearAttempButton.Location = new System.Drawing.Point(448, 390);
            this.ClearAttempButton.Name = "ClearAttempButton";
            this.ClearAttempButton.Size = new System.Drawing.Size(133, 23);
            this.ClearAttempButton.TabIndex = 3;
            this.ClearAttempButton.Text = "Очистити";
            this.ClearAttempButton.UseVisualStyleBackColor = true;
            this.ClearAttempButton.Click += new System.EventHandler(this.ClearAttempButton_Click);
            // 
            // CheckAnswersButton
            // 
            this.CheckAnswersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CheckAnswersButton.Location = new System.Drawing.Point(9, 390);
            this.CheckAnswersButton.Name = "CheckAnswersButton";
            this.CheckAnswersButton.Size = new System.Drawing.Size(133, 23);
            this.CheckAnswersButton.TabIndex = 4;
            this.CheckAnswersButton.Text = "Перевірити";
            this.CheckAnswersButton.UseVisualStyleBackColor = true;
            this.CheckAnswersButton.Click += new System.EventHandler(this.CheckAnswersButton_Click);
            // 
            // ReviewPDFButton
            // 
            this.ReviewPDFButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReviewPDFButton.Location = new System.Drawing.Point(148, 390);
            this.ReviewPDFButton.Name = "ReviewPDFButton";
            this.ReviewPDFButton.Size = new System.Drawing.Size(133, 23);
            this.ReviewPDFButton.TabIndex = 5;
            this.ReviewPDFButton.Text = "Звіт";
            this.ReviewPDFButton.UseVisualStyleBackColor = true;
            this.ReviewPDFButton.Click += new System.EventHandler(this.ReviewPDFButton_Click);
            // 
            // SearchNameBox
            // 
            this.SearchNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchNameBox.Location = new System.Drawing.Point(47, 422);
            this.SearchNameBox.Name = "SearchNameBox";
            this.SearchNameBox.Size = new System.Drawing.Size(241, 22);
            this.SearchNameBox.TabIndex = 6;
            this.SearchNameBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchNameLabel
            // 
            this.SearchNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchNameLabel.AutoSize = true;
            this.SearchNameLabel.Location = new System.Drawing.Point(9, 425);
            this.SearchNameLabel.Name = "SearchNameLabel";
            this.SearchNameLabel.Size = new System.Drawing.Size(32, 16);
            this.SearchNameLabel.TabIndex = 7;
            this.SearchNameLabel.Text = "Ім\'я:";
            // 
            // SearchStatusLabel
            // 
            this.SearchStatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchStatusLabel.AutoSize = true;
            this.SearchStatusLabel.Location = new System.Drawing.Point(294, 425);
            this.SearchStatusLabel.Name = "SearchStatusLabel";
            this.SearchStatusLabel.Size = new System.Drawing.Size(56, 16);
            this.SearchStatusLabel.TabIndex = 9;
            this.SearchStatusLabel.Text = "Статус:";
            // 
            // SearchStatusBox
            // 
            this.SearchStatusBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchStatusBox.Location = new System.Drawing.Point(356, 422);
            this.SearchStatusBox.Name = "SearchStatusBox";
            this.SearchStatusBox.Size = new System.Drawing.Size(149, 22);
            this.SearchStatusBox.TabIndex = 8;
            this.SearchStatusBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // SearchPointLabel
            // 
            this.SearchPointLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchPointLabel.AutoSize = true;
            this.SearchPointLabel.Location = new System.Drawing.Point(511, 425);
            this.SearchPointLabel.Name = "SearchPointLabel";
            this.SearchPointLabel.Size = new System.Drawing.Size(54, 16);
            this.SearchPointLabel.TabIndex = 11;
            this.SearchPointLabel.Text = "Оцінка:";
            // 
            // SearchPointBox
            // 
            this.SearchPointBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchPointBox.Location = new System.Drawing.Point(571, 422);
            this.SearchPointBox.Name = "SearchPointBox";
            this.SearchPointBox.Size = new System.Drawing.Size(149, 22);
            this.SearchPointBox.TabIndex = 10;
            this.SearchPointBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged);
            // 
            // AttemptInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 453);
            this.Controls.Add(this.SearchPointLabel);
            this.Controls.Add(this.SearchPointBox);
            this.Controls.Add(this.SearchStatusLabel);
            this.Controls.Add(this.SearchStatusBox);
            this.Controls.Add(this.SearchNameLabel);
            this.Controls.Add(this.SearchNameBox);
            this.Controls.Add(this.ReviewPDFButton);
            this.Controls.Add(this.CheckAnswersButton);
            this.Controls.Add(this.ClearAttempButton);
            this.Controls.Add(this.DeleteAttempButton);
            this.Controls.Add(this.ChangePointButton);
            this.Controls.Add(this.AttemptInfoGrid);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(750, 500);
            this.Name = "AttemptInfoForm";
            this.Text = "Інформація про спроби";
            ((System.ComponentModel.ISupportInitialize)(this.AttemptInfoGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AttemptInfoGrid;
        private System.Windows.Forms.Button ChangePointButton;
        private System.Windows.Forms.Button DeleteAttempButton;
        private System.Windows.Forms.Button ClearAttempButton;
        private System.Windows.Forms.Button CheckAnswersButton;
        private System.Windows.Forms.Button ReviewPDFButton;
        private System.Windows.Forms.TextBox SearchNameBox;
        private System.Windows.Forms.Label SearchNameLabel;
        private System.Windows.Forms.Label SearchStatusLabel;
        private System.Windows.Forms.TextBox SearchStatusBox;
        private System.Windows.Forms.Label SearchPointLabel;
        private System.Windows.Forms.TextBox SearchPointBox;
    }
}